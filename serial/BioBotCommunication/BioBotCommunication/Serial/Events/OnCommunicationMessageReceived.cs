using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Events
{
    public class OnCommunicationMessageReceived : EventArgs
    {
        public String data { get; private set; }
        public OnCommunicationMessageReceived(String data)
        {
            this.data = data;
        }
    }
}
