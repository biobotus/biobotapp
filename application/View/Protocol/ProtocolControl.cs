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
using BioBotApp.View.Step;
using BioBotApp.Presenter.Step;

namespace BioBotApp.View.Protocol
{
    public partial class ProtocolControl : DatasetViewControl, IProtocolView, IStepView
    {

        private ProtocolPresenter presenter;
        private StepPresenter stepPresenter;

        public ProtocolControl()
        {
            InitializeComponent();
            this.presenter = new ProtocolPresenter(this);
            stepPresenter = new StepPresenter(this);
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

            foreach (BioBotDataSets.bbt_stepRow step in protocol.Getbbt_stepRows())
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
            if (e.Item is ProtocolTreeNode)
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

            if (procotolNode != null)
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
                    procotolNode.getProtocolRow().index = destinationProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + 1;
                }
            }

            this.presenter.updateProtocol();
        }

        public Boolean isChildNodePresent(TreeNode parentNode, TreeNode childNode)
        {
            Boolean isPresent = false;

            foreach (TreeNode child in parentNode.Nodes)
            {
                if (isPresent) return isPresent;
                if (child == childNode) return true;
                isPresent = isChildNodePresent(child, childNode);
            }

            return isPresent;
        }

        public ProtocolTreeNode getSelectedProtocolTreeNode()
        {
            if (tlvProtocols.SelectedNode == null) return null;
            if (!(tlvProtocols.SelectedNode is ProtocolTreeNode)) return null;
            ProtocolTreeNode protocolNode = tlvProtocols.SelectedNode as ProtocolTreeNode;
            if (protocolNode.getProtocolRow() == null) return null;
            return protocolNode;
        }

        public StepTreeNode getSelectedStepTreeNode()
        {
            if (tlvProtocols.SelectedNode == null) return null;
            if (!(tlvProtocols.SelectedNode is StepTreeNode)) return null;
            StepTreeNode stepNode = tlvProtocols.SelectedNode as StepTreeNode;
            if (stepNode.getStepRow() == null) return null;
            return stepNode;
        }

        public BioBotDataSets.bbt_stepRow getSelectedStepRow()
        {
            StepTreeNode stepNode = getSelectedStepTreeNode();
            if (stepNode == null) return null;
            return stepNode.getStepRow();
        }

        public BioBotDataSets.bbt_protocolRow getSelectedProtocolRow()
        {
            ProtocolTreeNode protocolNode = getSelectedProtocolTreeNode();
            if (protocolNode == null) return null;
            return protocolNode.getProtocolRow();
        }

        public int getSelectProtocolIndex()
        {
            ProtocolTreeNode protocolNode = getSelectedProtocolTreeNode();
            if (protocolNode == null) return -1;
            return protocolNode.getProtocolRow().pk_id;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(btnAdd, 0, btnAdd.Height);
        }

        public void onProtocolAddEvent(BioBotDataSets.bbt_protocolRow row)
        {
            if (row == null) return;
            if (!(row is Model.Data.BioBotDataSets.bbt_protocolRow)) return;
            Model.Data.BioBotDataSets.bbt_protocolRow protocolRow = row as Model.Data.BioBotDataSets.bbt_protocolRow;

            if (protocolRow.Isfk_protocolNull())
            {
                ProtocolTreeNode protocolNode = new ProtocolTreeNode(protocolRow);
                tlvProtocols.Nodes.Add(protocolNode);
            }
            else
            {
                foreach (TreeNode treeNode in tlvProtocols.Nodes)
                {
                    if (treeNode is ProtocolTreeNode)
                    {
                        ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
                        BioBotDataSets.bbt_protocolRow parentProtocolRow = protocolNode.getProtocolRow();
                        if(parentProtocolRow.pk_id == row.fk_protocol)
                        {
                            protocolNode.Nodes.Insert(protocolRow.index, new ProtocolTreeNode(protocolRow));
                            protocolNode.Expand();
                            tlvProtocols.SelectedNode = protocolNode;
                        }
                        else
                        {
                            addProtocolChildNode(protocolRow, protocolNode);
                        }
                    }
                }
            }
        }

        public void addProtocolChildNode(BioBotDataSets.bbt_protocolRow protocolRow, ProtocolTreeNode node)
        {
            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
                    BioBotDataSets.bbt_protocolRow parentProtocolRow = protocolNode.getProtocolRow();
                    if (parentProtocolRow.pk_id == protocolRow.fk_protocol)
                    {
                        protocolNode.Nodes.Insert(protocolRow.index, new ProtocolTreeNode(protocolRow));
                        protocolNode.Expand();
                        tlvProtocols.SelectedNode = protocolNode;
                    }
                    else
                    {
                        addProtocolChildNode(protocolRow, protocolNode);
                    }
                }
            }
        }

        public void addStepChildNode(BioBotDataSets.bbt_stepRow stepRow, ProtocolTreeNode node)
        {
            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
                    if (protocolNode.getProtocolRow().pk_id == stepRow.fk_protocol)
                    {
                        protocolNode.Nodes.Insert(stepRow.index, new StepTreeNode(stepRow));
                        protocolNode.Expand();
                        tlvProtocols.SelectedNode = protocolNode;
                    }
                    else
                    {
                        addStepChildNode(stepRow, protocolNode);
                    }
                }
            }
        }

        public void modifyProtocolChildNode(BioBotDataSets.bbt_protocolRow protocolRow, TreeNode node)
        {
            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
                    if (protocolNode.getProtocolRow().pk_id == protocolRow.pk_id)
                    {
                        protocolNode.setProtocolRow(protocolRow);
                    }
                    else
                    {
                        modifyProtocolChildNode(protocolRow, protocolNode);
                    }
                }
            }
        }

        public void modifyStepNode(BioBotDataSets.bbt_stepRow row, TreeNode node)
        {
            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode is StepTreeNode)
                {
                    StepTreeNode stepNode = treeNode as StepTreeNode;
                    if(stepNode.getStepRow().pk_id == row.pk_id)
                    {
                        stepNode.updateStepRow(row);
                    }
                }
                else
                {
                    modifyStepNode(row, treeNode);
                }
            }
        }

        public void onProtocolModifyEvent(BioBotDataSets.bbt_protocolRow row)
        {
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                modifyProtocolChildNode(row, node);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_protocolRow protocolRow = getSelectedProtocolRow();
            BioBotDataSets.bbt_stepRow stepRow = getSelectedStepRow();
            if (protocolRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Modify protocol", "Modify protocol");
                NamedInputTextBox input = new NamedInputTextBox("Protocol name:", protocolRow.description);
                dialog.addControl(input);
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    protocolRow.description = input.getInputTextValue();
                    this.presenter.modifyProtocolRow(protocolRow);
                }
            }
            else if(stepRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Modify step", "Modify step");
                StepControl control = new StepControl(stepRow);
                dialog.addControl(control);
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    String description = control.getDescription();
                    if (description == null) return;
                    int fkObjectId = control.getSelectedObjectRow().pk_id;
                    stepRow.description = description;
                    stepRow.fk_object = fkObjectId;
                    this.stepPresenter.modifyStepRow(stepRow);
                    //protocolRow.description = input.getInputTextValue();
                    //this.presenter.modifyProtocolRow(protocolRow);
                }
            }

            
        }

        private void btnUp_Click_1(object sender, EventArgs e)
        {
            if (tlvProtocols.SelectedNode == null) return;
            TreeNode node = tlvProtocols.SelectedNode;
            MoveUp(node);
            updateIndex(node);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (tlvProtocols.SelectedNode == null) return;
            TreeNode node = tlvProtocols.SelectedNode;
            MoveDown(node);
            updateIndex(node);
        }

        public void updateIndex(TreeNode node)
        {
            if (node.Parent == null) return;
            foreach (TreeNode childNode in node.Parent.Nodes)
            {
                if (childNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = childNode as ProtocolTreeNode;
                    BioBotDataSets.bbt_protocolRow protocolRow = protocolNode.getProtocolRow();
                    int newIndex = node.Parent.Nodes.IndexOf(childNode);
                    if (protocolRow.index != newIndex)
                    {
                        protocolNode.getProtocolRow().index = newIndex;
                        this.presenter.modifyProtocolRow(protocolRow);
                    }
                }
                else if(childNode is StepTreeNode)
                {
                    StepTreeNode stepNode = childNode as StepTreeNode;
                    BioBotDataSets.bbt_stepRow stepRow = stepNode.getStepRow();
                    int newIndex = node.Parent.Nodes.IndexOf(childNode) + 1;
                    if (stepRow.index != newIndex)
                    {
                        stepRow.index = newIndex;
                        this.stepPresenter.modifyStepRow(stepRow);
                    }
                }
            }
        }

        public void MoveUp(TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index > 0)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index - 1, node);
                }
            }
            else if (node.TreeView.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index > 0)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index - 1, node);
                }
            }
            tlvProtocols.SelectedNode = node;
        }

        public void MoveDown(TreeNode node)
        {
            TreeNode parent = node.Parent;
            TreeView view = node.TreeView;
            if (parent != null)
            {
                int index = parent.Nodes.IndexOf(node);
                if (index < parent.Nodes.Count - 1)
                {
                    parent.Nodes.RemoveAt(index);
                    parent.Nodes.Insert(index + 1, node);
                }
            }
            else if (view != null && view.Nodes.Contains(node)) //root node
            {
                int index = view.Nodes.IndexOf(node);
                if (index < view.Nodes.Count - 1)
                {
                    view.Nodes.RemoveAt(index);
                    view.Nodes.Insert(index + 1, node);
                }
            }
            tlvProtocols.SelectedNode = node;
        }

        private void btnAddProtocol_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add protocol", "Add new protocol");
            NamedInputTextBox input = new NamedInputTextBox("Protocol name:");
            dialog.addControl(input);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                int parentId = getSelectProtocolIndex();
                int index = 0;
                ProtocolTreeNode parentProtocolNode = getSelectedProtocolTreeNode();

                if (parentProtocolNode != null)
                {
                    index = parentProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + 1;
                }


                if (parentId >= 0)
                {

                    this.presenter.addProtocolRow(parentId, input.getInputTextValue(), index);
                }
                else
                {
                    this.presenter.addProtocolRow(input.getInputTextValue(), index);
                }
            }
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add step", "Add new step");
            StepControl control = new StepControl();
            dialog.addControl(control);
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                BioBotDataSets.bbt_protocolRow protocolRow = getSelectedProtocolRow();
                if (protocolRow == null) return;
                int protocolId = protocolRow.pk_id;
                if (protocolId < 0) return;
                int stepNextIndex = protocolRow.Getbbt_stepRows().Length;
                int index = protocolRow.Getbbt_stepRows().Length;
                this.stepPresenter.addStepRow(protocolId, control.getDescription(), control.getSelectedObjectRow().pk_id, index);
            }
        }

        public void addStepRow(BioBotDataSets.bbt_stepRow row)
        {
            if (row == null) return;
            if (!(row is Model.Data.BioBotDataSets.bbt_stepRow)) return;
            Model.Data.BioBotDataSets.bbt_stepRow stepRow = row as Model.Data.BioBotDataSets.bbt_stepRow;

            foreach (TreeNode treeNode in tlvProtocols.Nodes)
            {
                if (treeNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
                    addStepChildNode(stepRow, protocolNode);
                }
            }
        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {
            foreach(TreeNode node in tlvProtocols.Nodes)
            {
                modifyStepNode(stepRow,node);
            }
            
        }
    }
}
