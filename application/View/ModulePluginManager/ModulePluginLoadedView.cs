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
    public partial class ModulePluginLoadedView : UserControl, IModulePluginLoadedView
    {
        private DataTable dtLoadedPlugin = new DataTable();
        private LoadedModulePresenter presenter;

        public ModulePluginLoadedView()
        {
            InitializeComponent();
            dtLoadedPlugin.Columns.Add("pluginName");
            loadedModuleGridView.DataSource = dtLoadedPlugin;
            presenter = new LoadedModulePresenter(this);
        }

        public void LoadLoadedPlugin(List<string> pluginList)
        {
            dtLoadedPlugin.Clear();
            foreach (string plugin in pluginList)
            {
                dtLoadedPlugin.Rows.Add(new object[] { plugin });
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            presenter.LoadModules();
        }
    }
}
