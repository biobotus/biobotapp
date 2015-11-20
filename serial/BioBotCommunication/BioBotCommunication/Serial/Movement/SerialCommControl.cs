using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BioBotCommunication.Serial.Movement
{
    public partial class SerialCommControl : UserControl
    {
        public SerialCommControl()
        {
            InitializeComponent();
            ddlBaud.Items.Add(300);
            ddlBaud.Items.Add(600);
            ddlBaud.Items.Add(1200);
            ddlBaud.Items.Add(2400);
            ddlBaud.Items.Add(9600);
            ddlBaud.Items.Add(14400);
            ddlBaud.Items.Add(19200);
            ddlBaud.Items.Add(38400);
            ddlBaud.Items.Add(57600);
            ddlBaud.Items.Add(115200);
            ddlBaud.Items.ToString();
            //get first item print in text
            ddlBaud.Text = ddlBaud.Items[ddlBaud.Items.Count - 1].ToString();

            ddlDataBits.Items.Add(7);
            ddlDataBits.Items.Add(8);
            //get the first item print it in the text 
            ddlDataBits.Text = ddlDataBits.Items[ddlDataBits.Items.Count - 1].ToString();

            ddlStopBits.Items.Add(StopBits.One);
            ddlStopBits.Items.Add(StopBits.OnePointFive);
            ddlStopBits.Items.Add(StopBits.Two);
            //get the first item print in the text
            ddlStopBits.Text = ddlStopBits.Items[0].ToString();

            //Parity 
            ddlParity.Items.Add(Parity.None);
            ddlParity.Items.Add(Parity.Even);
            ddlParity.Items.Add(Parity.Mark);
            ddlParity.Items.Add(Parity.Odd);
            ddlParity.Items.Add(Parity.Space);

            //get the first item print in the text

            ddlParity.Text = ddlParity.Items[0].ToString();
        }

        private void btnResfresh_Click(object sender, EventArgs e)
        {
            refreshPortsNames();
        }

        private void refreshPortsNames()
        {
            string[] comPortsNames = null;

            comPortsNames = SerialPort.GetPortNames();
            if (comPortsNames.Length == 0)
            {
                return;
            }
            ddlPortName.Items.Clear();

            foreach (String portName in comPortsNames)
            {
                ddlPortName.Items.Add(portName);
            }

            Array.Sort(comPortsNames);
            ddlPortName.Text = comPortsNames[0];
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(!(ddlStopBits.SelectedItem is StopBits) || !(ddlParity.SelectedItem is Parity))
            {
                return;
            }
            SerialCommunicationWorker.Instance.configure(ddlPortName.Text,ddlBaud.Text,ddlDataBits.Text, (StopBits)ddlStopBits.SelectedItem, (Parity)ddlParity.SelectedItem);
        }

        private void ArduinoSerialCommControl_Load(object sender, EventArgs e)
        {
            refreshPortsNames();
        }
    }
}
