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
        public DataRow PropertyTypeCurrentRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_property_typeRow row;
                DataRowView RowView = bbtpropertytypeBindingSource.Current as DataRowView;
                row = RowView.Row as Model.Data.BioBotDataSets.bbt_property_typeRow;
                return row;
            }
        }
        public DataTable PropertyTypeDataTable
        {
            set
            {
                dataGridView1.DataSource = bbtpropertytypeBindingSource.DataSource;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

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
