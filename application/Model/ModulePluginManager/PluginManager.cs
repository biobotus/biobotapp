using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows.Forms;
using System.Data.Linq;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace BioBotApp.Model.ModulePluginManager
{
    class PluginManager
    {
        private CompositionContainer _container;

        [ImportMany]
        private IEnumerable<Lazy<IModulePlugin,IModuleData>> plugins;

        private List<string> pathList;

        private static PluginManager instance;

        private PluginManager()
        {
            pathList = new List<string>();
            plugins = Enumerable.Empty<Lazy<IModulePlugin, IModuleData>>();
            LoadPathList();
        }

        public static PluginManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PluginManager();
             }
                return instance;
            }
        }

        private void AddPath(string path)
        {
            if (!pathList.Contains(path))
            {
                pathList.Add(path);
            }
        }

        public void ImportPlugins()
        {
            plugins = Enumerable.Empty<Lazy<IModulePlugin, IModuleData>>();
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
            foreach (Lazy<IModulePlugin, IModuleData> plugin in plugins)
            {
                result.Add(plugin.Metadata.Name);
            }
            return result;
        }

        public List<TreeNode> GetPluginConfTreeNode()
        {
            List<TreeNode> result = new List<TreeNode>();
            foreach (Lazy<IModulePlugin, IModuleData> plugin in plugins)
            {
                result.Add(plugin.Value.GetConfTreeNode());
            }
            return result;
        }

        public Dictionary<string,UserControl> GetPluginConfTreeNodeAction()
        {
            Dictionary<string, UserControl> result = new Dictionary < string, UserControl>();
            foreach (Lazy<IModulePlugin, IModuleData> plugin in plugins)
            {
                Dictionary<string, UserControl>  actions = plugin.Value.getConfAction();
                foreach (string key in actions.Keys)
                {
                    if(!result.Keys.Contains(key))
                    {
                        result[key] = actions[key];
                    }
                    else
                    {
                        throw new DuplicateKeyException(this, "Module node name already have an action associated");
                    }
                }
            }
            return result;
        }

        public void SavePathList(List<string> newPathList)
        {
            pathList = newPathList;
            var xEle = new XElement("PluginPathList", from path in newPathList
                                                      select new XElement("Path",
                                         new XAttribute("value", path)
                                       ));
            xEle.Save(".\\PluginPathList.xml");
        }

        public void LoadPathList()
        {
            if (File.Exists(".\\PluginPathList.xml"))
            {
                pathList = new List<string>();
                XmlTextReader reader = new XmlTextReader(".\\PluginPathList.xml");
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            if (reader.Name == "Path")
                            {
                                if (reader.MoveToNextAttribute())
                                {
                                    AddPath(reader.Value);
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
           
        }
    }
}
