using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Protocol
{
    public class ProtocolSelectionChangedEvent : EventArgs
    {
        public BioBotDataSets.bbt_protocolRow Row { get; private set; }

        public ProtocolSelectionChangedEvent(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            this.Row = protocolRow;
        }
    }
}
