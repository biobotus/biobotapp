using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils
{
    public class Billboard
    {
        private List<String> listValues = new List<String>();
        private List<SerialConsumer> listConsumers = new List<SerialConsumer>();
        private readonly Object registerLock = new Object();
        public event EventHandler<BillboardCompletionEventArgs> onBillboardCompletionEvent;

        public Billboard()
        {

        }

        public void create(String value)
        {
            lock (listValues)
            {
                listValues.Add(value);
            }
        }
        public void delete(String valueId)
        {
            lock (listValues)
            {
                foreach (String data in listValues)
                {
                    if (data.Contains(valueId))
                    {
                        listValues.Remove(data);
                        break;
                    }
                }
                if (listValues.Count == 0)
                {
                    Console.WriteLine("END OF OPERATION: " + valueId);
                }
            }

        }

        public List<String> getValues()
        {
            List<String> copy = new List<string>();
            lock (listValues)
            {
                foreach (String data in listValues)
                {
                    copy.Add(String.Copy(data));
                }
            }
            return copy;
        }

        public void notifyReadAll()
        {
            lock (registerLock)
            {
                foreach (SerialConsumer consumer in listConsumers)
                {
                    consumer.notifyValue(true);
                }
            }
        }
        public Boolean register(SerialConsumer consumer)
        {
            Boolean isRegistered = false;
            lock (registerLock)
            {
                isRegistered = listConsumers.Contains(consumer);
                if (!isRegistered)
                {
                    listConsumers.Add(consumer);
                    isRegistered = true;
                }
            }
            return isRegistered;
        }
        public Boolean unregister(SerialConsumer consumer)
        {
            Boolean isRegistered = false;
            lock (registerLock)
            {
                isRegistered = listConsumers.Contains(consumer);
                if (isRegistered)
                {
                    listConsumers.Remove(consumer);
                    isRegistered = false;
                    if (listConsumers.Count == 0)
                    {
                        if (onBillboardCompletionEvent != null)
                        {
                            onBillboardCompletionEvent(this, new BillboardCompletionEventArgs());
                            Console.WriteLine("Bilboard completion !");
                        }
                    }
                }
                return isRegistered;
            }
        }
    }
}
