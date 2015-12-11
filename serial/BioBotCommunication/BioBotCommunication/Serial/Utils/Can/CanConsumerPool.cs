using PCAN;
using Peak.Can.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanConsumerPool
    {
        List<CanConsumer> consumers;
        PCANCom communication;
        List<byte[]> messagesToSend;
        Billboard billboard;

        public CanConsumerPool(Billboard billboard)
        {
            communication = PCANCom.Instance;
            messagesToSend = new List<byte[]>();
            consumers = new List<CanConsumer>();
            this.billboard = billboard;
            //this.billboard.onBillboardCompletionEvent += Billboard_onBillboardCompletionEvent;
        }
        

        private void Billboard_onBillboardCompletionEvent(object sender, BillboardCompletionEvent e)
        {
            this.messagesToSend.Clear();

            this.consumers.Clear();
        }

        public void newConsumer(byte[] waitMessage)
        {
            if (waitMessage == null) return;
            messagesToSend.Add(waitMessage);
            CanConsumer consumer = new CanConsumer(billboard, waitMessage, waitMessage);
            consumer.onCompletion += Consumer_onCompletion;
            consumer.start();
        }

        private void Consumer_onCompletion(object sender, ConsumerCompletionEvent e)
        {
            if (messagesToSend.Count == 0) return;
            messagesToSend.RemoveAt(0);
            if (messagesToSend.Count == 0) return;
            sendCANMessage(messagesToSend.First());
        }

        public void startExecution()
        {

            sendCANMessage(messagesToSend.First());
        }

        private static void sendCANMessage(byte[] messageToSend)
        {
            TPCANMsg CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];
            CANMsg.DATA[0] = messageToSend[0];
            CANMsg.DATA[1] = messageToSend[1]; 
            CANMsg.DATA[2] = messageToSend[2];
            CANMsg.DATA[3] = messageToSend[3];
            CANMsg.DATA[4] = messageToSend[4];
            CANMsg.DATA[5] = messageToSend[5];
            CANMsg.DATA[6] = messageToSend[6];
            CANMsg.DATA[7] = messageToSend[7];
            CANMsg.ID = Convert.ToUInt32(messageToSend[8]);
            CANQueue.Instance.add(CANMsg);
            CANQueue.Instance.executeFirst();
        }
    }
}
