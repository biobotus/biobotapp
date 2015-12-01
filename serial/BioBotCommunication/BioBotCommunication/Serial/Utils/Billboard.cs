using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils
{
    public class Billboard
    {
        private List<Object> listValues = new List<Object>();
        private List<IConsumer> listConsumers = new List<IConsumer>();
        private readonly Object registerLock = new Object();
        public event EventHandler<BillboardCompletionEvent> onBillboardCompletionEvent;

        public Billboard()
        {

        }

        public void create(Object value)
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

        public void delete(Object valueId, IConsumer consumer)
        {
            lock (listValues)
            {
                foreach (Object data in listValues)
                {
                    if (consumer.objectEquals(data, valueId))
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

        public List<Object> getValues()
        {
            List<Object> copy = new List<Object>();
            lock (listValues)
            {
                foreach (Object data in listValues)
                {
                    if(data is String)
                    {
                        String dataString = data as String;
                        copy.Add(String.Copy(dataString));
                    }
                    else if(data is byte[])
                    {
                        byte[] dataByte = data as byte[];
                        byte[] deepCopy = new byte[dataByte.Length];
                        for(int i = 0; i < dataByte.Length; i++)
                        {
                            deepCopy[i] = dataByte[i];
                        }
                        copy.Add(ByteArrayToObject(deepCopy));
                    }
                }
            }
            return copy;
        }

        public void notifyReadAll()
        {
            lock (registerLock)
            {
                foreach (IConsumer consumer in listConsumers)
                {
                    consumer.notifyValue(true);
                }
            }
        }
        public Boolean register(IConsumer consumer)
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
        public Boolean unregister(IConsumer consumer)
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
                            onBillboardCompletionEvent(this, new BillboardCompletionEvent());
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

        public static byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        public static Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);
            return obj;
        }
    }
}
