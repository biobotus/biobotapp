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
        //BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker serialPort;
        public CommunicationTestForm()
        {
            InitializeComponent();
            /*
            serialPort = BioBotCommunication.Serial.Movement.ArduinoCommunicationWorker.Instance;
            serialPort.onConnect += SerialPort_onConnect;
            serialPort.onDisconnect += SerialPort_onDisconnect;
            */
        }

        private void SerialPort_onDisconnect(object sender, EventArgs e)
        {
            lblConnection.Text = "Disconnected";
        }

        private void SerialPort_onConnect(object sender, EventArgs e)
        {
            lblConnection.Text = "Connected";
        }

        private void btnConnectArduino_Click(object sender, EventArgs e)
        {
            //serialPort.configure("COM1", "9600", "8", System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None);
            //serialPort.Open();
            //BioBotCommunication.Serial.Movement.ArduinoCommunication.Instance.Write("adfghj\r\n");

            //serialPort.Close();

        }
    }
}
