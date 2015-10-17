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
            TreeNode selectedNode = tlvProtocols.SelectedNode;
                     
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
            TreeView treeView = ((TreeView)sender);
            ProtocolTreeNode procotolNode = (ProtocolTreeNode)e.Data.GetData(typeof(ProtocolTreeNode));

            if (treeView == null) return;

            Point pt = treeView.PointToClient(new Point(e.X, e.Y));
            TreeNode destinationNode = treeView.GetNodeAt(pt);
            ProtocolTreeNode destinationProtocolNode = null;

            if (destinationNode == null) return;

            if (destinationNode is ProtocolTreeNode)
            {
                destinationProtocolNode = (ProtocolTreeNode)destinationNode;
            }

            if(procotolNode != null)
            {
                TreeNode parentNode = procotolNode.Parent;

                if (!isChildNodePresent(procotolNode, destinationProtocolNode))
                {
                    if (parentNode == null)
                    {
                        tlvProtocols.Nodes.Remove(procotolNode);
                    }
                    else
                    {
                        parentNode.Nodes.Remove(procotolNode);
                    }
                    destinationProtocolNode.Nodes.Add(procotolNode);
                    procotolNode.getProtocolRow().fk_protocol = destinationProtocolNode.getProtocolRow().pk_id;
                }
            }

            this.presenter.updateProtocol();
        }

        public Boolean isChildNodePresent(TreeNode parentNode,TreeNode childNode)
        {
            Boolean isPresent = false;

            foreach(TreeNode child in parentNode.Nodes)
            {
                if (isPresent) return isPresent;
                if (child == childNode) return true;
                isPresent = isChildNodePresent(child, childNode);
            }

            return isPresent;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
