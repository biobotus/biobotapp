using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BioBotCommunication.Serial.Movement;

namespace BioBotCommunicationTest
{
    public partial class BioBotCommTest : Form
    {
        ArduinoCommunicationWorker worker;

        public BioBotCommTest()
        {
            InitializeComponent();
            worker = ArduinoCommunicationWorker.Instance;
            worker.OnCompletionEvent += Worker_OnCompletionEvent;
        }

        private void Worker_OnCompletionEvent(object sender, OnCompletionEventArgs e)
        {
            MessageBox.Show(e.message);
        }

        private void btnStartWorker_Click(object sender, EventArgs e)
        {
            worker.startWorker();
        }

        private void btnStopWorker_Click(object sender, EventArgs e)
        {
            worker.stopWorker();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtSendSerial.Text.Length == 0) return;
            
            worker.startWorker();
            worker.write(txtSendSerial.Text);
        }
    }
}
