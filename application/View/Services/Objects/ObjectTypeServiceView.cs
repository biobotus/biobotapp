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
using BioBotApp.View.Services.Objects;
using BioBotApp.Presenter.Services.Object;
namespace BioBotApp.View.Services
{
    public partial class ObjectTypeServiceView : DatasetViewControl, IObjectTypeServiceView
    {

        ObjectTypePresenter Presenter;

        public ObjectTypeServiceView()
        {
            InitializeComponent();
            Presenter = new ObjectTypePresenter(this);
            this.bioBotDataSets = dataset;
            this.bbtobjecttypeBindingSource.DataSource = bioBotDataSets;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            Model.Data.BioBotDataSets.bbt_object_typeRow row;
            DataRowView rowView = bbtobjecttypeBindingSource.Current as DataRowView;
            row = rowView.Row as Model.Data.BioBotDataSets.bbt_object_typeRow;

            Presenter.OnObjectTypeChanged(row.pk_id, e);


        }
    }
}
