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
using BioBotApp.View.Services.References;
using BioBotApp.Presenter.Services.References;

namespace BioBotApp.View.Services
{
    public partial class ObjectPropertyServiceView : DatasetViewControl, IObjectPropertyServiceView
    {
        private ObjectPropertyPresenter presenter = null;
        int property_id=0;

        public ObjectPropertyServiceView()
        {
            InitializeComponent();
            presenter = new ObjectPropertyPresenter(this);
            this.bioBotDataSets = dataset;
            this.bbtobjectpropertyBindingSource.DataSource = bioBotDataSets;
        }

        public Model.Data.BioBotDataSets.bbt_object_propertyRow ObjectPropertyCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_object_propertyRow row;
                DataRowView RowView = bbtobjectpropertyBindingSource.Current as DataRowView;
                if (RowView != null)
                {
                    row = RowView.Row as Model.Data.BioBotDataSets.bbt_object_propertyRow;
                }
                else
                {
                    row = null;
                }
                return row;
            }
        }

        private void AddObjectProperty(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add Object Property", "Add new object property");

            namedComboBox fk_object_type = new namedComboBox("Object Type: ");
            fk_object_type.getComboBox().DataSource = bioBotDataSets.bbt_object_type;
            fk_object_type.getComboBox().ValueMember = "pk_id";
            fk_object_type.getComboBox().DisplayMember = "description";
            dialog.addControl(fk_object_type);

            NamedInputTextBox value = new NamedInputTextBox("Value: ");
            dialog.addControl(value);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_object_typeRow ObjectTypeRow;
            DataRowView ObjectTypeCombo = fk_object_type.getComboBox().SelectedItem as DataRowView;
            ObjectTypeRow = ObjectTypeCombo.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            if (result == DialogResult.OK)
            {
                presenter.AddObjectProperty(ObjectTypeRow.pk_id, property_id, value.getInputTextValue());
            }

        }
        private void DeleteObjectProperty(object sender, EventArgs e)
        {
            if (ObjectPropertyCurrentRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Delete Object Property", "Delete Object Property");
                DialogResult result = MessageBox.Show("Delete : " + ObjectPropertyCurrentRow.value + " ?", "Delete Object Property ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.No))
                {
                    return;
                }

                presenter.DeleteObjectProperty(ObjectPropertyCurrentRow);

            }
        }
        private void ModifyObjectProperty(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_object_propertyRow CurrentObjectProperty = ObjectPropertyCurrentRow;

            AbstractDialog dialog = new AbstractDialog("Modify Object Property", "Modify Object Property");

            namedComboBox fk_object_type = new namedComboBox("Object Type: ");
            fk_object_type.getComboBox().DataSource = bioBotDataSets.bbt_object_type;
            fk_object_type.getComboBox().ValueMember = "pk_id";
            fk_object_type.getComboBox().DisplayMember = "description";
            fk_object_type.getComboBox().SelectedValue = CurrentObjectProperty.fk_object_type_id;
            dialog.addControl(fk_object_type);

            namedComboBox fk_property_type = new namedComboBox("Property:");
            fk_property_type.getComboBox().DataSource = bioBotDataSets.bbt_property;
            fk_property_type.getComboBox().ValueMember = "pk_id";
            fk_property_type.getComboBox().DisplayMember = "description";
            fk_property_type.getComboBox().SelectedValue = CurrentObjectProperty.fk_properties_id;
            dialog.addControl(fk_property_type);

            NamedInputTextBox value = new NamedInputTextBox("Value: ", CurrentObjectProperty.value);
            dialog.addControl(value);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_propertyRow PropertyRow;
            DataRowView PropertyCombo = fk_property_type.getComboBox().SelectedItem as DataRowView;
            PropertyRow = PropertyCombo.Row as Model.Data.BioBotDataSets.bbt_propertyRow;

            Model.Data.BioBotDataSets.bbt_object_typeRow ObjectTypeRow;
            DataRowView ObjectTypeCombo = fk_object_type.getComboBox().SelectedItem as DataRowView;
            ObjectTypeRow = ObjectTypeCombo.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            if (result == DialogResult.OK)
            {
                CurrentObjectProperty.fk_object_type_id = ObjectTypeRow.pk_id;
                CurrentObjectProperty.fk_properties_id = PropertyRow.pk_id;
                CurrentObjectProperty.value = value.getInputTextValue();

                presenter.ModifyObjectProperty(CurrentObjectProperty);
            }

        }
        public void OnPropertyChanged(int pk_id)
        {
            this.bbtobjectpropertyBindingSource.Filter = "fk_properties_id =" + pk_id;
            property_id = pk_id;
        }
    }
}
