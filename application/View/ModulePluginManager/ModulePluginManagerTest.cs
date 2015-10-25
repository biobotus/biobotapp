using BioBotApp.Model.ModulePluginManager;
using BioBotApp.Presenter.ModulePluginManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.ModulePluginManager
{
    public partial class ModulePluginManagerTest : Form
    {
        private Dictionary<string, UserControl> treeViewAction = new Dictionary<string, UserControl> ();

        public ModulePluginManagerTest()
        {
            PluginManager manager = PluginManager.Instance;
            manager.ImportPlugins();
            InitializeComponent();

            

            // this is sketchy only for demonstration purpose
            TreeNode t = treeView1.Nodes.Find("Outils", false)[0];
            t.Nodes.Add(new TreeNode("truc1"));
            List<TreeNode> nodeList = manager.GetPluginsConfTreeNode();
            foreach(TreeNode node in nodeList)
            {
                t.Nodes.Add(node);
            }

            Dictionary<string, UserControl> actions = manager.GetPluginConfTreeNodeAction();
            actions.ToList().ForEach(x => treeViewAction.Add(x.Key, x.Value));
            

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UserControl control = null;

            string nodeName = e.Node.Name;

            if(treeViewAction.Keys.Contains(nodeName))
            {
                control = treeViewAction[nodeName];
            }
            

            if (control!=null)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(control);
            }
            
        }
    }
}
