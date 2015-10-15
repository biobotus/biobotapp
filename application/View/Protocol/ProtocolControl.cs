using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Protocols;
using BioBotApp.Presenter;
using BioBotApp.View.Utils;
using BioBotApp.Model.Data;

namespace BioBotApp.View.Protocol
{
    public partial class ProtocolControl : UserControl, IProtocolView
    {

        private ProtocolPresenter _presenter;
        private BioBotDataSets _dataset;

        public ProtocolControl()
        {
            InitializeComponent();
            _presenter = new ProtocolPresenter(this);
        }

        public void setProjectDataset(BioBotDataSets dataset)
        {
            _dataset = dataset;
            initTree();
        }

        public void initTree()
        {
            foreach (BioBotDataSets.bbt_protocolRow protocol in _dataset.bbt_protocol)
            {
                if (protocol.Isfk_protocolNull())
                {
                    addNodes(protocol, null);
                }
            }
        }

        public void addNodes(BioBotDataSets.bbt_protocolRow protocol, TreeNode parentNode)
        {
            ProtocolTreeNode currentNode = new ProtocolTreeNode(protocol.description);

            if (parentNode == null)
            {
                tlvProtocols.Nodes.Add(currentNode);
            }
            else
            {
                parentNode.Nodes.Add(currentNode);
            }

            foreach (BioBotDataSets.bbt_protocolRow childProtocol in protocol.Getbbt_protocolRows())
            {
                addNodes(childProtocol, currentNode);
            }

            foreach(BioBotDataSets.bbt_stepRow step in protocol.Getbbt_stepRows())
            {
                StepTreeNode stepNode = new StepTreeNode(step.description);
                currentNode.Nodes.Add(stepNode);
            }
        }
    }
}
