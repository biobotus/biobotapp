using BioBotApp.Model.Data;
using BioBotCommunication.Serial.Utils;
using BioBotCommunication.Serial.Utils.Serial;
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
        public SerialBillboard billboard { get; private set; }
        public ExecutionEvent(BioBotDataSets.bbt_operationRow operationRow, SerialBillboard billboard)
        {
            this.operationRow = operationRow;
            this.billboard = billboard;
        }
    }
}
