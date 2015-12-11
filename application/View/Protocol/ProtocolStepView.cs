using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.View.Step;
using BioBotApp.Model.Data;
using BioBotApp.View.Utils;
using BioBotApp.Presenter;
using BioBotApp.Presenter.Step;

namespace BioBotApp.View.Protocol
{
    public partial class ProtocolStepView : DatasetViewControl, IProtocolView, IStepView
    {

        [PropertyTab("Show toolbar")]
        [Browsable(true)]
        [Description("Show right toolbar"), Category("Behavior")]
        public bool ShowToolbar
        {
            get { return this.toolbarPanel.Visible; }
            set { this.toolbarPanel.Visible = value; }
        }


        ProtocolPresenter protocolPresenter;
        StepPresenter stepPResenter;
        BindingSource bsObject;

        public ProtocolStepView()
        {
            InitializeComponent();
            this.protocolPresenter = new ProtocolPresenter(this);
            this.stepPResenter = new StepPresenter(this);
            bsObject = new BindingSource();
            bsObject.DataSource = dataset;
            bsObject.DataMember = "bbt_object";
        }

        private void ProtocolStepView_Load(object sender, EventArgs e)
        {
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

        public void addProtocolNode(TreeNode node, BioBotDataSets.bbt_protocolRow row)
        {
            if (node is ProtocolTreeNode)
            {
                ProtocolTreeNode parentProtocolNode = node as ProtocolTreeNode;
                BioBotDataSets.bbt_protocolRow parentProtocolRow = parentProtocolNode.getProtocolRow();
                if (parentProtocolRow.pk_id == row.fk_protocol)
                {
                    parentProtocolNode.Nodes.Add(new ProtocolTreeNode(row));
                }
                else
                {
                    foreach (TreeNode childNodes in parentProtocolNode.Nodes)
                    {
                        addProtocolNode(childNodes, row);
                    }
                }
            }
        }

        public void addStepNode(TreeNode node, BioBotDataSets.bbt_stepRow row)
        {
            if (node is ProtocolTreeNode)
            {
                ProtocolTreeNode parentProtocolNode = node as ProtocolTreeNode;
                BioBotDataSets.bbt_protocolRow parentProtocolRow = parentProtocolNode.getProtocolRow();
                if (parentProtocolRow.pk_id == row.fk_protocol)
                {
                    parentProtocolNode.Nodes.Add(new StepTreeNode(row));
                }
                else
                {
                    foreach (TreeNode childNodes in parentProtocolNode.Nodes)
                    {
                        addStepNode(childNodes, row);
                    }
                }
            }
        }

        public ProtocolTreeNode findProtocolNodeById(TreeNode node, int id)
        {
            if (!(node is ProtocolTreeNode)) return null;
            ProtocolTreeNode returnNode = null;
            ProtocolTreeNode protocolNode = node as ProtocolTreeNode;
            if (protocolNode.getId() == id)
            {
                return protocolNode;
            }
            foreach (TreeNode childNodes in node.Nodes)
            {
                returnNode = findProtocolNodeById(childNodes, id);
                if (returnNode != null) return returnNode;
            }
            return returnNode;
        }

        public StepTreeNode findStepNodeById(TreeNode node, int id)
        {
            StepTreeNode returnNode = null;
            if (node is ProtocolTreeNode)
            {
                foreach (TreeNode childNodes in node.Nodes)
                {
                    returnNode = findStepNodeById(childNodes, id);
                    if (returnNode != null) return returnNode;
                }
            }
            else
            {
                StepTreeNode stepNode = node as StepTreeNode;
                if (stepNode.getId() == id)
                {
                    return stepNode;
                }
            }

            return returnNode;
        }


        #region inherit methods
        public void setSelectedProtocolRow(BioBotDataSets.bbt_protocolRow row)
        {
        }

        public void addStepRow(BioBotDataSets.bbt_stepRow row)
        {
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                addStepNode(node, row);
            }
        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow row)
        {
            StepTreeNode protocolNode = null;
            ProtocolTreeNode oldParentNode = null;
            ProtocolTreeNode newParentNode = null;

            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                protocolNode = findStepNodeById(node, row.pk_id);
                if (protocolNode != null) break;
            }
            if (protocolNode != null)
            {
                oldParentNode = protocolNode.Parent as ProtocolTreeNode;
            }

            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                newParentNode = findProtocolNodeById(node, row.fk_protocol);
            }

            if (oldParentNode != newParentNode)
            {
                if(newParentNode == null)
                {
                    oldParentNode.Nodes.Remove(protocolNode);
                    tlvProtocols.Nodes.Add(protocolNode);
                    oldParentNode = newParentNode;
                }
                else
                {
                    oldParentNode.Nodes.Remove(protocolNode);
                    newParentNode.Nodes.Add(protocolNode);
                    oldParentNode = newParentNode;
                }
                
            }

            int newIndex = oldParentNode.Nodes.IndexOf(protocolNode) + 1;
            if (newIndex != row.index)
            {
                oldParentNode.Nodes.RemoveAt(oldParentNode.Nodes.IndexOf(protocolNode));
                oldParentNode.Nodes.Insert(row.index - 1, protocolNode);
            }

            protocolNode.setStepRow(row);
        }

        public void deleteStepRow(int id)
        {
            StepTreeNode stepNode = null;
            ProtocolTreeNode oldParentNode = null;
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                stepNode = findStepNodeById(node, id);
                if (stepNode != null) break;
            }

            if (stepNode != null)
            {
                oldParentNode = stepNode.Parent as ProtocolTreeNode;
            }

            oldParentNode.Nodes.RemoveAt(oldParentNode.Nodes.IndexOf(stepNode));
        }

        public void onProtocolAddEvent(BioBotDataSets.bbt_protocolRow row)
        {
            if (row.Isfk_protocolNull())
            {
                tlvProtocols.Nodes.Add(new ProtocolTreeNode(row));
            }
            else
            {
                foreach (TreeNode node in tlvProtocols.Nodes)
                {
                    addProtocolNode(node, row);
                }
            }
        }

        public void onProtocolModifyEvent(BioBotDataSets.bbt_protocolRow row)
        {
            ProtocolTreeNode protocolNode = null;
            ProtocolTreeNode oldParentNode = null;
            ProtocolTreeNode newParentNode = null;

            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                protocolNode = findProtocolNodeById(node, row.pk_id);
                if (protocolNode != null) break;
            }
            if (protocolNode != null)
            {
                oldParentNode = protocolNode.Parent as ProtocolTreeNode;
            }

            if (!row.Isfk_protocolNull())
            {
                foreach (TreeNode node in tlvProtocols.Nodes)
                {
                    newParentNode = findProtocolNodeById(node, row.fk_protocol);
                }
            }

            if (oldParentNode != newParentNode)
            {
                oldParentNode.Nodes.Remove(protocolNode);
                newParentNode.Nodes.Add(protocolNode);
                oldParentNode = newParentNode;
            }

            if(oldParentNode == null)
            {
                int newIndex = tlvProtocols.Nodes.IndexOf(protocolNode) + 1;
                if (newIndex != row.index)
                {
                    tlvProtocols.Nodes.RemoveAt(tlvProtocols.Nodes.IndexOf(protocolNode));
                    tlvProtocols.Nodes.Insert(row.index - 1, protocolNode);
                }
            }
            else
            {
                int newIndex = oldParentNode.Nodes.IndexOf(protocolNode) + 1;
                if (newIndex != row.index)
                {
                    oldParentNode.Nodes.RemoveAt(oldParentNode.Nodes.IndexOf(protocolNode));
                    oldParentNode.Nodes.Insert(row.index - 1, protocolNode);
                }
            }
            

            protocolNode.setProtocolRow(row);
        }

        public void onProtocolDeleteEvent(int rowId)
        {
            ProtocolTreeNode protocolNode = null;
            ProtocolTreeNode oldParentNode = null;
            foreach (TreeNode node in tlvProtocols.Nodes)
            {
                protocolNode = findProtocolNodeById(node, rowId);
                if (protocolNode != null) break;
            }

            if (protocolNode != null)
            {
                oldParentNode = protocolNode.Parent as ProtocolTreeNode;
            }
            if(oldParentNode == null)
            {
                tlvProtocols.Nodes.RemoveAt(tlvProtocols.Nodes.IndexOf(protocolNode));
            }
            else
            {
                oldParentNode.Nodes.RemoveAt(oldParentNode.Nodes.IndexOf(protocolNode));
            }
            
        }

        #endregion

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

        public StepTreeNode getSelectedStepNode()
        {
            if (tlvProtocols.SelectedNode == null) return null;
            if (!(tlvProtocols.SelectedNode is StepTreeNode)) return null;
            StepTreeNode stepNode = tlvProtocols.SelectedNode as StepTreeNode;
            if (stepNode.getStepRow() == null) return null;
            return stepNode;
        }

        public BioBotDataSets.bbt_stepRow getSelectedStepRow()
        {
            StepTreeNode stepNode = getSelectedStepNode();
            if (stepNode == null) return null;
            return stepNode.getStepRow();
        }

        public int getSelectProtocolIndex()
        {
            ProtocolTreeNode protocolNode = getSelectedProtocolTreeNode();
            if (protocolNode == null) return -1;
            return protocolNode.getProtocolRow().pk_id;
        }

        public BioBotDataSets.bbt_objectRow getSelectedObjectRow(BindingSource bindingSource)
        {
            if (bindingSource == null) return null;
            if (bindingSource.Current == null) return null;
            if (!(bindingSource.Current is DataRowView)) return null;
            DataRowView rowView = bindingSource.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_objectRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_objectRow;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(btnAdd, 0, btnAdd.Height);
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
                    this.protocolPresenter.modifyProtocolRow(protocolRow);
                }
            }
            if (stepRow != null)
            {
                AbstractDialog dialog = new AbstractDialog();
                if (stepRow == null) return;

                NamedInputTextBox stepDescription = new NamedInputTextBox("Description: ", stepRow.description);
                NamedInputTextBox stepValue = new NamedInputTextBox("Value: ", stepRow.value);
                namedComboBox stepObjectReference = new namedComboBox("Object: ");
                stepObjectReference.getComboBox().DataSource = this.bsObject;
                stepObjectReference.getComboBox().DisplayMember = "description";
                stepObjectReference.getComboBox().ValueMember = "pk_id";
                stepObjectReference.getComboBox().SelectedValue = stepRow.fk_object;
                dialog.addControl(stepDescription);
                dialog.addControl(stepObjectReference);
                dialog.addControl(stepValue);

                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    String description = stepDescription.getInputTextValue();
                    String value = stepValue.getInputTextValue();

                    if (description == null) return;
                    if (description == String.Empty) return;
                    if (!(stepObjectReference.getComboBox().DataSource is BindingSource)) return;
                    BioBotDataSets.bbt_objectRow objectRow = getSelectedObjectRow(stepObjectReference.getComboBox().DataSource as BindingSource);
                    stepRow.description = description;
                    stepRow.value = value;
                    stepRow.fk_object = objectRow.pk_id;

                    this.stepPResenter.modifyStepRow(stepRow);
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
                this.protocolPresenter.removeProtocolRow(row);
            }
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
                    index = parentProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + parentProtocolNode.getProtocolRow().Getbbt_stepRows().Length + 1;
                }


                if (parentId >= 0)
                {

                    this.protocolPresenter.addProtocolRow(parentId, input.getInputTextValue(), index);
                }
                else
                {
                    this.protocolPresenter.addProtocolRow(input.getInputTextValue(), index);
                }
            }
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog();
            NamedInputTextBox stepDescription = new NamedInputTextBox("Description: ", String.Empty);
            NamedInputTextBox stepValue = new NamedInputTextBox("Value: ", String.Empty);
            namedComboBox stepObjectReference = new namedComboBox("Object: ");
            stepObjectReference.getComboBox().DataSource = this.bsObject;
            stepObjectReference.getComboBox().DisplayMember = "description";
            stepObjectReference.getComboBox().ValueMember = "pk_id";

            dialog.addControl(stepDescription);
            dialog.addControl(stepObjectReference);
            dialog.addControl(stepValue);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String description = stepDescription.getInputTextValue();
                String value = stepValue.getInputTextValue();
                BioBotDataSets.bbt_protocolRow protocolRow = getSelectedProtocolRow();

                if (description == null) return;
                if (protocolRow == null) return;
                if (description == String.Empty) return;
                if (!(stepObjectReference.getComboBox().DataSource is BindingSource)) return;

                BioBotDataSets.bbt_objectRow objectRow = getSelectedObjectRow(stepObjectReference.getComboBox().DataSource as BindingSource);
                int index = protocolRow.Getbbt_stepRows().Length + protocolRow.Getbbt_protocolRows().Length + 1;

                this.stepPResenter.addStepRow(protocolRow.pk_id, description, objectRow.pk_id, index);
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            ProtocolTreeNode protocoleNode = getSelectedProtocolTreeNode();
            StepTreeNode stepNode = getSelectedStepNode();
            if (protocoleNode != null)
            {
                if (protocoleNode.getProtocolRow().index > 1)
                {
                    int index = protocoleNode.getProtocolRow().index;
                    TreeNode previousNode = protocoleNode.Parent.Nodes[index - 2] as TreeNode;
                    protocoleNode.getProtocolRow().index--;

                    if (previousNode is ProtocolTreeNode)
                    {
                        ProtocolTreeNode nextProtocolNode = previousNode as ProtocolTreeNode;
                        BioBotDataSets.bbt_protocolRow nextProtocolRow = nextProtocolNode.getProtocolRow();
                        nextProtocolRow.index++;
                        this.protocolPresenter.modifyProtocolRow(nextProtocolRow);
                    }
                    else if (previousNode is StepTreeNode)
                    {
                        StepTreeNode nextStepNode = previousNode as StepTreeNode;
                        BioBotDataSets.bbt_stepRow nextStepRow = nextStepNode.getStepRow();
                        nextStepRow.index++;
                        this.stepPResenter.modifyStepRow(nextStepRow);
                    }
                    this.protocolPresenter.modifyProtocolRow(protocoleNode.getProtocolRow());
                }
            }
            else if (stepNode != null)
            {
                if (stepNode.getStepRow().index > 1)
                {
                    int index = stepNode.getStepRow().index;
                    stepNode.getStepRow().index--;

                    TreeNode previousNode = stepNode.Parent.Nodes[index - 2] as TreeNode;
                    if (previousNode is ProtocolTreeNode)
                    {
                        ProtocolTreeNode nextProtocolNode = previousNode as ProtocolTreeNode;
                        BioBotDataSets.bbt_protocolRow nextProtocolRow = nextProtocolNode.getProtocolRow();
                        nextProtocolRow.index++;
                        this.protocolPresenter.modifyProtocolRow(nextProtocolRow);
                    }
                    else if (previousNode is StepTreeNode)
                    {
                        StepTreeNode nextStepNode = previousNode as StepTreeNode;
                        BioBotDataSets.bbt_stepRow nextStepRow = nextStepNode.getStepRow();
                        nextStepRow.index++;
                        this.stepPResenter.modifyStepRow(nextStepRow);
                    }
                    this.stepPResenter.modifyStepRow(stepNode.getStepRow());

                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            ProtocolTreeNode protocoleNode = getSelectedProtocolTreeNode();
            StepTreeNode stepNode = getSelectedStepNode();
            if (protocoleNode != null)
            {
                if (protocoleNode.getProtocolRow().index < protocoleNode.Parent.Nodes.Count)
                {
                    int index = protocoleNode.getProtocolRow().index;
                    TreeNode previousNode = protocoleNode.Parent.Nodes[index] as TreeNode;
                    BioBotDataSets.bbt_protocolRow protocolRow = protocoleNode.getProtocolRow();
                    protocolRow.index++;


                    if (previousNode is ProtocolTreeNode)
                    {
                        ProtocolTreeNode nextProtocolNode = previousNode as ProtocolTreeNode;
                        BioBotDataSets.bbt_protocolRow nextProtocolRow = nextProtocolNode.getProtocolRow();
                        nextProtocolRow.index--;
                        this.protocolPresenter.modifyProtocolRow(nextProtocolRow);
                    }
                    else if (previousNode is StepTreeNode)
                    {
                        StepTreeNode previousStepNode = previousNode as StepTreeNode;
                        BioBotDataSets.bbt_stepRow nextStepRow = previousStepNode.getStepRow();
                        nextStepRow.index--;
                        this.stepPResenter.modifyStepRow(nextStepRow);
                    }
                    this.protocolPresenter.modifyProtocolRow(protocolRow);
                }
            }
            else if (stepNode != null)
            {
                if (stepNode.getStepRow().index < stepNode.Parent.Nodes.Count)
                {
                    int index = stepNode.getStepRow().index;
                    BioBotDataSets.bbt_stepRow stepRow = stepNode.getStepRow();
                    stepRow.index++;

                    TreeNode previousNode = stepNode.Parent.Nodes[index] as TreeNode;

                    if (previousNode is ProtocolTreeNode)
                    {
                        ProtocolTreeNode nextProtocolNode = previousNode as ProtocolTreeNode;
                        BioBotDataSets.bbt_protocolRow nextProtocolRow = nextProtocolNode.getProtocolRow();
                        nextProtocolRow.index--;
                        this.protocolPresenter.modifyProtocolRow(nextProtocolRow);
                    }
                    else if (previousNode is StepTreeNode)
                    {
                        StepTreeNode nextStepNode = previousNode as StepTreeNode;
                        BioBotDataSets.bbt_stepRow nextStepRow = nextStepNode.getStepRow();
                        nextStepRow.index--;
                        this.stepPResenter.modifyStepRow(nextStepRow);
                    }
                    this.stepPResenter.modifyStepRow(stepNode.getStepRow());
                }
            }
        }

        private void tlvProtocols_DragDrop(object sender, DragEventArgs e)
        {
            if (ShowToolbar)
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
                        BioBotDataSets.bbt_protocolRow protocolRow = procotolNode.getProtocolRow();
                        protocolRow.fk_protocol = destinationProtocolNode.getProtocolRow().pk_id;
                        protocolRow.index = destinationProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + destinationProtocolNode.getProtocolRow().Getbbt_stepRows().Length;
                        this.protocolPresenter.modifyProtocolRow(protocolRow);
                    }
                }
                if (stepNode != null)
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

                        BioBotDataSets.bbt_stepRow stepRow = stepNode.getStepRow();
                        stepRow.fk_protocol = destinationProtocolNode.getProtocolRow().pk_id;
                        stepRow.index = destinationProtocolNode.getProtocolRow().Getbbt_protocolRows().Length + destinationProtocolNode.getProtocolRow().Getbbt_stepRows().Length;
                        this.stepPResenter.modifyStepRow(stepRow);
                    }
                }
                e.Effect = DragDropEffects.None;
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

        private void tlvProtocols_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tlvProtocols_DragEnter(object sender, DragEventArgs e)
        {
            if (ShowToolbar)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void tlvProtocols_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ProtocolTreeNode protocolTreeNode = getSelectedProtocolTreeNode();
            StepTreeNode stepTreeNode = getSelectedStepNode();

            if (protocolTreeNode != null)
            {
                this.protocolPresenter.setSelectedProtocolRow(protocolTreeNode.getProtocolRow());
                this.stepPResenter.setSelectedStepRow(null);
            }
            else if (stepTreeNode != null)
            {
                this.stepPResenter.setSelectedStepRow(stepTreeNode.getStepRow());
                this.protocolPresenter.setSelectedProtocolRow(null);
            }
        }
    }
}
