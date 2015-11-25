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
            this.PropertyBindingSource.DataSource = bioBotDataSets;

        }
        public void onPropertyTypeCurrentChange(Model.Data.BioBotDataSets.bbt_property_typeRow row)
        {

        }

    }
}
