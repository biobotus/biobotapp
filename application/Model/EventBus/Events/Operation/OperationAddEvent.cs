using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Operation
{
    public class OperationAddEvent : EventArgs
    {
        public Model.Data.BioBotDataSets.bbt_operationRow operationRow { get; private set; }

        public OperationAddEvent(Model.Data.BioBotDataSets.bbt_operationRow operationRow)
        {
            this.operationRow = operationRow;
        }
    }
}
