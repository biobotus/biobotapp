using System;
using System.Collections.Generic;
using BioBotApp.Model.ModulePluginManager;
using System.Windows.Forms;
using System.ComponentModel.Composition;
using Peak.Can.Basic;
using BioBotApp.Utils.Communication.pcan;
using System.Globalization;
using System.Text;

namespace TACDLL
{
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

            TPCANMsg CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];
            //Device Id
            CANMsg.DATA[0] = 1;
            //SubModule Target 
            CANMsg.DATA[1] = 1;
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
                        bool isParamFloat = float.TryParse(parsed_command[1], NumberStyles.Any, CultureInfo.InvariantCulture, out floatParam);
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
                            Console.WriteLine(parsed_command[1]);
                            Console.WriteLine(floatParam);
                            Console.WriteLine(temp);
                            Console.WriteLine(bytes[0]);
                            Console.WriteLine(bytes[1]);
                            StringBuilder hex = new StringBuilder(bytes.Length * 2);
                            foreach (byte b in bytes)
                                hex.AppendFormat("{0:x2}", b);
                            Console.WriteLine(hex);
                        }
                        else
                        {
                            // error handling
                        }
                        break;
                    case "set_agitator_speed":
                        // 0X01 1 byte
                        break;
                    case "set_fan_speed":
                        // 0x02 1 byte
                        break;

                    default:
                        returnValue = "uknown command : " + command;
                        break;

                }
            }
            else if (parsed_command.Length == 3)
            {
                switch (parsed_command[0])
                {
                    case "start_calibration":
                        // we verify here that we have a well formated command for temperature

                        break;
                    case "stop_calibration":

                        break;
                    case "start_temparature_maintain":

                        break;
                    case "stop_temparature_maintain":

                        break;
                    case "enable_fan":

                        break;
                    case "disable_fan":

                        break;
                    case "enable_peltier":

                        break;
                    case "disable_peltier":

                        break;
                    case "enable_agitator":

                        break;
                    case "disable_agitator":

                        break;
                    case "send_fan_speed":

                        break;
                    case "send_temperature":

                        break;
                    case "send_agitator_speed":

                        break;
                    case "send_turbidity":

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
