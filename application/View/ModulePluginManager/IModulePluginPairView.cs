using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.ModulePluginManager
{
    interface IModulePluginPairView
    {
        void LoadLoadedPluginList(List<string> pluginList);
        void LoadModuleNameListe(List<string> pluginList);
    }
}
