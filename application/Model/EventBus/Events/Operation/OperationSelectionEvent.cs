using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Operation
{
    public class OperationSelectionEvent : EventArgs
    {
        public BioBotDataSets.bbt_operationRow row { get; private set; }

        public OperationSelectionEvent(BioBotDataSets.bbt_operationRow row)
        {
            this.row = row;
        }
    }
}
