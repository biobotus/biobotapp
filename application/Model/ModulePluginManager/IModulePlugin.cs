using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.Model.ModulePluginManager
{
    public interface IModulePlugin
    {
        void ExecuteOperation();
        UserControl GetDescriptionControl();
        TreeNode GetConfTreeNode();
        Dictionary<string, UserControl> getConfAction();
    }

    public interface IModuleData
    {
        string Name { get; }
    }
}
