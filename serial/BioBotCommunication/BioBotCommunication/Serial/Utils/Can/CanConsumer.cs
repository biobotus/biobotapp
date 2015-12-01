using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanConsumer : IConsumer
    {
        private readonly Billboard billboard;
        private readonly byte[] waitValue;
        private volatile bool isStopped = false;
        private bool isNotified = false;
        private Object isNotifiedLock;
        private Thread consumerThread;
        public event EventHandler<CanConsumerCompletionEventArgs> onCompletion;

        public CanConsumer(Billboard billboard, byte[] waitValue)
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
                    List<Object> listValues = billboard.getValues();


                    foreach (Object value in listValues)
                    {
                        if (value is byte[])
                        {
                            byte[] byteValue = Billboard.ObjectToByteArray(value);
                            for (int i = 0; i < byteValue.Length; i++)
                            {
                                if (byteValue[i] != waitValue[i]) return;
                            }
                            Console.WriteLine("Consume: " + waitValue);
                            billboard.delete(value, this);
                            isStopped = true;
                            break;
                        }


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

        public bool objectEquals(object value, object compare)
        {
            byte[] byteValue = value as byte[];
            byte[] compareByte = compare as byte[];
            if (byteValue == null || compare == null) return false;

            if (byteValue.Length == compareByte.Length)
            {
                for (int i = 0; i < byteValue.Length; i++)
                {
                    if (byteValue[i] != compareByte[i]) return false;
                }
            }

            return true;
        }
    }
}
