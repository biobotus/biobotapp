using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class ArduinoCommunicationWorker : ArduinoCommunication
    {
        private Thread arduinoSerialWorker;
        private AutoResetEvent toggle = new AutoResetEvent(false);
        public event EventHandler<OnCompletionEventArgs> OnCompletionEvent;
        private List<String> data;
        private volatile Boolean isStopped = false;

        private ArduinoCommunicationWorker()
        {
            arduinoSerialWorker = new Thread(ArdunioSerialWorker_DoWork);
            onArduinoReceive += ArduinoCommunicationWorker_onArduinoReceive;
            onErrorMessage += ArduinoCommunicationWorker_onErrorMessage;
            arduinoSerialWorker.Start();
        }

        private void ArduinoCommunicationWorker_onErrorMessage(object sender, SerialErrorReceivedEventArgs e)
        {
            OnCompletionEventArgs eventargs = new OnCompletionEventArgs("Serial port receive error !");
            eventargs.error = true;
            toggle.Set();
        }

        private void ArduinoCommunicationWorker_onArduinoReceive(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender is SerialPort)
            {
                SerialPort port = sender as SerialPort;
                lock (data)
                {
                    data.Add(port.ReadExisting());
                }
            }


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

        private void ArdunioSerialWorker_DoWork()
        {
            Boolean dataReceived = false;
            while (!isStopped)
            {
                lock (data)
                {
                    dataReceived = toggle.WaitOne(100);
                    if (dataReceived)
                    {
                        dataReceived = false;                        
                        toggle.Reset();
                        OnMessageReceivedEvent(new OnCompletionEventArgs(data));
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void stopWorker()
        {
            isStopped = true;
            arduinoSerialWorker.Join(1000);
            if (arduinoSerialWorker.IsAlive)
            {
                KillTheThread();
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillTheThread()
        {
            arduinoSerialWorker.Abort();
        }

        protected virtual void OnMessageReceivedEvent(OnCompletionEventArgs e)
        {
            EventHandler<OnCompletionEventArgs> handler = OnCompletionEvent;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public String getNextMessage()
        {
            String dataReturn = "";
            lock (data)
            {
                if(data.Count > 0)
                {
                    dataReturn = data[0];
                    data.RemoveAt(0);
                }
            }
            return dataReturn;
        }
    }
}
