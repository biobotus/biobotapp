using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.Services.Object;
using BioBotApp.View.Utils;
using BioBotApp.View.Services.Objects;

namespace BioBotApp.View.Services
{
    public partial class ObjectServiceView : DatasetViewControl, IObjectServiceView
    {
        ObjectPresenter presenter;

        public ObjectServiceView()
        {
            InitializeComponent();
            presenter = new ObjectPresenter(this);
            this.bioBotDataSets = dataset;
            this.bindingSource1.DataSource = bioBotDataSets;
        }
        public void OnObjectTypeChange(int pk_id)
        {
            this.bindingSource1.Filter = "fk_object_type =" + pk_id;
        }
    }
}
