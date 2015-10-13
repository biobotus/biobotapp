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
        }

        private void btnStartWorker_Click(object sender, EventArgs e)
        {
            worker.startWorker();
        }

        private void btnStopWorker_Click(object sender, EventArgs e)
        {
            worker.stopWorker();
        }
    }
}
