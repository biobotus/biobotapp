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
        /// <summary>
        /// Use to pass command to the module. Command can be a request for a 
        /// sensor value (getTemperature for exemple) or a parameter command (setTemperature).
        /// The command will be parse on the module's dll side. 
        /// </summary>
        /// <param name="command">The string representing the command and argument</param>
        /// <returns></returns>
        string ExecuteCommand(string command);

        /// <summary>
        /// Give access to a Controle giving a description of the modules represented
        /// Information displayed on this control is up to the Dll implementation.
        /// Pertinent information could be :
        ///     module list, possible input/output, input/output range.
        /// </summary>
        /// <returns>A user control describing the module type implemented</returns>
        UserControl GetDescriptionControl();

        /// <summary>
        /// Provide a control describing the state of a given module.
        /// </summary>
        /// <param name="moduleId">The module we want the information from</param>
        /// <returns>A user control describing the module state</returns>
        UserControl GetModuleDescriptionControl(int moduleId);

        /// <summary>
        /// Provide a TreeNode being the root of a tree presenting the 
        /// different configuration option for the modules
        /// </summary>
        /// <returns>The root of a configuration tree</returns>
        TreeNode GetConfTreeNode();

        /// <summary>
        /// Provide UserControl for each of the node present in the descendence of the confTreeNode
        /// </summary>
        /// <returns> A dictionary associating a string (node) and a user controle providing the means of configuration for various topic related with the modules</returns>
        Dictionary<string, UserControl> getConfAction();

        /// <summary>
        /// Provide the dll a list of the module they are in charge of.
        /// </summary>
        /// <param name="moduleList">The list of modules</param>
        void SetInChargeModule(List<String> moduleList);
    }

    public interface IModuleData
    {
        string Name { get; }
    }
}
