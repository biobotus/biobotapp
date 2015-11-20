using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class SerialCommunicationWorker : SerialCommunication
    {
        private BackgroundWorker arduinoSerialWorker;
        AutoResetEvent toggle = new AutoResetEvent(false);

        private SerialCommunicationWorker()
        {
            arduinoSerialWorker = new BackgroundWorker();
            arduinoSerialWorker.WorkerSupportsCancellation = true;
            arduinoSerialWorker.DoWork += ArdunioSerialWorker_DoWork;
            onArduinoReceive += ArduinoCommunicationWorker_onArduinoReceive;
            onErrorMessage += ArduinoCommunicationWorker_onErrorMessage;
        }

        private void ArduinoCommunicationWorker_onErrorMessage(object sender, SerialErrorReceivedEventArgs e)
        {
            toggle.Set();
        }

        private void ArduinoCommunicationWorker_onArduinoReceive(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = sender as SerialPort;
            String dataReceived = port.ReadExisting();
            if (dataReceived.Contains("a"))
            {
                toggle.Set();
            }
        }

        private static SerialCommunicationWorker instance;
        public static SerialCommunicationWorker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialCommunicationWorker();
                }
                return instance;
            }
        }

        private void ArdunioSerialWorker_DoWork(object sender, DoWorkEventArgs e)
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
            if (!arduinoSerialWorker.IsBusy)
            {
                arduinoSerialWorker.RunWorkerAsync();
            }
        }

        public void stopWorker()
        {
            if (arduinoSerialWorker.WorkerSupportsCancellation)
            {
                arduinoSerialWorker.CancelAsync();
            }
        }
    }
}
