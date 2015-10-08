using BioBotApp.View.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter
{
    public class ProtocolPresenter
    {
        private IProtocolView protocolView;
        private int indexTest = 0;

        public ProtocolPresenter(IProtocolView protocolView)
        {
            this.protocolView = protocolView;
            
            this.protocolView.OnProtocolAddEvent += ProtocolView_OnProtocolAddEvent;
        }

        private void ProtocolView_OnProtocolAddEvent(object sender, Protocols.ProtocolAddEvent e)
        {
            protocolView.LoadProtocolName(e.value + ": " + indexTest++);
        }
    }
}
