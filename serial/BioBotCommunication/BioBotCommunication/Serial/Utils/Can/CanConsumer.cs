using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanConsumer
    {
        private readonly CanBillboard billboard;
        private readonly byte[] waitValue;
        private volatile bool isStopped = false;
        private bool isNotified = false;
        private Object isNotifiedLock;
        private Thread consumerThread;
        public event EventHandler<CanConsumerCompletionEventArgs> onCompletion;

        public CanConsumer(CanBillboard billboard, byte[] waitValue)
        {
            isNotifiedLock = new object();
            this.billboard = billboard;
            this.billboard.register(this);
            this.waitValue = waitValue;
            consumerThread = new Thread(run);
        }

        public void start()
        {
            consumerThread.Start();
        }

        public void notifyValue(bool value)
        {
            lock (isNotifiedLock)
            {
                isNotified = value;
            }
        }
        public bool isNotifiedValue()
        {
            lock (isNotifiedLock)
            {
                return isNotified;
            }
        }

        public void stopThread()
        {
            isStopped = true;
            consumerThread.Join(1000);
            if (consumerThread.IsAlive)
            {
                KillTheThread();
            }
        }

        public void run()
        {
            while (!isStopped)
            {
                Thread.Sleep(100);

                if (isNotifiedValue())
                {
                    List<byte[]> listValues = billboard.getValues();
                    foreach (byte[] value in listValues)
                    {
                        foreach (byte[] data in listValues)
                        {
                            if (waitValue.Length == data.Length)
                            {
                                for (int i = 0; i < data.Length; i++)
                                {
                                    if (data[i] != waitValue[i]) return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                        Console.WriteLine("Consume: " + waitValue);
                        billboard.delete(waitValue);
                        isStopped = true;
                        break;

                    }
                    notifyValue(false);
                }
            }
            if (onCompletion != null)
            {
                onCompletion(this, new CanConsumerCompletionEventArgs());
                billboard.unregister(this);
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillTheThread()
        {
            consumerThread.Abort();
        }
    }
}
