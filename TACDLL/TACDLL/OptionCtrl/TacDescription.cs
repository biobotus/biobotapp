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
using TACDLL.Can;
namespace TACDLL.OptionCtrl
{
    
    public partial class TacDescription : UserControl
    {
        TacDll tac;
        int tacId;
        public TacDescription(TacDll tacDll, int target_tacId)
        {
            InitializeComponent();
            PCANCom.Instance.OnMessageReceived += CANMessageReceived;
            tac = tacDll;
            tacId = target_tacId;
        }

        public void SetGoalTemperature(float temp)
        {
            if (this.goalTempLabel.InvokeRequired)
            {
                this.goalTempLabel.BeginInvoke((MethodInvoker)delegate () { this.goalTempLabel.Text = temp.ToString() + " °C"; });
            }
            else
            {
                this.goalTempLabel.Text = temp.ToString();
            }
        }

        public void SetCurrentTemperature(float temp)
        {
            if (this.currentTempLabel.InvokeRequired)
            {
                this.currentTempLabel.BeginInvoke((MethodInvoker)delegate () { this.currentTempLabel.Text = temp.ToString() + " °C" ; });
            }
            else
            {
                this.currentTempLabel.Text = temp.ToString() + " °C";
            }
        }

        public void SetCurrentFan(int fanSpeed)
        {
            if (this.VentilationLabel.InvokeRequired)
            {
                this.VentilationLabel.BeginInvoke((MethodInvoker)delegate () { this.VentilationLabel.Text = fanSpeed.ToString(); });
            }
            else
            {
                this.VentilationLabel.Text = fanSpeed.ToString();
            }
        }

        public void SetCurrentTurbidity(float turbido)
        {
            if (this.OpticalDensityLabel.InvokeRequired)
            {
                this.OpticalDensityLabel.BeginInvoke((MethodInvoker)delegate () { this.OpticalDensityLabel.Text = turbido.ToString(); });
            }
            else
            {
                this.OpticalDensityLabel.Text = turbido.ToString();
            }
        }

        public void SetCurrentAgitation(int agitationSpeed)
        {
            if (this.AgitationLabel.InvokeRequired)
            {
                this.AgitationLabel.BeginInvoke((MethodInvoker)delegate () { this.AgitationLabel.Text = agitationSpeed.ToString(); });
            }
            else
            {
                this.AgitationLabel.Text = agitationSpeed.ToString();
            }
        }

        private void CANMessageReceived(object sender, PCANComEventArgs e)
        {
            if (e.CanMsg.DATA[0] == TacDll.HARDWARE_FILTER_TAC)
            {
                switch (e.CanMsg.DATA[2])
                {
                    case TACConstant.INST_GET_TARGET_TEMPERATURE:
                        SetGoalTemperature(((float)(e.CanMsg.DATA[5] << 8) + (float)e.CanMsg.DATA[4]) / (float)10);
                        break;
                    case TACConstant.INST_GET_CURRENT_TEMPERATURE:
                        SetCurrentTemperature(((float)(e.CanMsg.DATA[5] << 8) + (float)e.CanMsg.DATA[4]) / (float)10); 
                        break;
                    case TACConstant.INST_GET_AGITATOR_STATE:
                        SetCurrentAgitation(e.CanMsg.DATA[5]);
                        break;
                    case TACConstant.INST_GET_FAN_STATE:
                        SetCurrentFan(e.CanMsg.DATA[5]);
                        break;
                    case TACConstant.INST_GET_TURBIDITY:
                        SetCurrentTurbidity(BitConverter.ToSingle(e.CanMsg.DATA, 4));
                        break;
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, 1, "send_fan_speed", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, 1, "send_temperature", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, 1, "send_agitator_speed", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, 1, "send_turbidity", ""));
            tac.ExecuteCommand(TacDll.BuildTacCmd(tacId, 1, "send_goal_temperature", ""));
        }

    }
}
