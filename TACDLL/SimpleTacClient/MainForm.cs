using System;
using System.Windows.Forms;
using TACDLL;
using TACDLL.Can;
namespace SimpleTacClient
{
    public partial class MainForm : Form
    {
        Option.frmOptions option;
        TacDll tacPlugin;
        public MainForm(TacDll dll)
        {
            InitializeComponent();
            tacPlugin = dll;
            option = new Option.frmOptions(tacPlugin.GetConfTreeNode(), tacPlugin.getConfAction());
        }

        #region UI-event
        /// <summary>
        /// Display a simple about modal window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple client to operate a TAC module.",
                            "About",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question);
        }

        /// <summary>
        /// Basic exit program action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Display the option modal form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option.ShowDialog();
        }

        private void autoCallibrationBtn_Click(object sender, EventArgs e)
        {
            // not implemented yet
        }

        /// <summary>
        /// Send the command to the tac acording to the user param
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            int subModuleId = GetSubModuleId();
            int moduleId = GetModuleId();
            if (agitationCb.Checked)
            {
                
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "enable_agitator", ""));
            }
            else
            {
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "disable_agitator", ""));
            }
            int agitationValue = agitPct.Value * 10;
            tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "set_agitator_speed", agitationValue.ToString()));

            // TODO verify that tempTB.Text is a float
            tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "set_target_temperature", tempTB.Text));

            if (ventilCb.Checked)
            {
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "enable_fan", ""));
            }
            else
            {
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "disable_fan", ""));
            }
            int vent = VentPct.Value * 10;
            tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "set_fan_speed", vent.ToString()));

        }

        private void moduleIdTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                loadTacDescription();
            }
        }

        private void moduleIdTxt_Validated(object sender, EventArgs e)
        {
            loadTacDescription();
        }

        #endregion

        /// <summary>
        /// Validate the moduleIdTxt and cast it as an int to return the module id.
        /// </summary>
        /// <returns>The desired module id</returns>
        private int GetModuleId()
        {
            int moduleId = -1;
            bool isModleIdValid = int.TryParse(moduleIdTxt.Text, out moduleId);
            if (!isModleIdValid)
            {
                MessageBox.Show("The module ID should be an int",
                "Error : invalid module ID",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return moduleId;
        }

        /// <summary>
        /// find the submodule id from the radio button checked
        /// </summary>
        /// <returns>The selected submodule Id</returns>
        private int GetSubModuleId()
        {
            int subModuleId = TACConstant.MODULE0;
            if (sub2RB.Checked)
            {
                subModuleId = TACConstant.MODULE1;
            }
            return subModuleId;
        }

        private void loadTacDescription()
        {
            int moduleId = GetModuleId();

            tacDescriptionPanel.Controls.Clear();

            TACDLL.OptionCtrl.TacDescription tacDesc;
            tacDesc = (TACDLL.OptionCtrl.TacDescription)tacPlugin.GetModuleDescriptionControl(moduleId);
            tacDescriptionPanel.Controls.Add(tacDesc);
        }


    }
}
