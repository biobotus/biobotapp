using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class OnCompletionEventArgs : EventArgs
    {
        public Boolean error { get; set; }
        public String message { get; set; }
        public OnCompletionEventArgs(String message)
        {
            this.message = message;
        }
    }
}
