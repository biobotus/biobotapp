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
namespace TACDLL
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IModulePlugin))]
    [ExportMetadata("Name", "TacPlugin")]
    public class TacDll : IModulePlugin
    {
        private const int HARDWARE_FILTER_TAC = 0x70;
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
            CANMsg.ID = HARDWARE_FILTER_TAC;
            PCANCom.Instance.send(CANMsg);

            if (parsed_command.Length == 4)
            {
                switch (parsed_command[0])
                {
                    case "set_taget_temperature":
                        // 0X00 2 byte
                        CANMsg.DATA[2] = 0;
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
                        // 0X01 1 byte
                        CANMsg.DATA[2] = 0x01;
                        CANMsg.DATA[4] = ParsePercent(parsed_command[3]);
                        break;
                    case "set_fan_speed":
                        // 0x02 1 byte
                        CANMsg.DATA[2] = 0x02;
                        CANMsg.DATA[4] = ParsePercent(parsed_command[3]);
                        break;

                    default:
                        returnValue = "uknown command : " + command;
                        // raise error?
                        break;

                }
            }
            else if (parsed_command.Length == 3)
            {
                switch (parsed_command[0])
                {
                    case "start_calibration":
                        CANMsg.DATA[2] = 0x03;
                        break;
                    case "stop_calibration":
                        CANMsg.DATA[2] = 0x04;
                        break;
                    case "start_temparature_maintain":
                        CANMsg.DATA[2] = 0x05;
                        break;
                    case "stop_temparature_maintain":
                        CANMsg.DATA[2] = 0x06;
                        break;
                    case "enable_fan":
                        CANMsg.DATA[2] = 0x07;
                        break;
                    case "disable_fan":
                        CANMsg.DATA[2] = 0x08;
                        break;
                    case "enable_peltier":
                        CANMsg.DATA[2] = 0x09;
                        break;
                    case "disable_peltier":
                        CANMsg.DATA[2] = 0x0A;
                        break;
                    case "enable_agitator":
                        CANMsg.DATA[2] = 0x0B;
                        break;
                    case "disable_agitator":
                        CANMsg.DATA[2] = 0x0C;
                        break;
                    case "send_fan_speed":
                        CANMsg.DATA[2] = 0x0D;
                        break;
                    case "send_temperature":
                        CANMsg.DATA[2] = 0x0E;
                        break;
                    case "send_agitator_speed":
                        CANMsg.DATA[2] = 0x0F;
                        break;
                    case "send_turbidity":
                        CANMsg.DATA[2] = 0x10;
                        break;

                    default:
                        returnValue = "uknown command : " + command;
                        break;

                }
            }
            else
            {
                returnValue = "malform temperature command : " + command;
            }
            // Here we should send the packet
            if (returnValue == "")
            {
                CANQueue.Instance.add(CANMsg);
                CANQueue.Instance.executeFirst();
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
    }
}
