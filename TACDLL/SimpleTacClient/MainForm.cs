using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TACDLL;
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
            tacDescriptionPanel.Controls.Clear();
            tacDescriptionPanel.Controls.Add(tacPlugin.GetModuleDescriptionControl(1234));

            dll.ExecuteCommand("set_taget_temperature 32.65 7 2");
            dll.ExecuteCommand("set_taget_temperature 254.58 7 2");
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
            tacPlugin.ExecuteCommand("start_calibration 1 1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int agitation = trackBar1.Value * 10;
            string agitationCommand = "set_agitator_speed 1 1 " + agitation.ToString();
            tacPlugin.ExecuteCommand(agitationCommand);

            string tempCmd = "set_taget_temperature 1 1 " + tempTB.Text;
            tacPlugin.ExecuteCommand(tempCmd);

            if(ventilCb.Checked )
            {
                int vent = trackBar1.Value * 10;
                string ventCmd =;
            }
        }
    }
}
