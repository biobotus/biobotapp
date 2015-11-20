using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Movement
{
    public class SerialCommunication
    {
        private SerialPort arduinoSerialPort;
        public event EventHandler<SerialDataReceivedEventArgs> onArduinoReceive;
        public event EventHandler<EventArgs> onConnect;
        public event EventHandler<EventArgs> onDisconnect;
        public event EventHandler<SerialErrorReceivedEventArgs> onErrorMessage;

        public SerialCommunication()
        {
            arduinoSerialPort = new SerialPort();
            arduinoSerialPort.DataReceived += ArduinoSerialPort_DataReceived;
            arduinoSerialPort.ErrorReceived += ArduinoSerialPort_ErrorReceived;
        }

        public void configure(string portName, string baudRate, string dataBits, StopBits stopBits, Parity parityBits)
        {
            lock (arduinoSerialPort)
            {
                if (arduinoSerialPort.IsOpen == true)
                {
                    arduinoSerialPort.Close();
                    ArduinoSerialPort_Disconnect(this, new EventArgs());
                }

                arduinoSerialPort.StopBits = stopBits;
                arduinoSerialPort.BaudRate = int.Parse(baudRate);
                arduinoSerialPort.DataBits = int.Parse(dataBits);
                arduinoSerialPort.PortName = portName;
                arduinoSerialPort.Parity = parityBits;

                try
                {
                    arduinoSerialPort.Open();
                    ArduinoSerialPort_Connect(this, new EventArgs());
                }
                catch (UnauthorizedAccessException e)
                {
                    disconnectArduinoSerialPort();
                }
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

        private void ArduinoSerialPort_ErrorReceived(object sender, SerialErrorReceivedEventArgs e)
        {
            if (onErrorMessage == null)
            {
                return;
            }
            onErrorMessage(this, e);
            disconnectArduinoSerialPort();
        }

        private void disconnectArduinoSerialPort()
        {
            lock (arduinoSerialPort)
            {
                if (arduinoSerialPort.IsOpen == true)
                {
                    arduinoSerialPort.Close();
                    ArduinoSerialPort_Disconnect(this, new EventArgs());
                }
            }
        }

        private void ArduinoSerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (onArduinoReceive == null)
            {
                return;
            }
            onArduinoReceive(this, e);
        }

        private void ArduinoSerialPort_Connect(object sender, EventArgs e)
        {
            if (onConnect == null)
            {
                return;
            }
            onConnect(this, e);
        }

        private void ArduinoSerialPort_Disconnect(object sender, EventArgs e)
        {
            if (onDisconnect == null)
            {
                return;
            }
            onDisconnect(this, e);
        }

    }
}
