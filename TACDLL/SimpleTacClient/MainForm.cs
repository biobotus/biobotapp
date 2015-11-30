using System;
using System.Windows.Forms;
using TACDLL;

namespace SimpleTacClient
{
    public partial class MainForm : Form
    {
        Option.frmOptions option;
        TacDll tacPlugin;
        TACDLL.OptionCtrl.TacDescription tacDesc; 
        public MainForm(TacDll dll)
        {
            InitializeComponent();
            tacPlugin = dll;
            option = new Option.frmOptions(tacPlugin.GetConfTreeNode(), tacPlugin.getConfAction());
            tacDescriptionPanel.Controls.Clear();
            tacDesc = (TACDLL.OptionCtrl.TacDescription)tacPlugin.GetModuleDescriptionControl(1234);
            tacDescriptionPanel.Controls.Add(tacDesc);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a simple client to operate a TAC module.",
                            "About",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Question);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            option.ShowDialog();
        }

        private void autoCallibrationBtn_Click(object sender, EventArgs e)
        {
            // not implemented yet
        }

        private void sendCommandBtn_Click(object sender, EventArgs e)
        {
            int subModuleId = GetSubModuleId();
            int moduleId = GetModuleId();
            if (agitationCb.Checked)
            {
                int agitationValue = agitPct.Value * 10;
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "set_agitator_speed", agitationValue.ToString()));
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "enable_agitator", ""));
            }
            else
            {
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "disable_agitator", ""));
            }

            // TODO verify that tempTB.Text is a float
            tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "set_target_temperature", tempTB.Text));

            if (ventilCb.Checked)
            {
                int vent = VentPct.Value * 10;
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "set_fan_speed", vent.ToString()));
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "enable_fan", ""));
            }
            else
            {
                tacPlugin.ExecuteCommand(TacDll.BuildTacCmd(moduleId, subModuleId, "disable_fan", ""));
            }
        }
        

        private int GetModuleId()
        {
            int moduleId = -1;
            bool isMoudleIdValid = int.TryParse(moduleIdTxt.Text, out moduleId);
            if (isMoudleIdValid)
            {
                int subModuleId = GetSubModuleId();
            }
            else
            {
                MessageBox.Show("The module ID should be an int",
                "Error : invalid module ID",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            return moduleId;
        }

        private int GetSubModuleId()
        {
            int subModuleId = 1;
            if (sub2RB.Checked)
            {
                subModuleId = 2;
            }
            return subModuleId;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
