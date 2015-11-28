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
        PropertyServicesPresenter PropertyPresenter;

        public PropertyServiceView()
        {
            InitializeComponent();
            PropertyPresenter = new PropertyServicesPresenter(this);
            this.bioBotDataSets = dataset;
            this.bindingSource1.DataSource = bioBotDataSets;
            //this.PropertyBindingSource.DataSource = bioBotDataSets;

        }
        public void onPropertyTypeCurrentChange(int pk_id)
        {
            this.bindingSource1.Filter = "fk_property_type =" + pk_id;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_propertyRow row;
            DataRowView rowView = bindingSource1.Current as DataRowView;
            row = rowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;

            PropertyPresenter.OnPropertyChanged(row.pk_id, e);
        }
    }
}
