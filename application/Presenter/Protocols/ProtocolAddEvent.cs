using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotApp.Presenter.Protocols
{
    public class ProtocolAddEvent : EventArgs
    {
        public String value { get; set; }

        public ProtocolAddEvent(String value)
        {
            this.value = value;
        }
    }
}
