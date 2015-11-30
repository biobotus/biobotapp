using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotApp.View.Utils;

namespace BioBotApp.View.Main
{
    public partial class MainViewControl : DatasetViewControl, IMainView
    {
        public MainViewControl()
        {
            InitializeComponent();
        }

        public void setConnectionStatus(string status)
        {
            txtConnectionStatus.Text = status;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            AbstractDialog dialog = new AbstractDialog();
            BioBotCommunication.Serial.Movement.ArduinoSerialCommControl control = new BioBotCommunication.Serial.Movement.ArduinoSerialCommControl();
            dialog.addControl(control);
            DialogResult result = dialog.ShowDialog();
            if (result != DialogResult.OK)
            {
                BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker.Instance.stopWorker();
            }
        }
    }
}
