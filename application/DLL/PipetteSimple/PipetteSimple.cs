using BioBotApp.Model.Data;
using BioBotApp.Model.EventBus;
using BioBotApp.Model.Sequencer.Helpers;
using BioBotCommunication.Serial.Movement;
using BioBotCommunication.Serial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.DLL.PipetteSimple
{
    public class PipetteSimple : Model.EventBus.Subscriber, ICommand
    {
        BioBotDataSets.bbt_operationRow operationRow;
        private const int OBJECT_ID = 5;
        SerialCommunication communication;
        List<String> messagesToSend;
        //List<SerialConsumer> localConsumers;

        public PipetteSimple()
        {
            communication = SerialCommunication.Instance;
            messagesToSend = new List<string>();
        }

        [Model.EventBus.Subscribe]
        public void onExecuteEvent(Model.EventBus.Events.ExecutionService.ExecutionEvent e)
        {
            /*
            if(e.operationRow.bbt_stepRow.bbt_objectRow.fk_object_type == 5)
            {
                Billboard billboard = e.billboard;
                String first = System.Guid.NewGuid().ToString();
                String second = System.Guid.NewGuid().ToString();
                messagesToSend.Add(first);
                messagesToSend.Add(second);
                SerialConsumer consumer = new SerialConsumer(billboard, first);
                consumer.onCompletion += Consumer_onCompletion;
                consumer.start();

                communication.WriteLine("Pipette: " + first);

                SerialConsumer consumer2 = new SerialConsumer(billboard, second);
                consumer2.onCompletion += Consumer_onCompletion;
                consumer2.start();
            }
            */
            /*
            Model.Data.BioBotDataSets.bbt_operationRow row = e.operationRow;
            if (row == null) return;
            BioBotDataSets.bbt_stepRow stepRow = row.bbt_stepRow;
            if(stepRow.bbt_objectRow.fk_object_type == OBJECT_ID)
            {
                operationRow = row;
                Console.WriteLine("Single channel pipette step execute: " + stepRow.description);
                EventBus.Instance.post(new Model.Sequencer.Events.ExecuteCommandEvent(this, operationRow));
            }
            if(row.Getbbt_operation_referenceRows().Length > 0)
            {
                
                foreach(BioBotDataSets.bbt_operation_referenceRow referenceRow in row.Getbbt_operation_referenceRows())
                {
                    if(referenceRow.fk_object == OBJECT_ID)
                    {
                        operationRow = row;
                        Console.WriteLine("Single channel pipette operation execute: " + row.bbt_operation_typeRow.description);
                        EventBus.Instance.post(new Model.Sequencer.Events.ExecuteCommandEvent(this, operationRow));
                    }
                }
            }
            */
        }

        private void Consumer_onCompletion(object sender, ConsumerCompletionEventargs e)
        {
            if (messagesToSend.Count == 0) return;
            messagesToSend.RemoveAt(0);
            if (messagesToSend.Count == 0) return;
            communication.WriteLine("Pipette: " + messagesToSend.First());
        }
    }
}
