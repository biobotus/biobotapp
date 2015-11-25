using BioBotApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Model.EventBus.Events.Protocol
{
    public class ProtocolAddEvent : EventArgs
    {
        public BioBotDataSets.bbt_protocolRow Row { get; private set; }

        public ProtocolAddEvent(BioBotDataSets.bbt_protocolRow protocolRow)
        {
            this.Row = protocolRow;
        }
    }
}
