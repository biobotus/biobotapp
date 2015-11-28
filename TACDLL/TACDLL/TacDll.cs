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
using Peak.Can.Basic;
namespace TACDLL
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IModulePlugin))]
    [ExportMetadata("Name", "TacPlugin")]
    public class TacDll : IModulePlugin
    {

        public byte HARDWARE_FILTER_TAC = 0x70;
        Dictionary<string, int> byteCommandDict = new Dictionary<string, int>()
        {
            {"set_target_temperature", 0x00},
            {"set_agitator_speed", 0x01},
            {"set_fan_speed", 0x02},
            {"start_calibration", 0x03},
            {"stop_calibration", 0x04},
            {"start_temperature_maintain", 0x05},
            {"stop_temperature_maintain", 0x06},
            {"enable_fan", 0x07},
            {"disable_fan", 0x08},
            {"enable_agitator", 0x09},
            {"disable_agitator", 0x0a},
            {"enable_peltier", 0x0b},
            {"disable_peltier", 0x0c},
            {"send_fan_speed", 0x0d},
            {"send_temperature", 0x0e},
            {"send_agitator_speed", 0x0f},
            {"send_turbidity", 0x10}
        };

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


            TPCANMsg CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];
            //Device Id
            CANMsg.DATA[0] = moduleId;
            //SubModule Target 
            CANMsg.DATA[1] = subModuleId;
            // Instruction 
            //  CANMsg.DATA[2] =
            // Spare 
            CANMsg.DATA[3] = 0;
            // Data Byte  1 to 4
            //  CANMsg.DATA[4 to 7] = 
            CANMsg.ID = this.HARDWARE_FILTER_TAC;
            

            if (parsed_command.Length == 4)
            {
                switch (parsed_command[0])
                {
                    case "set_target_temperature":
                        float floatParam;
                        bool isParamFloat = float.TryParse(parsed_command[3], NumberStyles.Any, CultureInfo.InvariantCulture, out floatParam);
                        if(isParamFloat)
                        {
                            Int16 temp = (Int16)Math.Truncate(floatParam * 10);
                            
                            byte[] bytes = BitConverter.GetBytes(temp);
                            if (BitConverter.IsLittleEndian)
                            {
                                CANMsg.DATA[4] = bytes[1];
                                CANMsg.DATA[5] = bytes[0];
                            }
                            else
                            {
                                CANMsg.DATA[4] = bytes[0];
                                CANMsg.DATA[5] = bytes[1];
                            }
                        }
                        else
                        {
                            // error handling
                        }
                        break;
                    case "set_agitator_speed":
                        CANMsg.DATA[4] = ParsePercent(parsed_command[3]);
                        break;
                    case "set_fan_speed":
                        CANMsg.DATA[4] = ParsePercent(parsed_command[3]);
                        break;

                    default:
                        returnValue = "uknown command : " + command;
                        // raise error?
                        break;
                }
            }
            // Need to check if parsed_command[0] is in the dictionary
            // and if parsed_command.Length == 3 or 4
            // Here we should send the packet
            if (returnValue == "")
            {
                CANMsg.DATA[2] = (Byte)byteCommandDict[parsed_command[0]];
                PCANCom.Instance.send(CANMsg);
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
            return new TACDLL.OptionCtrl.TacDescription(this);
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

        public string BuildTacCmd(int moduleId, int subModuleId, string cmd, string value)
        {
            return cmd + " " + moduleId.ToString() + " " + subModuleId.ToString() + " " + value;
        }
    }
}
