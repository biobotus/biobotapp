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
        private List<String> receivedData;
        private volatile Boolean isStopped = false;

        private ArduinoCommunicationWorker()
        {
            arduinoSerialWorker = new Thread(ArdunioSerialWorker_DoWork);
            onArduinoReceive += ArduinoCommunicationWorker_onArduinoReceive;
            onErrorMessage += ArduinoCommunicationWorker_onErrorMessage;
            arduinoSerialWorker.Start();
            receivedData = new List<String>();
        }

        private void ArduinoCommunicationWorker_onErrorMessage(object sender, SerialErrorReceivedEventArgs e)
        {

        }

        private void ArduinoCommunicationWorker_onArduinoReceive(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender is SerialPort)
            {
                SerialPort port = sender as SerialPort;
                lock (receivedData)
                {
                    receivedData.Add(port.ReadExisting());
                }
            }
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
            while (!isStopped)
            {
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

        public List<String> getMessages()
        {
            List<String> deepCopy = new List<string>();
            lock (receivedData)
            {
                foreach(String data in receivedData)
                {
                    deepCopy.Add(String.Copy(data));
                }
            }
            return deepCopy;
        }

        public void consume(String consumeData)
        {
            lock (receivedData)
            {
                foreach (String data in receivedData)
                {
                    if (data.Contains(consumeData))
                    {
                        receivedData.Remove(data);
                    }
                }
            }
        }
    }
}
