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

        private ProtocolPresenter presenter;
        private BioBotDataSets dataset;

        public ProtocolControl()
        {
            InitializeComponent();
            this.presenter = new ProtocolPresenter(this);
        }

        public void setProjectDataset(BioBotDataSets dataset)
        {
            this.dataset = dataset;
            initTree();
        }

        public void initTree()
        {
            foreach (BioBotDataSets.bbt_protocolRow protocol in this.dataset.bbt_protocol)
            {
                if (protocol.Isfk_protocolNull())
                {
                    addNodes(protocol, null);
                }
            }
        }

        public void addNodes(BioBotDataSets.bbt_protocolRow protocol, TreeNode parentNode)
        {
            ProtocolTreeNode currentNode = new ProtocolTreeNode(protocol);

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
                StepTreeNode stepNode = new StepTreeNode(step);
                currentNode.Nodes.Add(stepNode);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void tlvProtocols_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tlvProtocols_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if(e.Item is ProtocolTreeNode)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
            
        }

        private void tlvProtocols_DragDrop(object sender, DragEventArgs e)
        {
            ProtocolTreeNode procotolNode = (ProtocolTreeNode)e.Data.GetData(typeof(ProtocolTreeNode));
            Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode destinationNode = ((TreeView)sender).GetNodeAt(pt);
            ProtocolTreeNode destinationProtocolNode = null;

            if (destinationNode == null) return;

            if (destinationNode is ProtocolTreeNode)
            {
                destinationProtocolNode = (ProtocolTreeNode)destinationNode;
            }

            if(procotolNode != null)
            {
                TreeNode parentNode = procotolNode.Parent;
                parentNode.Nodes.Remove(procotolNode);
                procotolNode.getProtocolRow().fk_protocol = destinationProtocolNode.getProtocolRow().pk_id;
                destinationProtocolNode.Nodes.Add(procotolNode);
            }

            this.presenter.updateProtocol();
        }
    }
}
