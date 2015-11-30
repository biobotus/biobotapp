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
using BioBotApp.Presenter.Operation.OperationTypeObjectType;

namespace BioBotApp.View.Operation.OperationTypeObjectType
{
    public partial class OperationTypeObjectTypeView : DatasetViewControl, IOperationTypeObjectTypeView
    {
        OperationTypeObjectTypePresenter presenter;



        public OperationTypeObjectTypeView()
        {
            InitializeComponent();
            presenter = new OperationTypeObjectTypePresenter(this);
            this.bioBotDataSets = dataset;
            this.bbtoperationtypeobjecttypeBindingSource.DataSource = bioBotDataSets;
        }
        public Model.Data.BioBotDataSets.bbt_operation_type_object_typeRow OperationTypeObjectTypeCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_operation_type_object_typeRow row;
                DataRowView RowView = bbtoperationtypeobjecttypeBindingSource.Current as DataRowView;
                if (RowView != null)
                {
                    row = RowView.Row as Model.Data.BioBotDataSets.bbt_operation_type_object_typeRow;
                }
                else
                {
                    row = null;
                }
                return row;
            }
        }

        private void AddOperationTypeObjectType(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add Operation Type - Object Type", "Add new Operation Type - Object Type");

            namedComboBox fk_operation_type = new namedComboBox("Operation Type:");
            fk_operation_type.getComboBox().DataSource = bioBotDataSets.bbt_operation_type;
            fk_operation_type.getComboBox().ValueMember = "pk_id";
            fk_operation_type.getComboBox().DisplayMember = "description";
            dialog.addControl(fk_operation_type);

            namedComboBox fk_object_type = new namedComboBox("Object Type:");
            fk_object_type.getComboBox().DataSource = bioBotDataSets.bbt_object_type;
            fk_object_type.getComboBox().ValueMember = "pk_id";
            fk_object_type.getComboBox().DisplayMember = "description";
            dialog.addControl(fk_object_type);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_operation_typeRow OperationTypeRow;
            DataRowView OperationTypeCombo = fk_operation_type.getComboBox().SelectedItem as DataRowView;
            OperationTypeRow = OperationTypeCombo.Row as Model.Data.BioBotDataSets.bbt_operation_typeRow;

            Model.Data.BioBotDataSets.bbt_object_typeRow ObjectTypeRow;
            DataRowView ObjectTypeCombo = fk_object_type.getComboBox().SelectedItem as DataRowView;
            ObjectTypeRow = ObjectTypeCombo.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            if (result == DialogResult.OK)
            {
                presenter.AddOperationTypeObjectType(ObjectTypeRow.pk_id,OperationTypeRow.pk_id);
            }

        }
        private void DeleteOperationTypeObjectType(object sender, EventArgs e)
        {
            if (OperationTypeObjectTypeCurrentRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Delete Reference", "Delete Reference");
                DialogResult result = MessageBox.Show("Delete this reference?", "Delete Reference ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.No))
                {
                    return;
                }
                presenter.DeleteOperationTypeObjectType(OperationTypeObjectTypeCurrentRow);
            }
        }
        private void ModifyOperationTypeObjectType(object sender, EventArgs e)
        {

            Model.Data.BioBotDataSets.bbt_operation_type_object_typeRow CurrentOperationTypeObjectType = OperationTypeObjectTypeCurrentRow;

            if (CurrentOperationTypeObjectType == null)
            {
                return;
            }

            AbstractDialog dialog = new AbstractDialog("Modify Property", "Modify property");

            namedComboBox fk_operation_type = new namedComboBox("Operation Type:");
            fk_operation_type.getComboBox().DataSource = bioBotDataSets.bbt_operation_type;
            fk_operation_type.getComboBox().ValueMember = "pk_id";
            fk_operation_type.getComboBox().DisplayMember = "description";
            fk_operation_type.getComboBox().SelectedValue = CurrentOperationTypeObjectType.fk_operation_type;
            dialog.addControl(fk_operation_type);

            namedComboBox fk_object_type = new namedComboBox("Object Type:");
            fk_object_type.getComboBox().DataSource = bioBotDataSets.bbt_object_type;
            fk_object_type.getComboBox().ValueMember = "pk_id";
            fk_object_type.getComboBox().DisplayMember = "description";
            fk_object_type.getComboBox().SelectedValue = CurrentOperationTypeObjectType.fk_object_type;
            dialog.addControl(fk_object_type);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_operation_typeRow OperationTypeRow;
            DataRowView OperationTypeCombo = fk_operation_type.getComboBox().SelectedItem as DataRowView;
            OperationTypeRow = OperationTypeCombo.Row as Model.Data.BioBotDataSets.bbt_operation_typeRow;

            Model.Data.BioBotDataSets.bbt_object_typeRow ObjectTypeRow;
            DataRowView ObjectTypeCombo = fk_object_type.getComboBox().SelectedItem as DataRowView;
            ObjectTypeRow = ObjectTypeCombo.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            if (result == DialogResult.OK)
            {
                CurrentOperationTypeObjectType.fk_object_type = ObjectTypeRow.pk_id;
                CurrentOperationTypeObjectType.fk_operation_type = OperationTypeRow.pk_id;

                presenter.ModifyOperationTypeObjectType(CurrentOperationTypeObjectType);
            }

        }
    }
}
