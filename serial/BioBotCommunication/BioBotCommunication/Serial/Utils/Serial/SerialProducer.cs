using BioBotCommunication.Serial.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Serial
{
    public class SerialProducer
    {
        private readonly SerialBillboard billboard;
        private volatile bool isStopped = false;
        private Thread producerThread;
        SerialCommunication serial;

        public SerialProducer(SerialBillboard billboard)
        {
            this.billboard = billboard;
            producerThread = new Thread(run);
            serial = SerialCommunication.Instance;
        }

        public void start()
        {
            producerThread.Start();
        }

        public void write(String value)
        {
            billboard.create(value);
            billboard.notifyReadAll();
        }

        public void run()
        {
            while (!isStopped)
            {
                Thread.Sleep(100);
                if (serial.IsOpen)
                {
                    String data = serial.ReadExisting();
                    if(data != String.Empty)
                    {
                        Console.WriteLine("producing: " + data);
                        write(data);
                    }
                }
            }
        }

        public void stopThread()
        {
            isStopped = true;
            producerThread.Join(1000);
            if (producerThread.IsAlive)
            {
                KillTheThread();
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillTheThread()
        {
            producerThread.Abort();
        }
    }
}
