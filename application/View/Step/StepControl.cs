using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Step;
using BioBotApp.View.Utils;
using BioBotApp.Model.Data;
using BioBotApp.View.Operation;
using BioBotApp.Presenter.Operation;

namespace BioBotApp.View.Step
{
    public partial class StepControl : DatasetViewControl, IStepView, IOperationView
    {
        StepPresenter presenter;
        OperationPresenter operationPresenter;
        BioBotDataSets.bbt_stepRow stepRow;
        public StepControl()
        {
            InitializeComponent();
            presenter = new StepPresenter(this);
            operationPresenter = new OperationPresenter(this);

            this.bioBotDataSets = dataset;
            this.bsObject.DataSource = this.bioBotDataSets;
            this.bsOperationType.DataSource = this.bioBotDataSets;
            this.bsOperation.DataSource = this.bioBotDataSets;
        }

        public StepControl(BioBotDataSets.bbt_stepRow stepRow) : this()
        {
            setStepRow(stepRow);
        }

        public void setStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {
            if (stepRow == null)
            {
                this.stepRow = null;
                /*
                this.txtStepName.Text = "";
                this.cmbObject.SelectedValue = 0;
                */
                this.bsOperation.Filter = "fk_step = -1";

            }
            else
            {
                this.stepRow = stepRow;
                /*
                this.txtStepName.Text = stepRow.description;
                cmbObject.SelectedValue = stepRow.fk_object;
                */
                this.bsOperation.Filter = "fk_step = " + stepRow.pk_id;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add operation", "Add new operation");
            Operation.OperationControl control = new Operation.OperationControl();
            dialog.addControl(control);
            control.setOperation(null);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                BioBotDataSets.bbt_operation_typeRow operationTypeRow = control.getSeletedOperationType();
                String value = control.getOperationValue();
                if (operationTypeRow == null) return;
                if (value == null) return;
                if (value == String.Empty)
                {
                    MessageBox.Show("Error", "Description cannot be empty");
                }
                else
                {
                    this.operationPresenter.addOperationRow(operationTypeRow, stepRow, this.stepRow.Getbbt_operationRows().Length + 1, value);
                }
            }
        }

        public BioBotDataSets.bbt_objectRow getSelectedObjectRow()
        {
            BioBotDataSets.bbt_objectRow objectRow;
            if (this.bsObject.Current == null) return null;
            DataRowView rowView = this.bsObject.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_objectRow)) return null;
            objectRow = rowView.Row as BioBotDataSets.bbt_objectRow;
            return objectRow;
        }

        public String getDescription()
        {
            return "";
            /*
            if (txtStepName.Text == String.Empty) return null;
            return txtStepName.Text;
            */
        }

        public BioBotDataSets.bbt_operationRow getSelectedOperationRow()
        {
            if (this.bsOperation.Current == null) return null;
            DataRowView view = this.bsOperation.Current as DataRowView;
            if (view == null) return null;
            BioBotDataSets.bbt_operationRow row = view.Row as BioBotDataSets.bbt_operationRow;
            if (row == null) return null;
            return row;
        }

        public void addStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {
            /*
            AbstractDialog dialog = new AbstractDialog("Add operation", "Add new operation");
            Operation.OperationControl control = new Operation.OperationControl();
            dialog.addControl(control);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                BioBotDataSets.bbt_operation_typeRow operationTypeRow = control.getSeletedOperationType();
                this.operationPresenter.addOperationRow(control.getSeletedOperationType(), stepRow, this.stepRow.Getbbt_operationRows().Length + 1);
            }
            */
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add operation", "Add new operation");
            Operation.OperationControl control = new Operation.OperationControl();
            dialog.addControl(control);
            BioBotDataSets.bbt_operationRow row = getSelectedOperationRow();
            if (row == null) return;
            control.setOperation(row);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                BioBotDataSets.bbt_operation_typeRow operationType = control.getSeletedOperationType();
                String value = control.getOperationValue();
                if (operationType == null) return;
                if (value == null) return;
                row.fk_operation_type = operationType.pk_id;
                row.value = value;
                this.operationPresenter.modifyOperationRow(row);
            }

        }

        public void modifyStepRow(BioBotDataSets.bbt_stepRow stepRow)
        {
            if (this.stepRow == null) return;
            if (this.stepRow.pk_id == stepRow.pk_id)
            {
                setStepRow(stepRow);
            }
        }

        public void deleteStepRow(int rowId)
        {
            if (this.stepRow == null) return;
            if (this.stepRow.pk_id == rowId)
            {
                setStepRow(null);
            }
        }

        public void addOperation(BioBotDataSets.bbt_operationRow row)
        {

        }

        public void modifyOperation(BioBotDataSets.bbt_operationRow row)
        {

        }

        public void deleteOperation(int pkId)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow operationRow = getSelectedOperationRow();
            if (operationRow == null) return;
            if (operationRow.index <= 1) return;
            foreach (DataRowView rowView in bsOperation)
            {
                if (rowView.Row is BioBotDataSets.bbt_operationRow)
                {
                    BioBotDataSets.bbt_operationRow row = rowView.Row as BioBotDataSets.bbt_operationRow;
                    if (row.index == operationRow.index - 1)
                    {
                        row.index++;
                        operationRow.index--;
                        this.operationPresenter.modifyOperationRow(row);
                        this.operationPresenter.modifyOperationRow(operationRow);
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow operationRow = getSelectedOperationRow();
            if (operationRow == null) return;
            if (operationRow.index < this.bsOperation.Count) return;
            foreach (DataRowView rowView in bsOperation)
            {
                if (rowView.Row is BioBotDataSets.bbt_operationRow)
                {
                    BioBotDataSets.bbt_operationRow row = rowView.Row as BioBotDataSets.bbt_operationRow;
                    if (row.index == operationRow.index + 1)
                    {
                        row.index--;
                        operationRow.index++;
                        this.operationPresenter.modifyOperationRow(row);
                        this.operationPresenter.modifyOperationRow(operationRow);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operationRow operationRow = getSelectedOperationRow();
            if (operationRow == null) return;
            this.operationPresenter.deleteOperationRow(operationRow);
        }

        private void txtStepName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void StepControl_Load(object sender, EventArgs e)
        {
            dgvOperation.Sort(indexColumn, ListSortDirection.Ascending);
        }

        public void setSelectedProtocolRow(BioBotDataSets.bbt_protocolRow row)
        {
        }

        public void setSelectedStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }

        public void setSelectedObjectTypeRow(BioBotDataSets.bbt_object_typeRow row)
        {
        }

        public void deleteStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }
    }
}
