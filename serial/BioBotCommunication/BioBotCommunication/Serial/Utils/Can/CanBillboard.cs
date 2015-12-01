using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanBillboard
    {
        private List<byte[]> listValues = new List<byte[]>();
        private List<CanConsumer> listConsumers = new List<CanConsumer>();
        private readonly Object registerLock = new Object();
        public event EventHandler<CanBillboardCompletionEventArgs> onBillboardCompletionEvent;

        public CanBillboard()
        {

        }

        public void create(byte[] value)
        {
            lock (listValues)
            {
                listValues.Add(value);
            }
        }

        public void emptyList()
        {
            lock (listValues)
            {
                listValues.Clear();
            }
        }

        public void delete(byte[] valueId)
        {
            lock (listValues)
            {
                
                foreach (byte[] data in listValues)
                {
                    if (valueId.Length == data.Length)
                    {
                        for (int i = 0; i < data.Length; i++)
                        {
                            if (data[i] != valueId[i]) return;
                        }
                    }
                    listValues.Remove(data);
                }
                if (listValues.Count == 0)
                {
                    Console.WriteLine("END OF OPERATION: " + valueId);
                }
            }
        }

        public List<byte[]> getValues()
        {
            List<byte[]> copy = new List<byte[]>();
            lock (listValues)
            {
                foreach (byte[] data in listValues)
                {
                    byte[] temp = new byte[data.Length];
                    data.CopyTo(temp, 0);
                    copy.Add(temp);
                }
            }
            return copy;
        }

        public void notifyReadAll()
        {
            lock (registerLock)
            {
                foreach (CanConsumer consumer in listConsumers)
                {
                    consumer.notifyValue(true);
                }
            }
        }
        public Boolean register(CanConsumer consumer)
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
        public Boolean unregister(CanConsumer consumer)
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
                            onBillboardCompletionEvent(this, new CanBillboardCompletionEventArgs());
                            Console.WriteLine("Bilboard completion !");
                        }
                    }
                }
                return isRegistered;
            }
        }

        public int getConsumerRegisteredSize()
        {
            lock (listConsumers)
            {
                return listConsumers.Count;
            }
        }
    }
}
