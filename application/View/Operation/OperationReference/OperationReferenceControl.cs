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

namespace BioBotApp.View.Operation.OperationReference
{
    public partial class OperationReferenceControl : DatasetViewControl, IOperationReferenceView
    {
        BioBotDataSets.bbt_operationRow operationRow;
        Presenter.Operation.OperationReference.OperationReferencePresenter presenter;
        public OperationReferenceControl()
        {
            InitializeComponent();
            presenter = new Presenter.Operation.OperationReference.OperationReferencePresenter(this);
            this.bioBotDataSets = dataset;
            this.bsOperation.DataSource = this.bioBotDataSets;
            this.bsObject.DataSource = this.bioBotDataSets;
            this.bsOperationReference.DataSource = this.bsOperation;
        }

        public void setSelectedOperation(BioBotDataSets.bbt_operationRow row)
        {
            int index = this.dataset.bbt_operation.Rows.IndexOf(row);
            if (index < 0)
            {
                this.bsOperation.Filter = "pk_id = -1";
                this.bsObject.Filter = "";
                return;
            }
            this.bsOperation.Filter = "pk_id = " + row.pk_id;
            operationRow = row;
           
            this.bsOperation.Position = index;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog();
            namedComboBox objectName = new namedComboBox("Object: ");
            objectName.getComboBox().DataSource = this.bsObject;
            objectName.getComboBox().DisplayMember = "description";
            objectName.getComboBox().ValueMember = "pk_id";
            dialog.addControl(objectName);
            String filter = "";
            foreach(DataRowView view in bsOperationReference)
            {
                BioBotDataSets.bbt_operation_referenceRow operation = view.Row as BioBotDataSets.bbt_operation_referenceRow;
                if(filter == "")
                {
                    filter = "pk_id <> " + operation.fk_object;
                }
                else
                {
                    filter += " AND pk_id <> " + operation.fk_object;
                }
            }
            this.bsObject.Filter = filter;
            DialogResult result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                
                int pkId = (int)objectName.getComboBox().SelectedValue;
                this.presenter.addOperationReference(operationRow.pk_id, pkId);
                this.bsObject.Filter = "";
            }
        }

        public Model.Data.BioBotDataSets.bbt_objectRow getSelectedObject(BindingSource bindingSource)
        {
            Model.Data.BioBotDataSets.bbt_objectRow operationTypeRow;
            if (bindingSource.Current == null) return null;
            DataRowView rowview = bindingSource.Current as DataRowView;
            if (rowview == null) return null;
            operationTypeRow = rowview.Row as Model.Data.BioBotDataSets.bbt_objectRow;
            return operationTypeRow;
        }

        public Model.Data.BioBotDataSets.bbt_operation_referenceRow getSelectedOperationReference()
        {
            Model.Data.BioBotDataSets.bbt_operation_referenceRow operationTypeRow;
            if (this.bsOperationReference.Current == null) return null;
            DataRowView rowview = bsOperationReference.Current as DataRowView;
            if (rowview == null) return null;
            operationTypeRow = rowview.Row as Model.Data.BioBotDataSets.bbt_operation_referenceRow;
            return operationTypeRow;
        }

        public Model.Data.BioBotDataSets.bbt_objectRow getSelectedObject()
        {
            return getSelectedObject(this.bsObject);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BioBotDataSets.bbt_operation_referenceRow operationReference = getSelectedOperationReference();
            if (operationReference == null) return;
            this.presenter.removeOperationReference(operationReference);
        }
    }
}
