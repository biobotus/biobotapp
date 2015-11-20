using System;
using System.Collections.Generic;
using BioBotApp.Model.ModulePluginManager;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace TACDLL
{
    [Export(typeof(IModulePlugin))]
    [ExportMetadata("Name", "TacPlugin")]
    public class TacDll : IModulePlugin
    {
        public string ExecuteCommand(string command)
        {
            string[] parsed_command = command.Split(' ');
            String returnValue = "";
            switch(parsed_command[0])
            {
                case "temperature":
                    // we verify here that we have a well formated command for temperature
                    if(parsed_command.Length == 3)
                    {
                        float goalTemp = float.Parse(parsed_command[1],
                                        System.Globalization.CultureInfo.InvariantCulture);
                        // here send the temperature to the tac throught the communication
                    }
                    else
                    {
                        returnValue = "malform temperature command : " + command;
                    }
                    break;
                case "ventilation":
                    if (parsed_command.Length == 3)
                    {
                        float goalTemp = float.Parse(parsed_command[1],
                                        System.Globalization.CultureInfo.InvariantCulture);
                        // here send the temperature to the tac throught the communication
                    }
                    else
                    {
                        returnValue = "malform temperature command : " + command;
                    }
                    break;
                case "agitation":
                    if (parsed_command.Length == 3)
                    {
                        float goalTemp = float.Parse(parsed_command[1],
                                        System.Globalization.CultureInfo.InvariantCulture);
                        // here send the temperature to the tac throught the communication
                    }
                    else
                    {
                        returnValue = "malform temperature command : " + command;
                    }
                    break;
                default:
                    returnValue = "uknown command : " + command;
                    break;
                
            }
            return returnValue;
        }

        public Dictionary<string, UserControl> getConfAction()
        {
            var d = new Dictionary<string, UserControl>();
            d.Add("tacPluginRoot", new OptionCtrl.TacPluginDescription());
            d.Add("tacPluginDoConfiguration", new OptionCtrl.optionTacCalibration());
            return d;
        }

        public TreeNode GetConfTreeNode()
        {
            var root = new TreeNode("Tac modules");
            root.Name = "tacPluginRoot";

            var doCalibration = new TreeNode("Optical density calibration");
            doCalibration.Name = "tacPluginDoConfiguration";

            root.Nodes.Add(doCalibration);
            return root;
        }

        public UserControl GetDescriptionControl()
        {
            return new TACDLL.OptionCtrl.TacPluginDescription(); ;
        }

        public UserControl GetModuleDescriptionControl(int moduleId)
        {
            return new TACDLL.OptionCtrl.TacDescription();
        }

        public void SetInChargeModule(List<string> moduleList)
        {
            throw new NotImplementedException();
        }
    }
}
