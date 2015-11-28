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

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            int subModuleId = GetSubModuleId();
            tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "start_calibration", ""));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int subModuleId = GetSubModuleId();

            if (agitationCb.Checked)
            {
                int agitationValue = agitPct.Value * 10;
                tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "set_agitator_speed", agitationValue.ToString()));
                tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "enable_agitator", ""));
            }
            else
            {
                tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "disable_agitator", ""));
            }

            // TODO verify that tempTB.Text is a float
            tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "set_target_temperature", tempTB.Text));

            if (ventilCb.Checked )
            {
                int vent = VentPct.Value * 10;
                tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "set_fan_speed", vent.ToString()));
                tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "enable_fan", ""));
            }
            else
            {
                tacPlugin.ExecuteCommand(BuildTacCmd(1, subModuleId, "disable_fan", ""));
            }
        }

        private string BuildTacCmd(int moduleId, int subModuleId, string cmd, string value)
        {
            return cmd + " " + moduleId.ToString() + " " + subModuleId.ToString() + " " + value;
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
    }
}
