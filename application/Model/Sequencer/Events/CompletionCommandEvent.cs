using BioBotApp.Model.Data;
using BioBotApp.Model.Sequencer.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.Sequencer.Events
{
    public class CompletionCommandEvent : EventArgs
    {
        public ICommand command { get; private set; }
        public Model.Data.BioBotDataSets.bbt_operationRow operationRow { get; private set; }

        public CompletionCommandEvent(ICommand command, BioBotDataSets.bbt_operationRow operationRow)
        {
            this.command = command;
            this.operationRow = operationRow;
        }
    }
}
