using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter;
using BioBotApp.View.Utils;
using BioBotApp.Model.Data;
using BioBotApp.View.Step;
using BioBotApp.Presenter.Step;

namespace BioBotApp.View.Protocol
{
    public partial class ProtocolControl : DatasetViewControl, IProtocolView, IStepView
    {
        Boolean showSteps;

        [PropertyTab("Show toolbar")]
        [Browsable(true)]
        [Description("Show right toolbar"), Category("Behavior")]
        public bool ShowToolbar
        {
            get { return this.toolbarPanel.Visible; }
            set { this.toolbarPanel.Visible = value; }
        }

        [PropertyTab("Show steps")]
        [Browsable(true)]
        [Description("Show right steps"), Category("Behavior")]
        public bool ShowSteps
        {
            get { return showSteps; }
            set { showSteps = value; Console.WriteLine("showSteps" + value); }
        }

        private ProtocolPresenter presenter;
        private StepPresenter stepPresenter;

        public ProtocolControl()
        {
            InitializeComponent();
            this.presenter = new ProtocolPresenter(this);
            stepPresenter = new StepPresenter(this);

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
            int size = protocol.Getbbt_protocolRows().Length + protocol.Getbbt_stepRows().Length;
            BioBotDataSets.bbt_protocolRow[] protocolRows = protocol.Getbbt_protocolRows();
            BioBotDataSets.bbt_stepRow[] stepRows = protocol.Getbbt_stepRows();
            if (parentNode == null)
            {
                parentNode = new ProtocolTreeNode(protocol);
                tlvProtocols.Nodes.Add(parentNode);
            }

            for (int i = 0; i < size; i++)
            {
                addStepIndexNode(parentNode, stepRows, i + 1);
                addProtocolIndexNode(parentNode, protocolRows, i + 1);
            }

            /*


            ProtocolTreeNode currentNode = new ProtocolTreeNode(protocol);

            if (parentNode == null)
            {
                tlvProtocols.Nodes.Add(currentNode);
            }
            else
            {
                parentNode.Nodes.Add(currentNode);
            }

            if (showSteps)
            {
                foreach (BioBotDataSets.bbt_stepRow stepRow in protocol.Getbbt_stepRows())
                {
                    currentNode.Nodes.Add(new StepTreeNode(stepRow));
                }
            }

            foreach (BioBotDataSets.bbt_protocolRow childProtocol in protocol.Getbbt_protocolRows())
            {
                addNodes(childProtocol, currentNode);
            }
            */
        }

        public Boolean addStepIndexNode(TreeNode parentNode, BioBotDataSets.bbt_stepRow[] rows, int index)
        {
            foreach (BioBotDataSets.bbt_stepRow row in rows)
            {
                if (row.index == index)
                {
                    if (parentNode == null)
                    {
                        tlvProtocols.Nodes.Add(new StepTreeNode(row));
                    }
                    else
                    {
                        parentNode.Nodes.Add(new StepTreeNode(row));
                    }

                    return true;
                }
            }
            return false;
        }

        public void addProtocolIndexNode(TreeNode parentNode, BioBotDataSets.bbt_protocolRow[] rows, int index)
        {
            ProtocolTreeNode protocolNode;
            foreach (BioBotDataSets.bbt_protocolRow row in rows)
            {
                protocolNode = new ProtocolTreeNode(row);
                if (row.index == index)
                {
                    if (parentNode == null)
                    {

                        tlvProtocols.Nodes.Add(protocolNode);
                    }
                    else
                    {
                        parentNode.Nodes.Add(protocolNode);
                    }
                    addNodes(row, protocolNode);
                }
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
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tlvProtocols_DragDrop(object sender, DragEventArgs e)
        {
            TreeView treeView = ((TreeView)sender);
            ProtocolTreeNode procotolNode = (ProtocolTreeNode)e.Data.GetData(typeof(ProtocolTreeNode));
            StepTreeNode stepNode = (StepTreeNode)e.Data.GetData(typeof(StepTreeNode));
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
                    if (destinationProtocolNode == procotolNode) return;
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
                    procotolNode.getProtocolRow().index = destinationProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + destinationProtocolNode.getProtocolRow().Getbbt_stepRows().Length;
                }
                this.presenter.updateProtocol();
            }
            if(stepNode != null)
            {
                TreeNode parentNode = stepNode.Parent;
                if (!isChildNodePresent(stepNode, destinationProtocolNode))
                {
                    if (parentNode == null)
                    {
                        tlvProtocols.Nodes.Remove(stepNode);
                    }
                    else
                    {
                        parentNode.Nodes.Remove(stepNode);
                    }

                    destinationProtocolNode.Nodes.Add(stepNode);
                    destinationNode.Expand();
                    stepNode.getStepRow().fk_protocol = destinationProtocolNode.getProtocolRow().pk_id;
                    stepNode.getStepRow().index = destinationProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + destinationProtocolNode.getProtocolRow().Getbbt_stepRows().Length;
                }
                this.stepPresenter.modifyStepRow(stepNode.getStepRow());
            }
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
                    index = parentProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + parentProtocolNode.getProtocolRow().Getbbt_stepRows().Length + 1;
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
                        if (parentProtocolRow.pk_id == row.fk_protocol)
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


        }

        private void btnUp_Click_1(object sender, EventArgs e)
        {
            if (tlvProtocols.SelectedNode == null) return;
            TreeNode selectedNode = tlvProtocols.SelectedNode;
            MoveUp(selectedNode);
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                updateIndex(node, tlvProtocols.Nodes);
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (tlvProtocols.SelectedNode == null) return;
            TreeNode selectedNode = tlvProtocols.SelectedNode;
            MoveDown(selectedNode);
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                updateIndex(node, tlvProtocols.Nodes);
            }
        }

        public void updateIndex(TreeNode node, TreeNodeCollection nodes)
        {
            foreach (TreeNode childNode in nodes)
            {
                if (childNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = childNode as ProtocolTreeNode;
                    BioBotDataSets.bbt_protocolRow protocolRow = protocolNode.getProtocolRow();
                    int newIndex = nodes.IndexOf(childNode) + 1;
                    if (protocolRow.index != newIndex)
                    {
                        protocolNode.getProtocolRow().index = newIndex;
                        this.presenter.modifyProtocolRow(protocolRow);
                    }
                }
                else if (childNode is StepTreeNode)
                {
                    StepTreeNode stepNode = childNode as StepTreeNode;
                    BioBotDataSets.bbt_stepRow stepRow = stepNode.getStepRow();
                    int newIndex = nodes.IndexOf(childNode) + 1;
                    if (stepRow.index != newIndex)
                    {
                        stepNode.getStepRow().index = newIndex;
                        this.stepPresenter.modifyStepRow(stepRow);
                    }
                }
                updateIndex(childNode, childNode.Nodes);
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

        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add step", "Add new step");
            StepControl control = new StepControl();

            dialog.addControl(control);
            control.setStepRow(null);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                BioBotDataSets.bbt_protocolRow protocolRow = getSelectedProtocolRow();
                if (protocolRow == null) return;
                int protocolId = protocolRow.pk_id;
                if (protocolId < 0) return;
                int stepNextIndex = protocolRow.Getbbt_stepRows().Length;
                int index = protocolRow.Getbbt_stepRows().Length + protocolRow.Getbbt_protocolRows().Length + 1;
                this.stepPresenter.addStepRow(protocolId, control.getDescription(), control.getSelectedObjectRow().pk_id, index);
            }
        }


        public void deleteProtocolChildNode(int rowId, TreeNode node)
        {
            foreach (TreeNode treeNode in node.Nodes)
            {
                if (treeNode is ProtocolTreeNode)
                {
                    ProtocolTreeNode protocolNode = treeNode as ProtocolTreeNode;
                    int stepId = protocolNode.getId();
                    if (stepId >= 0)
                    {
                        if (stepId == rowId)
                        {
                            node.Nodes.Remove(protocolNode);
                            break;
                        }
                        else
                        {
                            deleteProtocolChildNode(rowId, protocolNode);
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TreeNode node = tlvProtocols.SelectedNode;
            if (node is ProtocolTreeNode)
            {
                ProtocolTreeNode protocolNode = node as ProtocolTreeNode;
                BioBotDataSets.bbt_protocolRow row = protocolNode.getProtocolRow();
                if (row == null) return;
                this.presenter.removeProtocolRow(row);
            }
        }

        public void onProtocolDeleteEvent(int rowId)
        {
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                deleteProtocolChildNode(rowId, node);
            }
        }

        public void setSelectedProtocolRow(BioBotDataSets.bbt_protocolRow row)
        {

        }

        private void tlvProtocols_AfterSelect(object sender, TreeViewEventArgs e)
        {
            BioBotDataSets.bbt_protocolRow row = getSelectedProtocolRow();
            if (row == null) return;
            this.presenter.setSelectedProtocolRow(row);
        }

        private void ProtocolControl_Load(object sender, EventArgs e)
        {
            initTree();
        }

        public void onStepAddEvent(BioBotDataSets.bbt_stepRow row)
        {
            foreach(TreeNode node in tlvProtocols.Nodes)
            {
                addStepRow(node, row);
            }
        }

        public void addStepRow(TreeNode parentNode, BioBotDataSets.bbt_stepRow row)
        {
            if (!(parentNode is ProtocolTreeNode)) return;
            if (row == null) return;
            ProtocolTreeNode protocolTreeNode = parentNode as ProtocolTreeNode;
            int id = protocolTreeNode.getProtocolRow().pk_id;
            if (row.fk_protocol == id)
            {
                protocolTreeNode.Nodes.Add(new StepTreeNode(row));
                return;
            }
            foreach(TreeNode node in parentNode.Nodes)
            {
                addStepRow(node,row);
            }
            
        }

        public void modifyStepRow(TreeNode parentNode, BioBotDataSets.bbt_stepRow row)
        {
            if (!(parentNode is ProtocolTreeNode)) return;
            if (row == null) return;
            ProtocolTreeNode protocolTreeNode = parentNode as ProtocolTreeNode;
            
            BioBotDataSets.bbt_protocolRow protocolRow = protocolTreeNode.getProtocolRow();
            int id = protocolRow.pk_id;
            if (row.fk_protocol == id)
            {
                protocolTreeNode.Nodes.Add(new StepTreeNode(row));
            }
            
            foreach(TreeNode otherStepNode in parentNode.Nodes)
            {
                if(otherStepNode is StepTreeNode)
                {
                    StepTreeNode stepNode = otherStepNode as StepTreeNode;
                    BioBotDataSets.bbt_stepRow stepRow = stepNode.getStepRow();
                    if(stepRow.pk_id == row.pk_id)
                    {

                    }
                }
            }

            foreach (TreeNode node in parentNode.Nodes)
            {
                addStepRow(node, row);
            }

        }

        public void onStepModifyEvent(BioBotDataSets.bbt_stepRow row)
        {
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                modifyStepRow(node, row);
            }
        }

        public void addStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }

        public void deleteStepRow(int id)
        {
        }
    }
}
