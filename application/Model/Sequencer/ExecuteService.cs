using BioBotApp.Model.Data;
using BioBotApp.Model.EventBus;
using BioBotApp.Model.Sequencer.Helpers;
using BioBotCommunication.Serial.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// the 'Invoker' class 
/// </summary>
namespace BioBotApp.Model.Sequencer
{
    public class ExecuteService : Subscriber
    {
        DBManager dbManager;

        private static ExecuteService privateInstance;
        BioBotDataSets.bbt_save_protocol_referenceDataTable commands;
        Dictionary<int, BioBotDataSets.bbt_operationRow> commandsTODO;
        int index = 0;
        SerialProducer producer;
        Billboard billboard;

        private ExecuteService()
        {
            this.dbManager = DBManager.Instance;
            commandsTODO = new Dictionary<int, BioBotDataSets.bbt_operationRow>();
            billboard = new Billboard();
            billboard.onBillboardCompletionEvent += Billboard_onBillboardCompletionEvent;
            producer = new SerialProducer(billboard);
            producer.start();
        }

        private void Billboard_onBillboardCompletionEvent(object sender, BillboardCompletionEventArgs e)
        {
            index++;
            exectuteNext();
        }

        public static ExecuteService Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new ExecuteService();
                }
                return privateInstance;
            }
        }

        public void startExecuteSequence(BioBotDataSets.bbt_save_protocol_referenceDataTable commands)
        {
            this.commands = commands;
            if (commands.Count > 0)
            {
                if (!commands[0].Isfk_protocolNull())
                {
                    commandsTODO = new Dictionary<int, BioBotDataSets.bbt_operationRow>();
                    BioBotDataSets.bbt_protocolRow row = DBManager.Instance.projectDataset.bbt_protocol.FindBypk_id(commands[0].fk_protocol);
                    index = 0;
                    generateList(row);
                    index = 0;
                    exectuteNext();

                }
            }
        }

        public void exectuteNext()
        {
            if (commandsTODO.Count <= index)
            {
                return;
            }

            
            EventBus.EventBus.Instance.post(new EventBus.Events.ExecutionService.ExecutionEvent(commandsTODO[index], this.billboard));
            
            //communicationService.writeData("Executing: " + .description + '\r' + '\n');
        }

        public void generateList(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            int maxSize = protocolRow.Getbbt_protocolRows().Length + protocolRow.Getbbt_stepRows().Length;
            for (int internalIndex = 1; internalIndex < maxSize + 1; internalIndex++)
            {
                BioBotDataSets.bbt_stepRow nextStepRow = getNextChildStep(protocolRow, internalIndex);
                if (nextStepRow != null)
                {
                    int operationCount = nextStepRow.Getbbt_operationRows().Length;
                    for (int i = 0; i < operationCount; i++)
                    {
                        commandsTODO.Add(index++, nextStepRow.Getbbt_operationRows()[i]);
                    }
                }


                BioBotDataSets.bbt_protocolRow nextProtocolRow = getNextChildProtocol(protocolRow, internalIndex);
                if (nextProtocolRow != null)
                {
                    generateList(nextProtocolRow);
                }
            }
        }

        public BioBotDataSets.bbt_stepRow getNextChildStep(BioBotDataSets.bbt_protocolRow protocolRow, int index)
        {
            foreach (BioBotDataSets.bbt_stepRow stepRow in protocolRow.Getbbt_stepRows())
            {
                if (stepRow.index == index)
                {
                    return stepRow;
                }
            }
            return null;
        }

        public BioBotDataSets.bbt_protocolRow getNextChildProtocol(BioBotDataSets.bbt_protocolRow protocolRow, int index)
        {
            foreach (BioBotDataSets.bbt_protocolRow protocolChildRow in protocolRow.Getbbt_protocolRows())
            {
                if (protocolChildRow.index == index)
                {
                    return protocolChildRow;
                }
            }
            return null;
        }
        
    }
}
