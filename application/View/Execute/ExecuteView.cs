using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data;
using BioBotApp.View.Protocol;
using BioBotApp.Presenter.Sequencer;
using BioBotApp.View.Utils;

namespace BioBotApp.View.Execute
{
    public partial class ExecuteView : DatasetViewControl, ISequencerView
    {
        TreeNode executeDropTreeNode;
        SequencerPresenter presenter;

        public ExecuteView()
        {
            InitializeComponent();
            this.presenter = new SequencerPresenter(this);
            
        }

        private void tlvProtocol_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = tlvProtocol.PointToClient(new Point(e.X, e.Y));
            
            StepTreeNode treeNodeStep = (StepTreeNode)e.Data.GetData(typeof(StepTreeNode));
            ProtocolTreeNode treeNodeProtocol = (ProtocolTreeNode)e.Data.GetData(typeof(ProtocolTreeNode));
            TreeNode dragNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (treeNodeStep != null)
            {
                dragNode = treeNodeStep as TreeNode;
            }
            else if (treeNodeProtocol != null)
            {
                dragNode = treeNodeProtocol as TreeNode;
            }

            if(dragNode.TreeView == this.tlvProtocol)
            {
                return;
            }
            else
            {
                if (treeNodeProtocol != null)
                {
                    addNodes(treeNodeProtocol.getProtocolRow(), null);
                }
                else if (treeNodeStep != null)
                {
                    tlvProtocol.Nodes.Add(new StepTreeNode(treeNodeStep.getStepRow()));
                }
            }
        }

        public void addNodes(BioBotDataSets.bbt_protocolRow row, TreeNode parentNode)
        {
            TreeNode treeNode = new ProtocolTreeNode(row);

            if (parentNode == null)
            {
                tlvProtocol.Nodes.Add(treeNode);
            }
            else
            {
                parentNode.Nodes.Add(treeNode);
            }
            foreach (BioBotDataSets.bbt_stepRow stepRow in row.Getbbt_stepRows())
            {
                TreeNode stepNode = new StepTreeNode(stepRow);
                treeNode.Nodes.Add(stepNode);
            }
            foreach (BioBotDataSets.bbt_protocolRow childRows in row.Getbbt_protocolRows())
            {
                addNodes(childRows, treeNode);
            }
        }


        private void tlvProtocol_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            //tlvProtocol.SelectedNode;
            //executeDropTreeNode = 
        }
        
        private void tlvProtocol_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tlvProtocol_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void btnExectue_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_save_protocol_referenceDataTable table = new BioBotDataSets.bbt_save_protocol_referenceDataTable();
            int index = 1;
            foreach (TreeNode node in tlvProtocol.Nodes)
            {
                BioBotDataSets.bbt_save_protocol_referenceRow row = table.Newbbt_save_protocol_referenceRow();
                if (node is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = node as ProtocolTreeNode;
                    row.fk_protocol = protocolNode.getProtocolRow().pk_id;
                }
                else if (node is StepTreeNode)
                {
                    StepTreeNode stepNode = node as StepTreeNode;
                    row.fk_step = stepNode.getStepRow().pk_id;
                }
                row.fk_save_protocol = 0; //un-saved work
                row.index = index++;
                table.Addbbt_save_protocol_referenceRow(row);
            }
            
            this.presenter.executeProtocol(table);
        }
        /*
        public BioBotDataSets.bbt_save_protocol_referenceDataTable generateExectuteSequence()
        {

            int i = 1;
            foreach(TreeNode childNode in node.Nodes)
            {
                if(childNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = childNode as ProtocolTreeNode;
                    BioBotDataSets.bbt_protocolRow protocolRow = protocolNode.getProtocolRow();
                }
                else if(childNode is StepTreeNode)
                {
                    StepTreeNode stepNode = childNode as StepTreeNode;
                    BioBotDataSets.bbt_stepRow stepRow = stepNode.getStepRow();
                }
            }
        }*/
    }
}

