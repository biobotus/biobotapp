using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.ExecutionService
{
    public class ExecutionEvent : EventArgs
    {
        public BioBotDataSets.bbt_operationRow operationRow { get; private set; }
        public ExecutionEvent(BioBotDataSets.bbt_operationRow operationRow)
        {
            this.operationRow = operationRow;
        }
    }
}
