using BioBotApp.Model.Data;
using BioBotApp.Model.EventBus;
using BioBotApp.Model.Sequencer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.DLL.PipetteSimple
{
    public class PipetteSimple : Model.EventBus.Subscriber, ICommand
    {
        Model.Communication.CommunicationService communicationService;
        BioBotDataSets.bbt_operationRow operationRow;
        private const int OBJECT_ID = 5;
        public PipetteSimple()
        {
            communicationService = Model.Communication.CommunicationService.Instance;
        }

        [Model.EventBus.Subscribe]
        public void onExecuteEvent(Model.EventBus.Events.ExecutionService.ExecutionEvent e)
        {
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

        [Model.EventBus.Subscribe]
        public void OnMessageReceived(BioBotCommunication.Serial.Events.OnCommunicationMessageReceived e)
        {

            //EventBus.Instance.post(new Model.Sequencer.Events.CompletionCommandEvent(this, operationRow));
        }
    }
}
