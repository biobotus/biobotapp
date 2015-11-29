using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Services;
using BioBotApp.Model.Data.Services;
using BioBotApp.View.Utils;

namespace BioBotApp.View.Services
{
    public partial class PropertyServiceView : DatasetViewControl, IPropertyServiceView
    {

        int pk_id;
        int fk_property_type = 0;
        
        PropertyServicesPresenter PropertyPresenter;

        public PropertyServiceView()
        {
            InitializeComponent();
            PropertyPresenter = new PropertyServicesPresenter(this);
            this.bioBotDataSets = Model.Data.DBManager.Instance.projectDataset;
            this.bindingSource1.DataSource = bioBotDataSets;
            //this.PropertyBindingSource.DataSource = bioBotDataSets;

        }
        public Model.Data.BioBotDataSets.bbt_propertyRow PropertyCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_propertyRow row;
                DataRowView RowView = bindingSource1.Current as DataRowView;
                if(RowView != null)
                {
                    row = RowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;
                }
                else
                {
                    row = null;
                }
                return row;
            }
        }

        public void onPropertyTypeCurrentChange(int pk_id)
        {
            this.bindingSource1.Filter = "fk_property_type =" + pk_id;
            fk_property_type = pk_id;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_propertyRow row;
            DataRowView rowView = bindingSource1.Current as DataRowView;

            if(rowView == null)
            {
                pk_id = 0;
            }
            else
            {
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;
                pk_id = row.pk_id;
            }
            
            PropertyPresenter.OnPropertyChanged(pk_id, e);
        }
        private void addProperty(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add Property ", "Add new property");
            NamedInputTextBox description = new NamedInputTextBox("Property Name: ");
            dialog.addControl(description);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PropertyPresenter.addProperty(description.getInputTextValue(), fk_property_type);
            }
        }
        private void deleteProperty(object sender, EventArgs e)
        {
            if (PropertyCurrentRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Delete Property", "Delete Property");
                DialogResult result = MessageBox.Show("Delete : " + PropertyCurrentRow.description + " ?", "Delete Step ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.No))
                {
                    return;
                }


                PropertyPresenter.deleteProperty(PropertyCurrentRow);

            }
        }
        private void modifyProperty(object sender, EventArgs e)
        {
            if(PropertyCurrentRow == null)
            {
                return;
            }

            AbstractDialog dialog = new AbstractDialog("Modify Property", "Modify property");

            NamedInputTextBox description = new NamedInputTextBox("Property Type Name: ", PropertyCurrentRow.description);
            dialog.addControl(description);

            namedComboBox fk_property_type = new namedComboBox("Property Type");
            fk_property_type.getComboBox().DataSource = bioBotDataSets.bbt_property_type;
            fk_property_type.getComboBox().ValueMember = "pk_id";
            fk_property_type.getComboBox().DisplayMember = "description";
            fk_property_type.getComboBox().SelectedValue = PropertyCurrentRow.fk_property_type;
            dialog.addControl(fk_property_type);

            DialogResult result = dialog.ShowDialog();

            Model.Data.BioBotDataSets.bbt_property_typeRow PropertyTypeRow;
            DataRowView PropertyTypeCombo = fk_property_type.getComboBox().SelectedItem as DataRowView;
            PropertyTypeRow = PropertyTypeCombo.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;

            if (result == DialogResult.OK)
            {
                PropertyCurrentRow.description = description.getInputTextValue();
                PropertyCurrentRow.fk_property_type = PropertyTypeRow.pk_id;
                PropertyPresenter.modifyProperty(PropertyCurrentRow);
            }
        }
    }
}
