using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Presenter.ModulePluginManager;

namespace BioBotApp.View.ModulePluginManager
{
    public partial class ModulePluginPairView : UserControl, IModulePluginPairView 
    {
        /// <summary>
        /// List of loaded module serving as option for combobox column
        /// </summary>
        private DataTable pluginList = new DataTable();
        private DataTable moduleTypeList = new DataTable();

        ModulePluginPairPresenter presenter;

        public ModulePluginPairView()
        {
            InitializeComponent();
            
            moduleTypeList.Columns.Add("Module type");

            pluginList.Columns.Add("Module plugin");

            pairView.DataSource = moduleTypeList;

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.Name = "Module plugin";
            cmb.HeaderText = "Select Data";
            cmb.DisplayMember = "Module plugin";
            cmb.DataSource = pluginList;
            pairView.Columns.Insert(1,cmb);

            presenter = new ModulePluginPairPresenter(this);
            presenter.LoadPairing();
        }

        public void LoadLoadedPluginList(List<string> newPluginList)
        {
            pluginList.Clear();
            foreach (string plugin in newPluginList)
            {
                pluginList.Rows.Add(new object[] { plugin });
            }
        }

        public void LoadModuleTypeListe(List<string> newModuleList)
        {
            moduleTypeList.Clear();
            foreach (string plugin in newModuleList)
            {
                moduleTypeList.Rows.Add(new object[] { plugin });
            }
        }

        public void FillPairing(Dictionary<string, string> pairingDict)
        {
            foreach (DataGridViewRow row in pairView.Rows)
            {
                
                string moduleType = (String)pairView["Module type", row.Index].Value;
                string pluginName = pairingDict[moduleType];
                bool isPluginLoaded = pluginList.AsEnumerable().Any(pluginRow => pluginName == pluginRow.Field<String>("Module plugin"));
                if (isPluginLoaded)
                {

                    DataGridViewComboBoxCell pluginCell = (DataGridViewComboBoxCell)pairView["Module plugin", row.Index];
                    pluginCell.Value = pluginName;
                    
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> moduleTypePluginPairing = new Dictionary<string, string>();
            foreach(DataGridViewRow row in pairView.Rows)
            {
                string moduleType = (string)row.Cells[1].Value;
                string pluginName = (string)row.Cells[0].Value;
                if (moduleType == null)
                {
                    moduleType = "";
                }
                if (pluginName == null)
                {
                    pluginName = "";
                }
                moduleTypePluginPairing.Add(moduleType, pluginName);
            }
            presenter.SavePairing(moduleTypePluginPairing);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            presenter.LoadPairing();
        }

    }
}
