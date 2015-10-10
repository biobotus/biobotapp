using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class AutoConnectArduino
    {
        public static void autoconnect(string portName, string baudRate, string dataBits, StopBits stopBits, Parity parityBits)
        {
            ArduinoCommunication.Instance.configure(portName, baudRate, dataBits, stopBits, parityBits);
            ArduinoCommunication.Instance.Write("aa");
        }
    }
}
