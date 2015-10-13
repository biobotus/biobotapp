using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class ArduinoCommunication
    {
        public SerialPort arduinoSerialPort;
        public event EventHandler<SerialDataReceivedEventArgs> onArduinoReceive;

        public ArduinoCommunication()
        {
            arduinoSerialPort = new SerialPort();
            arduinoSerialPort.DataReceived += ArduinoSerialPort_DataReceived;
        }

        private void ArduinoSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (onArduinoReceive != null)
            {
                onArduinoReceive(this, e);
            }
        }

        public void configure(string portName, string baudRate, string dataBits, StopBits stopBits, Parity parityBits)
        {
            lock (arduinoSerialPort)
            {
                arduinoSerialPort.StopBits = stopBits;
                arduinoSerialPort.BaudRate = int.Parse(baudRate);
                arduinoSerialPort.DataBits = int.Parse(dataBits);
                arduinoSerialPort.PortName = portName;
                arduinoSerialPort.Parity = parityBits;

                if (arduinoSerialPort.IsOpen == true)
                {
                    arduinoSerialPort.Close();
                }
                arduinoSerialPort.Open();
            }
        }

        public void write(String data)
        {
            lock (arduinoSerialPort)
            {
                if (arduinoSerialPort.IsOpen)
                {
                    arduinoSerialPort.Write(data);
                }
            }
        }
    }
}
