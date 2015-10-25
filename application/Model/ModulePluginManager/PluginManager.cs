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

        /// <summary>
        /// Path to the xml storing the plugin's dll path list .
        /// </summary>
        private static string PathListXmlPath = ".\\PluginPathList.xml";

        /// <summary>
        /// Path to the xml where the plugin <-> module type pairing is store. 
        /// </summary>
        private static string PairingXmlPath = ".\\PluginPairingList";

        [ImportMany]
        private IEnumerable<Lazy<IModulePlugin,IModuleData>> plugins;

        /// <summary>
        /// List of path where are store the DLL containing the modules plugin.
        /// </summary>
        private List<string> pathList;

        /// <summary>
        /// Dictionnary associating a type of module (object_type description) and a plugin name (metadata).
        /// </summary>
        private Dictionary<string, string> pairingDict;

        /// <summary>
        ///  Instance of the pluginManager for the singleton implementation
        /// </summary>
        private static PluginManager instance;

        /// <summary>
        /// Private constructor load the path store into ./PluginPathList.xml file
        /// </summary>
        private PluginManager()
        {
            pathList = new List<string>();
            plugins = Enumerable.Empty<Lazy<IModulePlugin, IModuleData>>();
            LoadPathList();
            LoadPairingDictionary();
        }

        /// <summary>
        /// Singleton implementation, return a unique instance of the plugin manager
        /// </summary>
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

        /// <summary>
        /// Add a path to the pathList.
        /// </summary>
        /// <param name="path">the path to be add</param>
        private void AddPath(string path)
        {
            if (!pathList.Contains(path))
            {
                pathList.Add(path);
            }
        }

        /// <summary>
        /// Import plugins from the dll located into the path from the pathList and the plugin manager assambly
        /// </summary>
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

        /// <summary>
        /// Replace the path list with a new one.
        /// </summary>
        /// <param name="newPathList"> the new path where to look for plugins</param>
        public void UpdatePluginPathList(List<string> newPathList)
        {
            pathList = newPathList;
        }

        /// <summary>
        /// Accessor for the plugin search path list.
        /// </summary>
        /// <returns>the list use to search for plugins</returns>
        public List<string> GetPluginPathList()
        {
            return pathList;
        }

        /// <summary>
        ///  Return a list of the loaded plugins name.
        /// </summary>
        /// <returns>the list of plugin name</returns>
        public List<string> GetLoadedPluginList()
        {
            List<string> result = new List<string>();
            foreach (Lazy<IModulePlugin, IModuleData> plugin in plugins)
            {
                result.Add(plugin.Metadata.Name);
            }
            return result;
        }


        public List<TreeNode> GetPluginsConfTreeNode()
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

        /// <summary>
        /// Change the plugin search path list and save it to the file .\PluginPathList.xml.
        /// </summary>
        /// <param name="newPathList"> the new path list, to be save as xml</param>
        public void SavePathList(List<string> newPathList)
        {
            pathList = newPathList;
            var xEle = new XElement("PluginPathList", from path in newPathList
                                                      select new XElement("Path",
                                         new XAttribute("value", path)
                                       ));
            xEle.Save(PathListXmlPath);
        }

        /// <summary>
        /// Replace the current path list with the one store as xml on the file .\PluginPathList.xml.
        /// 
        /// </summary>
        public void LoadPathList()
        {
             if (File.Exists(PathListXmlPath))
            {
                pathList = new List<string>();
                XmlTextReader reader = new XmlTextReader(PathListXmlPath);
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
                reader.Close();
            }
           
        }

        public Dictionary<string,string> GetPairingDictionnary()
        {
            return pairingDict;
        }

        public void SavePairingDictionary(Dictionary<string,string> pairing)
        {
            pairingDict = pairing;
            var xEle = new XElement("PairingList", from pair in pairingDict
                                                      select new XElement("Pairing",
                                                        new XAttribute("moduleType", pair.Key),
                                                        new XAttribute("pluginName", pair.Value)
                                                      ));
            xEle.Save(PairingXmlPath);
        }

        public void LoadPairingDictionary()
        {
            if (File.Exists(PairingXmlPath))
            {
                pairingDict = new Dictionary<string, string>();
                XmlTextReader reader = new XmlTextReader(PairingXmlPath);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an element.
                            if (reader.Name == "Pairing")
                            {
                                string type = "";
                                string plugin = "";
                                while (reader.MoveToNextAttribute())
                                {
                                    if(reader.Name == "moduleType")
                                    {
                                        type = reader.Value;
                                    }
                                    if (reader.Name == "pluginName")
                                    {
                                        plugin = reader.Value;
                                    }
                                }
                                pairingDict.Add(type, plugin);
                            }
                            break;
                        default:
                            break;
                    }
                }
                reader.Close();
            }
        }
    }
}
