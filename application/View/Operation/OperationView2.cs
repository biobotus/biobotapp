using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.View.Utils;
using BioBotApp.Model.Data;
using BioBotApp.Presenter.Step;
using BioBotApp.View.Operation;
using BioBotApp.Presenter.Operation;

namespace BioBotApp.View.Step
{
    public partial class OperationControl2 : DatasetViewControl, IOperationView
    {
        private OperationPresenter presenter;
        private BioBotDataSets.bbt_stepRow stepRow;
        private BioBotDataSets.bbt_object_typeRow objectTypeRow;
        public OperationControl2()
        {
            InitializeComponent();
            presenter = new OperationPresenter(this);
            this.bioBotDataSet = this.dataset;

            this.bsStep.DataSource = this.bioBotDataSet;
            this.bsOperation.DataSource = this.bsStepOperation;
            this.bsStepOperation.DataSource = this.bsStep;
            this.bsObjectType.DataSource = this.bioBotDataSet;
            this.bsOperationType.DataSource = this.bioBotDataSet;
            this.bsObjectTypeOperationType.DataSource = this.bsObjectType;
            this.bsStep.Filter = "pk_id = -1";
        }

        public void setSelectedStepRow(BioBotDataSets.bbt_stepRow row)
        {
            int index = this.dataset.bbt_step.Rows.IndexOf(row);
            if (index < 0)
            {
                this.bsStep.Filter = "pk_id = -1";
                return;
            }
            this.bsStep.Filter = "pk_id = " + row.pk_id;
            stepRow = row;
            this.bsStep.Position = index;
        }

        public void setSelectedObjectTypeRow(BioBotDataSets.bbt_object_typeRow row)
        {
            int index = this.dataset.bbt_object_type.Rows.IndexOf(row);
            if (index < 0)
            {
                this.bsObjectType.Filter = "pk_id = -1";
                return;
            }
            this.bsObjectType.Filter = String.Empty;
            objectTypeRow = row;
            this.bsObjectType.Position = index;
        }

        public BioBotDataSets.bbt_operationRow getSelectedOperationRow()
        {
            return getSelectedOperationRow(this.bsOperation);
        }

        public BioBotDataSets.bbt_operationRow getSelectedOperationRow(BindingSource bindingSource)
        {
            if (bindingSource == null) return null;
            if (bindingSource.Current == null) return null;
            if (!(bindingSource.Current is DataRowView)) return null;
            DataRowView rowView = bindingSource.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_operationRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_operationRow;
        }

        public BioBotDataSets.bbt_operation_typeRow getSelectedOperationTypeRow(BindingSource bindingSource)
        {
            if (bindingSource == null) return null;
            if (bindingSource.Current == null) return null;
            if (!(bindingSource.Current is DataRowView)) return null;
            DataRowView rowView = bindingSource.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_operation_typeRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_operation_typeRow;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow stepRow = getSelectedOperationRow();
            if (stepRow == null) return;
            if (stepRow.index > this.bsStep.Count) return;
            foreach (DataRowView rowView in bsStep)
            {
                if (rowView.Row is BioBotDataSets.bbt_stepRow)
                {
                    BioBotDataSets.bbt_operationRow row = rowView.Row as BioBotDataSets.bbt_operationRow;
                    if (row.index == stepRow.index - 1)
                    {
                        row.index++;
                        stepRow.index--;
                        this.presenter.modifyOperationRow(row);
                        this.presenter.modifyOperationRow(stepRow);
                        break;
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow stepRow = getSelectedOperationRow();
            if (stepRow == null) return;
            if (stepRow.index > this.bsStep.Count) return;
            foreach (DataRowView rowView in bsStep)
            {
                if (rowView.Row is BioBotDataSets.bbt_stepRow)
                {
                    BioBotDataSets.bbt_operationRow row = rowView.Row as BioBotDataSets.bbt_operationRow;
                    if (row.index == stepRow.index + 1)
                    {
                        row.index--;
                        stepRow.index++;
                        this.presenter.modifyOperationRow(row);
                        this.presenter.modifyOperationRow(stepRow);
                        break;
                    }
                }
            }
        }

        private void StepView2_Load(object sender, EventArgs e)
        {
            try
            {
                dgvOperations.Sort(indexColumn, ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //exception used to eliminate designer error : 
                //DataGridView control cannot be sorted if it is bound to an IBindingList that does not support sorting. 
            }

        }

        private void dgvOperation_EnabledChanged(object sender, EventArgs e)
        {
            try
            {
                dgvOperations.Sort(indexColumn, ListSortDirection.Ascending);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //exception used to eliminate designer error : 
                //DataGridView control cannot be sorted if it is bound to an IBindingList that does not support sorting. 
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow row = getSelectedOperationRow();
            if (row == null) return;
            this.presenter.deleteOperationRow(row);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow row = getSelectedOperationRow();
            if (row == null) return;
            AbstractDialog dialog = new AbstractDialog("Modify step", "Modify step");

            /*
            dialog.addControl(control);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                String description = control.getDescription();
                if (description == null) return;
                int fkObjectId = control.getSelectedObjectRow().pk_id;
                row.description = description;
                row.fk_object = fkObjectId;
                this.presenter.modifyStepRow(row);
                //protocolRow.description = input.getInputTextValue();
                //this.presenter.modifyProtocolRow(protocolRow);
            }
            */
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (objectTypeRow == null) return;
            AbstractDialog dialog = new AbstractDialog();
            NamedInputTextBox valueInput = new NamedInputTextBox("Value: ");
            Operation.OperationType.OperationTypeControl operationTypeControl = new Operation.OperationType.OperationTypeControl(objectTypeRow);

            dialog.addControl(operationTypeControl);
            dialog.addControl(valueInput);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                BioBotDataSets.bbt_operation_typeRow operationType = operationTypeControl.getSelectedOperationType();
                String value = valueInput.getInputTextValue();

                if (value == null) return;
                if (operationType == null) return;
                if (this.stepRow == null) return;
                int index = stepRow.Getbbt_operationRows().Length + 1;
                if (index < 0) return;
                this.presenter.addOperationRow(operationType, stepRow, index, value);
            }
        }

        private void bsOperation_ListChanged(object sender, ListChangedEventArgs e)
        {
            Boolean enableControl = !(dgvOperations.Rows.GetRowCount(DataGridViewElementStates.Visible) == 0);
            btnDelete.Enabled = enableControl;
            btnDown.Enabled = enableControl;
            btnEdit.Enabled = enableControl;
            btnUp.Enabled = enableControl;
            btnDown.Enabled = enableControl;
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow operationRow = getSelectedOperationRow();
            if (operationRow == null) return;
            AbstractDialog dialog = new AbstractDialog();
            namedComboBox operationTypeInput = new namedComboBox("Operation type: ");
            NamedInputTextBox valueInput = new NamedInputTextBox("Value: ", operationRow.value);
            operationTypeInput.getComboBox().DataSource = this.bsOperationType;
            operationTypeInput.getComboBox().DisplayMember = "description";
            operationTypeInput.getComboBox().ValueMember = "pk_id";
            operationTypeInput.getComboBox().SelectedValue = operationRow.fk_operation_type;
            dialog.addControl(operationTypeInput);
            dialog.addControl(valueInput);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                BioBotDataSets.bbt_operation_typeRow operationType = getSelectedOperationTypeRow(operationTypeInput.getComboBox().DataSource as BindingSource);
                String value = valueInput.getInputTextValue();

                if (value == null) return;
                if (operationType == null) return;
                operationRow.value = value;
                operationRow.fk_operation_type = operationType.pk_id;

                this.presenter.modifyOperationRow(operationRow);
            }
        }

        private void dgvOperations_SelectionChanged(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow row = getSelectedOperationRow();
            if (row == null) return;
            this.presenter.setSelectedOperationRow(row);
        }
    }
}
