using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.Model.ModulePluginManager;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace DummyModule
{
    [Export(typeof(IModulePlugin))]
    [ExportMetadata("Name", "DummyModule")]
    public class Class1:IModulePlugin
    {
        public string Name
        {
            get { return "DummyModule"; }
        }
        public void ExecuteOperation()
        {

        }

        public UserControl GetDescriptionControl()
        {
            return new DummyControl();
        }
        public TreeNode GetConfTreeNode()
        {
            var t = new TreeNode("testTreeNodeMuchDummy");
            t.Name = "confDummyNode";
            return t;
        }
        public Dictionary<string, UserControl> getConfAction()
        {
            var d = new Dictionary<string, UserControl>();
            d.Add("confDummyNode", new DummyControl());
            return d;
        }
    }
}
