using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.Utils.Communication.pcan;
          
namespace TACDLL.OptionCtrl
{
    
    public partial class TacDescription : UserControl
    {
        TacDll tac;
        public TacDescription(TacDll tacDll)
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
            tac = tacDll;
        }

        public void SetCurrentTemperature(float temp)
        {
            this.currentTempLabel.Text = temp.ToString();
        }

        public void SetCurrentFan(int fanSpeed)
        {
            this.VentilationLabel.Text = fanSpeed.ToString();
        }

        public void SetCurrentTurbido(float turbido)
        {
            this.OpticalDensityLabel.Text = turbido.ToString();
        }

        public void SetCurrentAgitation(int agitationSpeed)
        {
            this.AgitationLabel.Text = agitationSpeed.ToString();
        }

        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if (e.CanMsg.DATA[0] == tac.HARDWARE_FILTER_TAC)
            {
                switch (e.CanMsg.DATA[2])
                {
                    // temp
                    case 0xE:
                        float curTemp = (float)((float)((e.CanMsg.DATA[5] << 8) + e.CanMsg.DATA[4]) / 10);
                        SetCurrentTemperature(curTemp);
                        break;
                    // fan speed
                    case 0xD:
                        SetCurrentFan(e.CanMsg.DATA[4]);
                        break;
                    // agit speed
                    case 0xF:
                        SetCurrentFan(e.CanMsg.DATA[4]);
                        break;
                    // turbidity
                    case 0x10:
                        break;

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tac.ExecuteCommand(tac.BuildTacCmd(1, 1, "send_fan_speed", ""));
            tac.ExecuteCommand(tac.BuildTacCmd(1, 1, "send_temperature", ""));
            tac.ExecuteCommand(tac.BuildTacCmd(1, 1, "send_agitator_speed", ""));
            tac.ExecuteCommand(tac.BuildTacCmd(1, 1, "send_turbidity", ""));
        }

    }
}
