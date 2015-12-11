using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils
{
    public class ConsumerPool
    {
        List<AbstractConsumer> consumers;
        Billboard billboard;

        public ConsumerPool(Billboard billboard)
        {
            consumers = new List<AbstractConsumer>();
            this.billboard = billboard;
        }

        public void addConsumer(AbstractConsumer consumer)
        {
            if (consumer == null) return;
            lock (consumers)
            {
                consumers.Add(consumer);
            }
            consumer.onCompletion += Consumer_onCompletion;
            consumer.start();
        }

        private void Consumer_onCompletion(object sender, ConsumerCompletionEvent e)
        {
            lock (consumers)
            {
                if (consumers.Count == 0) return;
                consumers.RemoveAt(0);
                if (consumers.Count == 0) return;
                consumers.First().writeLine(consumers.First().getWriteValue());
            }
        }

        public void startExecutionHistory()
        {
            lock (consumers)
            {
                if (consumers.Count == 0) return;
                consumers.First().writeLine(consumers.First().getWriteValue());
            }
        }
    }
}
