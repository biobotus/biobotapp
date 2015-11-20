using BioBotApp.Model.ModulePluginManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyModule2
{
    [Export(typeof(IModulePlugin))]
    [ExportMetadata("Name", "DummyModule2")]
    public class Class1 : IModulePlugin
    {
        public string Name
        {
            get { return "DummyModule2"; }
        }
        public void ExecuteOperation()
        {

        }

        public UserControl GetDescriptionControl()
        {
            return new DummyControlReturn();
        }
        public TreeNode GetConfTreeNode()
        {
            var t = new TreeNode("testTreeNodeMuchDummyReturn");
            t.Name = "toto";
            return t;
        }
        public Dictionary<string, UserControl> getConfAction()
        {
            var d = new Dictionary<string, UserControl>();
            d.Add("toto", new DummyControlReturn());
            return d;
        }
    }
}
