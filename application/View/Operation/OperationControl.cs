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
using BioBotApp.View.Utils;
using BioBotApp.Presenter.Operation;

namespace BioBotApp.View.Operation
{
    public partial class OperationControl : DatasetViewControl, IOperationView
    {
        OperationPresenter presenter;
        BioBotDataSets.bbt_operationRow row;
        
        public OperationControl()
        {
            InitializeComponent();
            this.presenter = new OperationPresenter(this);
            this.bsObject.DataSource = this.dataset;
            this.bsOperationReference.DataSource = this.dataset;
        }

        public void setOperation(BioBotDataSets.bbt_operationRow row)
        {
            if (row == null)
            {
                this.bsOperationReference.Filter = String.Empty;
                this.txtOperationValue.Text = String.Empty;
                this.row = null;
                return;
            }
            this.row = row;
            this.bsOperationReference.Filter = "fk_operation = " + row.pk_id;
            this.operationTypeControl1.setSelectedOperationType(row.bbt_operation_typeRow);
            this.txtOperationValue.Text = row.value;
        }

        public String getOperationValue()
        {
            if (txtOperationValue.Text == "") return null;
            return txtOperationValue.Text;
        }

        public BioBotDataSets.bbt_operation_typeRow getSeletedOperationType()
        {
            return operationTypeControl1.getSelectedOperationType();
        }

        public void addOperation(BioBotDataSets.bbt_operationRow row)
        {
            throw new NotImplementedException();
        }

        public void addOperationReference()
        {
            throw new NotImplementedException();
        }

        public void deleteOperation(int pkId)
        {
            
        }
        
        public void modifyOperation(BioBotDataSets.bbt_operationRow row)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BindingSource bsObjectFilter = new BindingSource(this.dataset, "bbt_object");
            AbstractDialog dialog = new AbstractDialog();
            namedComboBox comboBoxObject = new namedComboBox("Object: ");
            String filter = "";
            comboBoxObject.getComboBox().DataSource = bsObjectFilter;
            comboBoxObject.getComboBox().DisplayMember = "description";

            dialog.addControl(comboBoxObject);

            foreach(DataRowView view in bsOperationReference)
            {
                if(view.Row is BioBotDataSets.bbt_operation_referenceRow)
                {
                    BioBotDataSets.bbt_operation_referenceRow row = view.Row as BioBotDataSets.bbt_operation_referenceRow;
                    if (filter == "")
                    {
                        filter += "pk_id <> " + row.fk_object;
                    }
                    else
                    {
                        filter += " AND pk_id <> " + row.fk_object;
                    }
                }
            }
            bsObjectFilter.Filter = filter;

            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                if (this.row == null) return;
                
                if (!(comboBoxObject.getComboBox().SelectedValue is DataRowView)) return;
                DataRowView rowView = comboBoxObject.getComboBox().SelectedValue as DataRowView;
                if (!(rowView.Row is BioBotDataSets.bbt_objectRow)) return;
                BioBotDataSets.bbt_objectRow objectRow = rowView.Row as BioBotDataSets.bbt_objectRow;
                if (objectRow == null) return;
                this.presenter.addOperationReferenceRow(this.row.pk_id,objectRow.pk_id);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operation_referenceRow row = getSelectedOperationReferenceRow();
            if (row == null) return;
            this.presenter.removeOperationReferenceRow(row);
        }

        public BioBotDataSets.bbt_operation_referenceRow getSelectedOperationReferenceRow()
        {
            if (this.bsOperationReference == null) return null;
            if (this.bsOperationReference.Current == null) return null;
            if (!(this.bsOperationReference.Current is DataRowView)) return null;
            DataRowView rowView = this.bsOperationReference.Current as DataRowView;
            if (rowView.Row == null) return null;
            if (!(rowView.Row is BioBotDataSets.bbt_operation_referenceRow)) return null;
            return rowView.Row as BioBotDataSets.bbt_operation_referenceRow;
        }

        public void setSelectedStepRow(BioBotDataSets.bbt_stepRow row)
        {
        }

        public void setSelectedObjectTypeRow(BioBotDataSets.bbt_object_typeRow row)
        {
        }
    }
}
