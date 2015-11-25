using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.OperationReference
{
    public class OperationReferenceRemoveEvent : EventArgs
    {
        public Model.Data.BioBotDataSets.bbt_operation_referenceRow Row { get; private set; }

        public OperationReferenceRemoveEvent(Model.Data.BioBotDataSets.bbt_operation_referenceRow Row)
        {
            this.Row = Row;
        }
    }
}
