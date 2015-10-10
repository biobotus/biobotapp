using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioBotApp.View.Communication
{
    public partial class CommunicationTestForm : Form
    {
        BioBotCommunication.Serial.Movement.ArduinoCommunication serialPort;
        public CommunicationTestForm()
        {
            InitializeComponent();
            serialPort = BioBotCommunication.Serial.Movement.ArduinoCommunication.Instance;
        }

        private void btnConnectArduino_Click(object sender, EventArgs e)
        {
            serialPort.configure("COM1", "9600", "8", System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None);
            serialPort.Open();
            BioBotCommunication.Serial.Movement.ArduinoCommunication.Instance.Write("adfghj\r\n");

            serialPort.Close();
        }
    }
}
