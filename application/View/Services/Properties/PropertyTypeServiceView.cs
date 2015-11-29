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
using BioBotApp.Presenter.Services;


namespace BioBotApp.View.Services
{
    public partial class PropertyTypeServiceView : DatasetViewControl, IpropertyTypeServiceView
    {
        PropertyTypeServicePresenter PropertyTypePresenter;

        public PropertyTypeServiceView()
        {
            InitializeComponent();
            PropertyTypePresenter = new PropertyTypeServicePresenter(this);
            this.bioBotDataSets = dataset;
            this.bbtpropertytypeBindingSource.DataSource = this.bioBotDataSets;
        }

        /*
        Get And Set Properties
        */
        public int PropertyTypePrimaryKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_property_typeRow row;
                DataRowView RowView = bbtpropertytypeBindingSource.Current as DataRowView;
                row = RowView.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;
                return row.pk_id;
            }
        }
        public string PropertyTypeDescription
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_property_typeRow row;
                DataRowView RowView = bbtpropertytypeBindingSource.Current as DataRowView;
                row = RowView.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;
                return row.description;
            }
        }
        public Model.Data.BioBotDataSets.bbt_property_typeRow PropertyTypeCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_property_typeRow row;
                DataRowView RowView = bbtpropertytypeBindingSource.Current as DataRowView;
                if(RowView == null)
                {
                    row = null;
                }
                else
                {
                    row = RowView.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;
                }
                
                return row;
            }
        }
        public Model.Data.BioBotDataSets.bbt_property_typeDataTable PropertyTypeDataTable
        {
            set
            {
                dataGridView1.DataSource = bbtpropertytypeBindingSource.DataSource;
            }
        }
        private void AddPropertyType(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog("Add Property Type","Add new property type");
            NamedInputTextBox description = new NamedInputTextBox("Property Type Name: ");
            dialog.addControl(description);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PropertyTypePresenter.AddPropertyType(description.getInputTextValue());
            }

            
        }
        private void DeletePropertyType(object sender, EventArgs e)
        {
            if(PropertyTypeCurrentRow != null)
            {
                AbstractDialog dialog = new AbstractDialog("Delete Property Type", "Delete Property Type");
                DialogResult result = MessageBox.Show("Delete : " + PropertyTypeCurrentRow.description + " ?", "Delete Step ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result.Equals(DialogResult.No))
                {
                    return;
                }


                PropertyTypePresenter.DeletePropertyType(PropertyTypeCurrentRow);
                 
            }
            
        }
        private void ModifyPropertyType(object sender, EventArgs e)
        {
            if(PropertyTypeCurrentRow == null)
            {
                return;
            }

            AbstractDialog dialog = new AbstractDialog("Modify Property Type", "Modify property type");
            NamedInputTextBox description = new NamedInputTextBox("Property Type Name: ", PropertyTypeCurrentRow.description);
            dialog.addControl(description);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                PropertyTypeCurrentRow.description = description.getInputTextValue();
                PropertyTypePresenter.ModifyPropertyType(PropertyTypeCurrentRow);
            }
            
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (bbtpropertytypeBindingSource.Current == null)
            {
                return;
            }

            Model.Data.BioBotDataSets.bbt_property_typeRow row;
            DataRowView rowView = bbtpropertytypeBindingSource.Current as DataRowView;
            row = rowView.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;


            PropertyTypePresenter.CurrentChanged(row.pk_id, e);
        }

        /*
        
        */
    }
}
