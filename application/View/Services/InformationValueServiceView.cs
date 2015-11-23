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
using BioBotApp.Controls.Option.Options;

namespace BioBotApp.View.Services
{
    public partial class InformationValueServiceView : UserControl, IInformationValueServiceView
    {
        private InformationValueServicesPresenter presenter = null;


        public InformationValueServiceView()
        {
            InitializeComponent();
            presenter = new InformationValueServicesPresenter(this);
            //Model.Data.BioBotDataSets dsBiobotDataSets;
            //this.bbtinformationvalueBindingSource.DataSource = dsBiobotDataSets;            
        }

        /* 
        Variable containing passing information 
        */

        public DataGridView InformationValueDataTable
        {
            set
            {
                this.dataGridView1.DataSource = bbtinformationvalueBindingSource;
            }
        }

        public int InformationValuePrimaryKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_information_valueRow row;
                DataRowView rowView = bbtinformationvalueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_information_valueRow;
                return row.pk_id;
            }
        }
        public DataRow InformationValueRow
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_information_valueRow row;
                DataRowView rowView = bbtinformationvalueBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_information_valueRow;
                return row;
            }
        }
        public int PropertyForeignKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_propertyRow row;
                DataRowView rowView = bbtpropertyBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;
                return row.pk_id;
            }
        }
        public int ObjectForeignKey
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_objectRow row;
                DataRowView rowView = bbtobjectBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
                return row.pk_id;
            }
        }
        public string PropertyDescription
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_propertyRow row;
                DataRowView rowView = bbtpropertyBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_propertyRow;
                return row.description;
            }
        }
        public string ObjectDescription
        {
            get
            {
                Model.Data.BioBotDataSets.bbt_objectRow row;
                DataRowView rowView = bbtobjectBindingSource.Current as DataRowView;
                row = rowView.Row as Model.Data.BioBotDataSets.bbt_objectRow;
                return row.description;
            }
        }

        /*
        Fonction triggered by the button 
        */

        private void Add_Click(object sender, EventArgs e)
        {
            /*Abstract Dialog*/
            //abstractDialog dialog = new abstractDialog("New Information Value","Add Information Value");
            //namedInputTextBox InformationValueText = new namedInputTextBox("Information value:");
            //namedComboBox InformationValueFkCombo = new namedComboBox();
            /*Model fonction*/
            //presenter.AddInformationRow();
        }
        private void Modify_Click(object sender, EventArgs e)
        {
           
        }
        private void Delete_Click(object sender, EventArgs e)
        {

        }
                
    }
}
