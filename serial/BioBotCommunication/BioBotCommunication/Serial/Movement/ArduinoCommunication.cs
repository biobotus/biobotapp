using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class ArduinoCommunication : SerialPort
    {
        public event EventHandler<SerialDataReceivedEventArgs> onArduinoReceive;
        public event EventHandler<EventArgs> onConnect;
        public event EventHandler<EventArgs> onDisconnect;
        public event EventHandler<SerialErrorReceivedEventArgs> onErrorMessage;

        private static ArduinoCommunication privateInstance;


        public static ArduinoCommunication Instance
        {
            get
            {
                if (privateInstance == null)
                {
                    privateInstance = new ArduinoCommunication();
                }
                return privateInstance;
            }
        }

        private ArduinoCommunication()
        {
            /*
            arduinoSerialPort = new SerialPort();
            arduinoSerialPort.DataReceived += ArduinoSerialPort_DataReceived;
            arduinoSerialPort.ErrorReceived += ArduinoSerialPort_ErrorReceived;
            */
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
            }
        }
    }



}
