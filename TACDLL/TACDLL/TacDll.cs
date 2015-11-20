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
                    if(parsed_command.Length == 2 )
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
            throw new NotImplementedException();
        }

        public TreeNode GetConfTreeNode()
        {
            throw new NotImplementedException();
        }

        public UserControl GetDescriptionControl()
        {
            throw new NotImplementedException();
        }

        public UserControl GetModuleDescriptionControl(int moduleId)
        {
            throw new NotImplementedException();
        }

        public void SetInChargeModule(List<string> moduleList)
        {
            throw new NotImplementedException();
        }
    }
}
