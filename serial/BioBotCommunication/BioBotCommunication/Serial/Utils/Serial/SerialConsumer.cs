using BioBotCommunication.Serial.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Serial
{
    public class SerialConsumer : AbstractConsumer
    {
        SerialCommunication communication;

        public SerialConsumer(Billboard billboard, String waitValue, String writeValue) : base(billboard,waitValue, writeValue)
        {
            communication = SerialCommunication.Instance;
        }

        public override bool objectEquals(object value, object compare)
        {
            String valueString = value as String;
            String compareString = compare as String;
            if (valueString == null || compareString == null) return false;
            return valueString.Contains(compareString);
        }

        public override void writeLine(object writeValue)
        {
            if (!(writeValue is String)) return;
            Console.WriteLine("Serial port write line: " + writeValue as String);
            communication.WriteLine(writeValue as String);
        }
    }
}
