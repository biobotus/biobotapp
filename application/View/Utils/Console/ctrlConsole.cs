using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Utils.Console
{
    public partial class ctrlConsole : UserControl
    {
        public ctrlConsole()
        {
            InitializeComponent();
        }

        private void btnSendCmbToRemote_Click(object sender, EventArgs e)
        {
            if (edtCmdWindow.Text.Length > 0)
            {
                edtCmdWindow.Text += "\r\n";
            }
            edtCmdWindow.Text += edtSendCmd.Text;
            edtCmdWindow.SelectionStart = edtCmdWindow.Text.Length;
            edtCmdWindow.ScrollToCaret();
        }

        public void Log(String logLine)
        {
            if (edtCmdWindow.Text.Length > 0)
            {
                edtCmdWindow.Text += "\r\n";
            }
            edtCmdWindow.Text += logLine;
            edtCmdWindow.SelectionStart = edtCmdWindow.Text.Length;
            edtCmdWindow.ScrollToCaret();
        }
    }
}
