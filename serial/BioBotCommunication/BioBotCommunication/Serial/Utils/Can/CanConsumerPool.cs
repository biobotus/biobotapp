using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BioBotApp.Utils.Communication.pcan;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanConsumerPool
    {
        List<CanConsumer> consumers;
        PCANCom communication;
        List<byte[]> messagesToSend;
        CanBillboard billboard;

        public CanConsumerPool(CanBillboard billboard)
        {
            communication = PCANCom.Instance;
            messagesToSend = new List<byte[]>();
            consumers = new List<CanConsumer>();
            this.billboard = billboard;
            this.billboard.onBillboardCompletionEvent += Billboard_onBillboardCompletionEvent;
        }

        private void Billboard_onBillboardCompletionEvent(object sender, CanBillboardCompletionEventArgs e)
        {
            this.messagesToSend.Clear();

            this.consumers.Clear();
        }

        public void newConsumer(byte[] waitMessage)
        {
            if (waitMessage == null) return;
            messagesToSend.Add(waitMessage);
            CanConsumer consumer = new CanConsumer(billboard, waitMessage);
            consumer.onCompletion += Consumer_onCompletion;
            consumer.start();
        }

        private void Consumer_onCompletion(object sender, CanConsumerCompletionEventArgs e)
        {
            if (messagesToSend.Count == 0) return;
            messagesToSend.RemoveAt(0);
            if (messagesToSend.Count == 0) return;
            communication.printPacket(messagesToSend.First());
        }

        public void startExecution()
        {
            communication.printPacket(messagesToSend.First());
        }
    }
}
