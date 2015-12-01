using BioBotApp.Utils.Communication.pcan;
using Peak.Can.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanProducer
    {
        private readonly Billboard billboard;
        private volatile bool isStopped = false;
        private Thread producerThread;
        PCANCom serial;
        List<byte[]> receivedData;
        AutoResetEvent messageReceived;

        public CanProducer(Billboard billboard)
        {
            this.billboard = billboard;
            producerThread = new Thread(run);
            serial = PCANCom.Instance;
            serial.OnMessageReceived += Serial_OnMessageReceived;
            receivedData = new List<byte[]>();
        }

        private void Serial_OnMessageReceived(object sender, PCANComEventArgs e)
        {
            lock (receivedData)
            {
                receivedData.Add(e.CanMsg.DATA);
            }
            messageReceived.Set();
        }

        public void start()
        {
            producerThread.Start();
        }

        public void write(byte[] value)
        {
            billboard.create(value);
            billboard.notifyReadAll();
        }

        public void run()
        {
            while (!isStopped)
            {
                if (messageReceived.WaitOne(100))
                {
                    lock (receivedData)
                    {
                        while (receivedData.Count > 0)
                        {
                            Console.WriteLine("producing: " + receivedData.First());
                            write(receivedData.First());
                            receivedData.Remove(receivedData.First());
                        }
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
