using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class SerialCommunication : SerialPort
    {
        private static SerialCommunication instance;
        public static SerialCommunication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialCommunication();
                }
                return instance;
            }
        }

        public void configure(string portName, string baudRate, string dataBits, StopBits stopBits, Parity parityBits)
        {
            if (IsOpen == true)
            {
                Close();
            }

            StopBits = stopBits;
            BaudRate = int.Parse(baudRate);
            DataBits = int.Parse(dataBits);
            PortName = portName;
            Parity = parityBits;

            try
            {
                Open();
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        
    }
}
