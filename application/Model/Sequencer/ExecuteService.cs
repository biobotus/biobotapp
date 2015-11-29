using BioBotApp.Model.Data;
using BioBotApp.Model.EventBus;
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
        private Communication.CommunicationService communicationService;
        BioBotDataSets.bbt_save_protocol_referenceDataTable commands;
        Dictionary<int, BioBotDataSets.bbt_stepRow> commandsTODO;
        int index = 0;

        private ExecuteService()
        {
            this.dbManager = DBManager.Instance;
            communicationService = Communication.CommunicationService.Instance;
            commandsTODO = new Dictionary<int, BioBotDataSets.bbt_stepRow>();
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
                    commandsTODO = new Dictionary<int, BioBotDataSets.bbt_stepRow>();
                    BioBotDataSets.bbt_protocolRow row = DBManager.Instance.projectDataset.bbt_protocol.FindBypk_id(commands[0].fk_protocol);
                    generateList(row);
                    index = 0;
                    exectuteNext();
                    
                }
            }
        }

        public void exectuteNext()
        {
            if(commandsTODO.Count <= index)
            {
                return;
            }
            Console.WriteLine("Executing: " + commandsTODO[index].description);
            communicationService.writeData("Executing: " + commandsTODO[index].description + '\r' + '\n');
        }

        public void generateList(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            int maxSize = protocolRow.Getbbt_protocolRows().Length + protocolRow.Getbbt_stepRows().Length;
            for (int internalIndex = 1; internalIndex < maxSize+1; internalIndex++)
            {
                BioBotDataSets.bbt_stepRow nextStepRow = getNextChildStep(protocolRow, internalIndex);
                if (nextStepRow != null)
                {
                    commandsTODO.Add(index++, nextStepRow);
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
        [Model.EventBus.Subscribe]
        public void onCompletionProtocolCommand(BioBotCommunication.Serial.Events.OnConnectionStatusChangeEvent e)
        {
            index++;
            exectuteNext();
        }
    }
}
