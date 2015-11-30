using System;
using System.Collections.Generic;
using BioBotApp.Model.ModulePluginManager;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Peak.Can.Basic;
using BioBotApp.Utils.Communication.pcan;
using System.Globalization;
using System.Text;
using BioBotApp.Model.Data;
using TACDLL.Can;
namespace TACDLL
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IModulePlugin))]
    [ExportMetadata("Name", "TacPlugin")]
    public class TacDll : IModulePlugin
    {

        public static byte HARDWARE_FILTER_TAC = 0x70;
      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public string ExecuteCommand(string command)
        {
            string[] parsed_command = command.Split(' ');
            String returnValue = "";
            byte moduleId = 0;
            byte subModuleId = 0;

            // Parsing module id an sub-module id
            bool isModuleIdByte = byte.TryParse(parsed_command[1], NumberStyles.Any, CultureInfo.InvariantCulture, out moduleId);
            bool isSubModuleIdByte = byte.TryParse(parsed_command[2], NumberStyles.Any, CultureInfo.InvariantCulture, out subModuleId);

            // verify module id and subModule id validity
            if(isModuleIdByte)
            {
                // TODO verifier si le module possedant cette id est la et repondant
            }
            else
            {
                // error handling
            }

            // verify module id and subModule id validity
            if (!isSubModuleIdByte && (subModuleId > 0 || subModuleId < 3))
            {
                // error handling
            }
            

            if (parsed_command.Length == 4)
            {
                switch (parsed_command[0])
                {
                    case "set_target_temperature":
                        float floatParam;
                        bool isParamFloat = float.TryParse(parsed_command[3], NumberStyles.Any, CultureInfo.InvariantCulture, out floatParam);
                        if(isParamFloat)
                        {
                            UInt16 temp = (UInt16)Math.Truncate(floatParam * 10);
                            TAC2CAN.setTemperatureTarget(temp);
                        }
                        else
                        {
                            // error handling
                        }

                        break;
                    case "set_agitator_speed":
                        TAC2CAN.setAgitatorSpeed(ParsePercent(parsed_command[3]));
                        break;
                    case "set_fan_speed":
                        TAC2CAN.setFanSpeed(ParsePercent(parsed_command[3]));
                        break;

                    default:
                        returnValue = "uknown command : " + command;
                        // raise error?
                        break;
                }
            }
            else if(parsed_command.Length == 3)
            {
                switch (parsed_command[0])
                {
                    case "enable_agitator":
                        TAC2CAN.setAgitatorEnable(1);
                        break;
                    case "disable_agitator":
                        TAC2CAN.setAgitatorEnable(0);
                        break;
                    case "enable_fan":
                        TAC2CAN.setFanEnable(1);
                        break;
                    case "disable_fan":
                        TAC2CAN.setFanEnable(0);
                        break;
                    case "send_fan_speed":
                        TAC2CAN.getFanState();
                        break;
                    case "send_temperature":
                        TAC2CAN.getCurrentTemperature();
                        break;
                    case "send_agitator_speed":
                        TAC2CAN.getAgitatorState();
                        break;
                    case "send_turbidity":
                        TAC2CAN.getTurbidity();
                        break;
                    case "send_goal_temperature":
                        TAC2CAN.getTemperatureTargetValue();
                        break;
                    default:
                        returnValue = "uknown command : " + command;
                        // raise error?
                        break;
                }
            }

            return returnValue;
        }

        public Dictionary<string, UserControl> getConfAction()
        {
            var d = new Dictionary<string, UserControl>();
            d.Add("tacPluginRoot", new OptionCtrl.TacPluginDescription());
            // Need to be linked to the db here change the null null
            d.Add("tacPluginDoConfiguration", new OptionCtrl.optionTacCalibration(null, null, this));
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
            return new TACDLL.OptionCtrl.TacDescription(this, moduleId);
        }

        public void SetInChargeModule(List<string> moduleList)
        {
            throw new NotImplementedException();
        }

        public void SetDataSet(BioBotDataSets dataset)
        {
        }

        private byte ParsePercent(string stringValue)
        {
            byte result = 0;
            bool isStringByte = byte.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
            if(!isStringByte && result>0)
            {
                // raise error
            }
            return result;
        }

        public static string BuildTacCmd(int moduleId, int subModuleId, string cmd, string value)
        {
            string command = cmd + " " + moduleId.ToString() + " " + subModuleId.ToString();
            if (value != "")
            {
                command += " " + value;
            }
            return command; 
        }
    }
}
