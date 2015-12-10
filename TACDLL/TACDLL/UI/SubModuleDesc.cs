using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TACDLL.UI
{
    public partial class SubModuleDesc : UserControl
    {
        public SubModuleDesc()
        {
            InitializeComponent();
        }

        #region labelSetter
        /// <summary>
        /// Set the goal temperature label with a temperature in a thread safe fashion
        /// </summary>
        /// <param name="temp">the value to be set</param>
        public void SetGoalTemperature(float temp)
        {
            if (this.goalTempLabel.InvokeRequired)
            {
                this.goalTempLabel.BeginInvoke((MethodInvoker)delegate () { this.goalTempLabel.Text = temp.ToString("00.0") + " °C"; });
            }
            else
            {
                this.goalTempLabel.Text = temp.ToString("00.0");
            }
        }

        /// <summary>
        /// Set the current temperature label with a temperature in a thread safe fashion
        /// </summary>
        /// <param name="temp">the value to be set</param>
        public void SetCurrentTemperature(float temp)
        {
            if (this.currentTempLabel.InvokeRequired)
            {
                this.currentTempLabel.BeginInvoke((MethodInvoker)delegate () { this.currentTempLabel.Text = temp.ToString("00.0") + " °C"; });
            }
            else
            {
                this.currentTempLabel.Text = temp.ToString("00.0") + " °C";
            }
        }

        /// <summary>
        /// Set the current fan speed label with a percent in a thread safe fashion
        /// </summary>
        /// <param name="fanSpeed">the value to be set should be in [0-100]</param>
        public void SetCurrentFan(int fanSpeed)
        {
            if (fanSpeed > 100 || fanSpeed < 0)
            {
                return;
            }

            if (this.VentilationLabel.InvokeRequired)
            {
                this.VentilationLabel.BeginInvoke((MethodInvoker)delegate () { this.VentilationLabel.Text = fanSpeed.ToString(); });
            }
            else
            {
                this.VentilationLabel.Text = fanSpeed.ToString();
            }
        }

        /// <summary>
        /// Set the current turbidity label with a value in a thread safe fashion
        /// </summary>
        /// <param name="turbido">the value to be set</param>
        public void SetCurrentTurbidity(float turbido)
        {
            if (this.OpticalDensityLabel.InvokeRequired)
            {
                this.OpticalDensityLabel.BeginInvoke((MethodInvoker)delegate () { this.OpticalDensityLabel.Text = turbido.ToString("0.0000"); });
            }
            else
            {
                this.OpticalDensityLabel.Text = turbido.ToString("0.0000");
            }
        }

        /// <summary>
        /// Set the current agitation speed label with a percent in a thread safe fashion
        /// </summary>
        /// <param name="agitationSpeed">the agitation value to be set. It should be in [0-100]</param>
        public void SetCurrentAgitation(int agitationSpeed)
        {
            if (agitationSpeed > 100 || agitationSpeed < 0)
            {
                return;
            }

            if (this.AgitationLabel.InvokeRequired)
            {
                this.AgitationLabel.BeginInvoke((MethodInvoker)delegate () { this.AgitationLabel.Text = agitationSpeed.ToString(); });
            }
            else
            {
                this.AgitationLabel.Text = agitationSpeed.ToString();
            }
        }
        #endregion
    }
}
