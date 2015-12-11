﻿using BioBotCommunication.Serial.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Serial
{
    public class SerialConsumerPool
    {
        List<SerialConsumer> consumers;
        SerialCommunication communication;
        List<String> messagesToSend;
        Billboard billboard;

        public SerialConsumerPool(Billboard billboard)
        {
            communication = SerialCommunication.Instance;
            messagesToSend = new List<string>();
            consumers = new List<SerialConsumer>();
            this.billboard = billboard;
            //this.billboard.onBillboardCompletionEvent += Billboard_onBillboardCompletionEvent;
        }

        private void Billboard_onBillboardCompletionEvent(object sender, BillboardCompletionEvent e)
        {
            this.messagesToSend.Clear();

            this.consumers.Clear();
        }

        public void newConsumer(String waitMessage, String writeMessage)
        {
            if (waitMessage == null) return;
            messagesToSend.Add(String.Copy(waitMessage));
            SerialConsumer consumer = new SerialConsumer(billboard, waitMessage, writeMessage);
            consumer.onCompletion += Consumer_onCompletion;
            consumer.start();
        }

        private void Consumer_onCompletion(object sender, ConsumerCompletionEvent e)
        {
            if (messagesToSend.Count == 0) return;
            messagesToSend.RemoveAt(0);
            if (messagesToSend.Count == 0) return;
            communication.WriteLine(messagesToSend.First());
        }

        public void startExecution()
        {
            communication.WriteLine(messagesToSend.First());
        }
    }
}
