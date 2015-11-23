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
    public class ArduinoCommunicationWorker : ArduinoCommunication
    {
        private BackgroundWorker arduinoSerialWorker;
        private AutoResetEvent toggle = new AutoResetEvent(false);
        public event EventHandler<OnCompletionEventArgs> OnCompletionEvent;

        private ArduinoCommunicationWorker()
        {
            arduinoSerialWorker = new BackgroundWorker();
            arduinoSerialWorker.WorkerSupportsCancellation = true;
            arduinoSerialWorker.DoWork += ArdunioSerialWorker_DoWork;
            onArduinoReceive += ArduinoCommunicationWorker_onArduinoReceive;
            onErrorMessage += ArduinoCommunicationWorker_onErrorMessage;
        }

        private void ArduinoCommunicationWorker_onErrorMessage(object sender, SerialErrorReceivedEventArgs e)
        {
            OnCompletionEventArgs eventargs = new OnCompletionEventArgs("Serial port receive error !");
            eventargs.error = true;
            OnMessageReceivedEvent(eventargs);
            toggle.Set();
        }

        private void ArduinoCommunicationWorker_onArduinoReceive(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort port = sender as SerialPort;
            String dataReceived = port.ReadExisting();

            OnCompletionEventArgs eventargs = new OnCompletionEventArgs("Completed work");
            eventargs.error = false;
            OnMessageReceivedEvent(eventargs);
            toggle.Set();
        }

        private static ArduinoCommunicationWorker instance;
        public static ArduinoCommunicationWorker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArduinoCommunicationWorker();
                }
                return instance;
            }
        }

        private void ArdunioSerialWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
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

        protected virtual void OnMessageReceivedEvent(OnCompletionEventArgs e)
        {
            EventHandler<OnCompletionEventArgs> handler = OnCompletionEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
