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

        public ObjectPropertyServiceView()
        {
            InitializeComponent();
            presenter = new ObjectPropertyPresenter(this);
            this.bioBotDataSets = dataset;
            this.bbtobjectpropertyBindingSource.DataSource = bioBotDataSets;
        }
        public void OnPropertyChanged(int pk_id)
        {
            this.bbtobjectpropertyBindingSource.Filter = "fk_properties_id =" + pk_id;
        }
    }
}
