using BioBotApp.Utils.Communication.pcan;
using PCAN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Can
{
    public class CANCommunicationWorker : PCANCom
    {
        private BackgroundWorker canCommunicationWorker;
        AutoResetEvent toggle = new AutoResetEvent(false);

        private static CANCommunicationWorker instance;
        public static CANCommunicationWorker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CANCommunicationWorker();
                }
                return instance;
            }
        }

        private CANCommunicationWorker()
        {
            canCommunicationWorker = new BackgroundWorker();
            canCommunicationWorker.WorkerSupportsCancellation = true;
            canCommunicationWorker.DoWork += CanCommunicationWorker_DoWork;

           // onPCANReceive += CANCommunicationWorker_onPCANReceive;
           // onErrorMessage += CANCommunicationWorker_onErrorMessage;
        }

        private void CANCommunicationWorker_onErrorMessage(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            toggle.Set();
        }

        private void CANCommunicationWorker_onPCANReceive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SerialPort port = sender as SerialPort;
            String dataReceived = port.ReadExisting();
            if (dataReceived.Contains("a"))
            {
                toggle.Set();
            }
        }

        private void CanCommunicationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int a = 0;
            Boolean finished = false;
            while (!finished)
            {
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                finished = toggle.WaitOne(100);
            }
        }

        public void startWorker()
        {
            if (!canCommunicationWorker.IsBusy)
            {
                canCommunicationWorker.RunWorkerAsync();
            }
        }

        public void stopWorker()
        {
            if (canCommunicationWorker.WorkerSupportsCancellation)
            {
                canCommunicationWorker.CancelAsync();
            }
        }
    }
}
