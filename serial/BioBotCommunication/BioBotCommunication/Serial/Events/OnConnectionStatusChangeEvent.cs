using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Events
{
    public class OnConnectionStatusChangeEvent : EventArgs
    {
        public String status { get; private set; }

        public OnConnectionStatusChangeEvent(String status)
        {
            this.status = status;
        }
    }
}
