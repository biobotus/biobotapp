using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.ModulePluginManager
{
    public partial class ModulePluginPairView : UserControl, IModulePluginPairView 
    {
        private DataTable pluginList = new DataTable();
        private DataTable moduleTypeList = new DataTable();
        public ModulePluginPairView()
        {
            InitializeComponent();
            moduleTypeList.Columns.Add("Module type");

            pluginList.Columns.Add("Module plugin");

            pairView.DataSource = moduleTypeList;

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.HeaderText = "Select Data";
            cmb.Name = "cmb";
            cmb.DisplayMember = "Module plugin";
            cmb.DataSource = pluginList;
            pairView.Columns.Add(cmb);
        }

        public void LoadLoadedPluginList(List<string> newPluginList)
        {
            foreach(string plugin in newPluginList)
            {
                pluginList.Rows.Add(new object[] { plugin });
            }
        }

        public void LoadModuleNameListe(List<string> newModuleList)
        {
            foreach (string plugin in newModuleList)
            {
                moduleTypeList.Rows.Add(new object[] { plugin });
            }
        }
    }
}
