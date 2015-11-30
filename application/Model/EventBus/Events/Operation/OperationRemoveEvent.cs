using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Operation
{
    public class OperationRemoveEvent : EventArgs
    {
        public int pkId { get; private set; }

        public OperationRemoveEvent(int pkId)
        {
            this.pkId = pkId;
        }
    }
}
