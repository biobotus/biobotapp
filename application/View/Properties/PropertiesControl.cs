using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Model.Data;
using BioBotApp.Presenter.Properties;

namespace BioBotApp.View.Properties
{
    public partial class PropertiesControl : UserControl, IPropertiesView
    {

        PropertiesPresenter presenter;
        public PropertiesControl()
        {
            InitializeComponent();
            this.presenter = new PropertiesPresenter(this);
            
        }

        public void setBioBotDataset(BioBotDataSets dataset)
        {
            this.dsBioBot = dataset;
            this.bsObjectProperty.DataMember = "bbt_object_property";
            this.bsObjectProperty.DataSource = this.dsBioBot;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int fkObjectType = Convert.ToInt16(txtObjectType.Text);
            int fkProperties = Convert.ToInt16(txtProperties.Text);
            this.presenter.addObjectPropertiesValueRow(fkObjectType, fkProperties, txtValue.Text);
        }
    }
}
