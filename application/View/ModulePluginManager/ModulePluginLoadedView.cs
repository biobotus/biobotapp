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
    public partial class ModulePluginLoadedView : UserControl, IModulePluginLoadedView
    {
        private DataTable dtLoadedPlugin = new DataTable();
        public ModulePluginLoadedView()
        {
            InitializeComponent();
            dtLoadedPlugin.Columns.Add("pluginName");
            loadedModuleGridView.DataSource = dtLoadedPlugin;
        }

        public void LoadLoadedPlugin(List<string> pluginList)
        {
            foreach(string plugin in pluginList)
            {
                dtLoadedPlugin.Rows.Add(new object[] { plugin });
            }
        }
    }
}
