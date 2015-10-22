using BioBotApp.Model.ModulePluginManager;
using BioBotApp.View.ModulePluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.ModulePluginManager
{
    class LoadedModulePresenter
    {
        private PluginManager pluginManager;
        private IModulePluginLoadedView view;

        public LoadedModulePresenter(IModulePluginLoadedView loadedModuleView)
        {
            pluginManager = PluginManager.Instance;
            view = loadedModuleView;
            view.LoadLoadedPlugin(pluginManager.GetLoadedPluginList());
        }

        public void LoadModules()
        {
            pluginManager.ImportPlugins();
            view.LoadLoadedPlugin(pluginManager.GetLoadedPluginList());
        }
    }
}
