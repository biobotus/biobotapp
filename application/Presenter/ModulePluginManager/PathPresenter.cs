using BioBotApp.Model.ModulePluginManager;
using BioBotApp.View.ModulePluginManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.ModulePluginManager
{
    class PathPresenter
    {
        private PluginManager pluginManager;
        private IModulePluginPathView view;

        public PathPresenter(IModulePluginPathView pathListView)
        {
            pluginManager = PluginManager.Instance;
            view = pathListView;
            view.LoadModulePluginPath(pluginManager.GetPluginPathList());
            
        }


        public void saveModulePluginPathList(List<string> pathList)
        {
            pluginManager.SavePathList(pathList);
        }

        public void loadModulePluginPathList()
        {
            pluginManager.LoadPathList();
            view.LoadModulePluginPath(pluginManager.GetPluginPathList());
        }
    }
}
