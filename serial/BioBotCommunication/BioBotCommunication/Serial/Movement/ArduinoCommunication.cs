using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace BioBotCommunication.Serial.Movement
{
    public class ArduinoCommunication : SerialPort
    {
        private static ArduinoCommunication instance;
        
        public static ArduinoCommunication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ArduinoCommunication();
                }
                return instance;
            }
        }

        public void configure(string portName, string baudRate, string dataBits, StopBits stopBits, Parity parityBits)
        {
            lock (this)
            {
                this.StopBits = stopBits;
                this.BaudRate = int.Parse(baudRate);
                this.DataBits = int.Parse(dataBits);
                this.PortName = portName;
                this.Parity = parityBits;

                if (this.IsOpen == true)
                {
                    this.Close();
                }
            }
        }
    }
}
