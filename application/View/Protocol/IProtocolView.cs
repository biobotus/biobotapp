using BioBotApp.Presenter.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.View.Protocol
{
    public interface IProtocolView
    {
        event EventHandler<ProtocolAddEvent> OnProtocolAddEvent;

        String GetProtocolName{ get; }

        void LoadProtocolName(String protocolName);
    }
}
