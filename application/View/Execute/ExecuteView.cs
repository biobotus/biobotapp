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

namespace BioBotApp.View.Execute
{
    public partial class ExecuteView : UserControl
    {
        public ExecuteView()
        {
            InitializeComponent();
        }

        private void tlvProtocol_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = tlvProtocol.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = tlvProtocol.GetNodeAt(targetPoint);
            TreeNode dropNode = new TreeNode();
            StepTreeNode treeNodeStep = (StepTreeNode)e.Data.GetData(typeof(StepTreeNode));
            ProtocolTreeNode treeNodeProtocol = (ProtocolTreeNode)e.Data.GetData(typeof(ProtocolTreeNode));
            List < BioBotDataSets.bbt_stepRow > listStep = new List<BioBotDataSets.bbt_stepRow>();
            if (treeNodeProtocol != null)
            {
                addNodes(treeNodeProtocol.getProtocolRow(), targetNode);
            }
            else if (treeNodeStep!= null)
            {
                targetNode.Nodes.Add(new StepTreeNode(treeNodeStep.getStepRow()));
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

            foreach (BioBotDataSets.bbt_protocolRow childRows in row.Getbbt_protocolRows())
            {
                addNodes(childRows, treeNode);
            }

            foreach (BioBotDataSets.bbt_stepRow stepRow in row.Getbbt_stepRows())
            {
                TreeNode StepTreeNode = new StepTreeNode(stepRow);
                treeNode.Nodes.Add(StepTreeNode);
            }
        }


        private void tlvProtocol_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        //private void btnAdd_Click(object sender, EventArgs e)
        //{
        //    frmNewProtocol frmProtocolAdd = new frmNewProtocol();
        //    DialogResult dialogResultAddNode = DialogResult.Cancel;
        //    dialogResultAddNode = frmProtocolAdd.ShowDialog();
        //    if (dialogResultAddNode == DialogResult.OK)
        //    {
        //        if (dialogResultAddNode.Equals(DialogResult.OK))
        //        {
        //            ProtocolTreeNode treeNode = new ProtocolTreeNode(frmProtocolAdd.getStepName());
        //            if (tlvProtocol.SelectedNode != null)
        //            {
        //                tlvProtocol.SelectedNode.Nodes.Add(treeNode);
        //            }
        //            else
        //            {
        //                tlvProtocol.Nodes.Add(treeNode);
        //            }
        //        }
        //    }
        //}

        //private void btnStart_Click(object sender, EventArgs e)
        //{
        //    if (tlvProtocol.SelectedNode == null)
        //    {
        //        return;
        //    }

        //    executeAction(tlvProtocol.SelectedNode);
        //}

        //public void executeAction(TreeNode treeNode)
        //{
        //    if (treeNode is StepCompositeNode || treeNode is TreeNode)
        //    {
        //        foreach (TreeNode childNodes in treeNode.Nodes)
        //        {
        //            executeAction(childNodes);
        //        }
        //    }

        //    if (treeNode is StepLeafNode)
        //    {
        //        StepLeafNode stepLeafNode = treeNode as StepLeafNode;


        //        DataSets.dsModuleStructure3.dtStepLeafRow stepLeaf = stepLeafNode.getStepLeaf();
        //        DataSets.dsModuleStructure3.dtActionValueRow[] actionValueRows = stepLeaf.GetdtActionValueRows();



        //        //DataSets.dsModuleStructure3.dtActionValueDataTable table = stepLeafNode.getActionValueDataTable();

        //        foreach (DataSets.dsModuleStructure3.dtActionValueRow actionValueRow in actionValueRows)
        //        {
        //            mainProtocol.executeAction(actionValueRow);
        //        }


        //    }
        //}

        //private void btnReset_Click(object sender, EventArgs e)
        //{
        //    tlvProtocol.Nodes.Clear();
        //}

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    tlvProtocol.Nodes.Remove(tlvProtocol.SelectedNode);
        //}



        //private void LoadButton_Click(object sender, EventArgs e)
        //{

        //    LoadDialog LoadDialogAdd = new LoadDialog();
        //    DialogResult dialogResultAddNode = DialogResult.Cancel;
        //    dialogResultAddNode = LoadDialogAdd.ShowDialog();

        //    if (dialogResultAddNode == DialogResult.OK)
        //        if (LoadDialogAdd.DialogResult.Equals(DialogResult.OK))
        //        {
        //            ProtocolTreeNode treeNode = new ProtocolTreeNode(LoadDialogAdd.getProtocolName());
        //            DataGridView DGV = LoadDialogAdd.getDGV();
        //            tlvProtocol.Nodes.Add(treeNode);
        //            DataSets.dsModuleStructure3.dtSavedProtocolRow row;
        //            DataSets.dsModuleStructure3.dtStepCompositeRow Compositerow;

        //            foreach (DataGridViewRow DGVrow in DGV.Rows)
        //            {
        //                DataRowView rowView = DGVrow.DataBoundItem as DataRowView;
        //                row = rowView.Row as DataSets.dsModuleStructure3.dtSavedProtocolRow;

        //                foreach (DataSets.dsModuleStructure3.dtStepCompositeRow CompositeRow in dsModuleStructure.dtStepComposite)
        //                {
        //                    if (row.fk_step_composite == CompositeRow.pk_id)
        //                    {
        //                        addNodes(CompositeRow, treeNode);
        //                    }
        //                }
        //            }
        //        }

        //    //if (result == DialogResult.OK)
        //    //{
        //    //    LoadTree(tlvProtocol, dialogue.FileName);
        //    //}
        //}
        ////public void SaveTree(TreeNode treeNode, string description)
        ////{
        ////    BioBotDataSets.bbt_save_protocolRow newSaveProtocol = Model.Data.Services.SaveProtocolService.Instance.addSaveStepRow(description);
        ////}

        ////public void SaveTree(TreeNode treeNode)
        ////{
            
        ////    int parentNode = protocol
        ////    if (treeNode is TreeNode && !(treeNode is StepTreeNode))
        ////    {
        ////        foreach (TreeNode childNodes in treeNode.Nodes)
        ////        {
        ////            ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
        ////            BioBotDataSets.bbt_protocolRow protocol = protocolNode.getProtocolRow();
        ////            Model.Data.Services.SaveProtocolService.Instance.addSaveProtocolRow(parentNode, protocol.pk_id, protocol.description);
        ////            parentNode = protocol.pk_id;
        ////            SaveTree(childNodes);
        ////        }
        ////    }

        ////    if (treeNode is StepTreeNode)
        ////    {

        ////        StepTreeNode stepNode = treeNode as StepTreeNode;

        ////        BioBotDataSets.bbt_stepRow step = stepNode.getStepRow();

        ////        BioBotDataSets.bbt_save_protocolRow row;
        ////        //DataSets.dsModuleStructure3.dtSavedProtocolRow test;
        ////        //row = dsModuleStructureGUI.dtSavedProtocol.NewdtSavedProtocolRow();
        ////        row = dsModuleStructure.dtSavedProtocol.NewdtSavedProtocolRow();
        ////        row.description = stepCompositeNode.Parent.Text;
        ////        row.fk_step_composite = stepComposite.pk_id;
        ////        dsModuleStructure.dtSavedProtocol.AdddtSavedProtocolRow(row);
        ////        updateRow(row);


        ////    }

        //    }
            //public void addrow(TreeNode treeNode)
            //{

            //    //StepCompositeNode stepCompositeNode = treeNode as StepCompositeNode;

            //    //DataSets.dsModuleStructure3.dtStepCompositeRow stepComposite = stepCompositeNode.getStepCompositeRow();

            //    //DataSets.dsModuleStructure3.dtSavedProtocolRow row;
            //    ////DataSets.dsModuleStructure3.dtSavedProtocolRow test;
            //    //row = dsModuleStructureGUI.dtSavedProtocol.NewdtSavedProtocolRow();
            //    //row.Description = stepCompositeNode.Parent.Text;
            //    //row.fk_step_composite = stepComposite.pk_id;
            //    //dsModuleStructureGUI.dtSavedProtocol.AdddtSavedProtocolRow(row);
            //    //updateRow(row);

            //}

            //private void updateRow(DataSets.dsModuleStructure3.dtSavedProtocolRow updateRow)
            //{
            //    try
            //    {
            //        ta_Saved_Protocol.Update(updateRow);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Invalid action type, try again !",
            //        "Error !",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //        dsModuleStructure.RejectChanges();
            //    }
            //}

            //public static void LoadTree(TreeView tree, string filename)
            //{
            //    using (Stream file = File.Open(filename, FileMode.Open))
            //    {
            //        BinaryFormatter bf = new BinaryFormatter();
            //        object obj = bf.Deserialize(file);

            //        TreeNode[] nodeList = (obj as IEnumerable<TreeNode>).ToArray();
            //        tree.Nodes.AddRange(nodeList);
            //    }
            //}


        private void tlvProtocol_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {


            //   SaveTree(tlvProtocol.SelectedNode);

        }
}
}
    
