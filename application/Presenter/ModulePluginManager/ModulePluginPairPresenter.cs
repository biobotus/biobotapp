using BioBotApp.Model.Data;
using BioBotApp.Model.ModulePluginManager;
using BioBotApp.View.ModulePluginManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.ModulePluginManager
{
    /// <summary>
    /// Presenter for the view displaying the pairing between module type and the 
    /// </summary>
    class ModulePluginPairPresenter
    {
        private PluginManager pluginManager;
        private DBManager dataBaseManager;
        private IModulePluginPairView view;

        public ModulePluginPairPresenter(IModulePluginPairView modulePairView)
        {
            view = modulePairView;
            dataBaseManager = DBManager.Instance;
            pluginManager = PluginManager.Instance;

            var moduleTypeList = dataBaseManager.projectDataset.bbt_object_type.AsEnumerable().Select(r => r.Field<string>("description")).ToList();
            view.LoadModuleTypeListe(moduleTypeList);

            view.LoadLoadedPluginList(pluginManager.GetLoadedPluginList());
        }

        public void SavePairing(Dictionary<string,string> pairingDict)
        {
            pluginManager.SavePairingDictionary(pairingDict);
        }

        public void LoadPairing()
        {
            pluginManager.LoadPairingDictionary();
            view.FillPairing(pluginManager.GetPairingDictionnary());
        }
    }
}
