using BioBotCommunication.Serial.Utils.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils
{
    public abstract class AbstractConsumer
    {
        private readonly Billboard billboard;
        private readonly Object waitValue;
        private readonly Object writeValue;
        private volatile bool isStopped = false;
        private bool isNotified = false;
        private Object isNotifiedLock;
        private Thread consumerThread;
        public event EventHandler<ConsumerCompletionEvent> onCompletion;
        public abstract bool objectEquals(object value, object compare);
        public abstract void writeLine(Object writeValue);

        public AbstractConsumer(Billboard billboard, Object waitValue, Object writeValue)
        {
            isNotifiedLock = new object();
            this.billboard = billboard;
            this.billboard.register(this);
            this.writeValue = writeValue;
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
                        if(objectEquals(value, waitValue))
                        {
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
                onCompletion(this, new ConsumerCompletionEvent());
                billboard.unregister(this);
            }
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillTheThread()
        {
            consumerThread.Abort();
        }

        //TODO: deep copy
        public Object getWaitValue()
        {
            return waitValue;
        }

        //TODO: deep copy
        public Object getWriteValue()
        {
            return writeValue;
        }
    }
}
