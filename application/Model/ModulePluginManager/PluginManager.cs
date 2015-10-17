using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace BioBotApp.Model.ModulePluginManager
{
    class PluginManager
    {
        private CompositionContainer _container;

        [ImportMany]
        private IEnumerable<IModulePlugin> plugins;

        private List<string> pathList;

        public PluginManager()
        {
            pathList = new List<string>();
            pathList.Add("C:\\Users\\maler\\Documents\\Visual Studio 2015\\Projects\\DummyModule\\DummyModule\\bin\\Debug");
        }

        public void ImportPlugins()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();
            //Adds all the parts found in the same assembly as the Program class
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(PluginManager).Assembly));

            foreach(string path in pathList)
            {
                catalog.Catalogs.Add(new DirectoryCatalog(path));
            }
            

            //Create the CompositionContainer with the parts in the catalog
            _container = new CompositionContainer(catalog);
            //Fill the imports of this object
            try
            {
                this._container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        public void UpdatePluginPathList(List<string> newPathList)
        {
            pathList = newPathList;
        }

        public List<string> GetPluginPathList()
        {
            return pathList;
        }

        public List<string> GetLoadedPluginList()
        {
            List<string> result = new List<string>();
            foreach (IModulePlugin plugin in plugins)
            {
                result.Add(plugin.Name);
            }
            return result;
        }
    }
}
