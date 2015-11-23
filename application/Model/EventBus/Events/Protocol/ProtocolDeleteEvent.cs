using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Protocol
{
    public class ProtocolDeleteEvent
    {
        public int rowId { get; private set; }
        public ProtocolDeleteEvent(int rowId)
        {
            this.rowId = rowId;
        }
    }
}
