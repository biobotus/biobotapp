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
        public ModulePluginManagerTest()
        {
            InitializeComponent();
            List<string> test = new List<string>{ "test1", "test2", "test3" };
            pluginPathControl1.loadModulePluginPath(test);
        }
    }
}
