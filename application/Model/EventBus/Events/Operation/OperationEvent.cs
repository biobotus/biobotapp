using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Operation
{
    public class OperationEvent : EventArgs
    {
        public Model.Data.BioBotDataSets.bbt_operationRow operationRow { get; private set; }

        public OperationEvent(Model.Data.BioBotDataSets.bbt_operationRow operationRow)
        {
            this.operationRow = operationRow;
        }
    }
}
