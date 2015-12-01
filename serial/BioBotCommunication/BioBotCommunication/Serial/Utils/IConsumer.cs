using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils
{
    public interface IConsumer
    {
        void notifyValue(Boolean value);
        Boolean objectEquals(Object value, Object compare);
        void stopThread();
    }
}
