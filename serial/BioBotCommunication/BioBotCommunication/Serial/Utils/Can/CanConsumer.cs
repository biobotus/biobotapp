using PCAN;
using Peak.Can.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BioBotCommunication.Serial.Utils.Can
{
    public class CanConsumer : AbstractConsumer
    {
        private PCAN.PCANCom communication;

        public CanConsumer(Billboard billboard, byte[] waitValue, byte[] writeValue) : base(billboard, waitValue, writeValue)
        {
            communication = PCAN.PCANCom.Instance;
        }

        public override bool objectEquals(object value, object compare)
        {
            byte[] byteValue = value as byte[];
            byte[] compareByte = compare as byte[];
            if (byteValue == null || compare == null) return false;

            for (int i = 0; i < byteValue.Length; i++)
            {
                if (byteValue[i] != compareByte[i]) return false;
            }


            return true;
        }

        public override void writeLine(object writeValue)
        {

            if (!(writeValue is byte[])) return;
            byte[] messageToSend = writeValue as byte[];
            TPCANMsg CANMsg = new TPCANMsg();
            CANMsg.DATA = new byte[8];
            CANMsg.DATA[0] = messageToSend[0];
            CANMsg.DATA[1] = messageToSend[1];
            CANMsg.DATA[2] = messageToSend[2];
            CANMsg.DATA[3] = messageToSend[3];
            CANMsg.DATA[4] = messageToSend[4];
            CANMsg.DATA[5] = messageToSend[5];
            CANMsg.DATA[6] = messageToSend[6];
            CANMsg.DATA[7] = messageToSend[7];
            CANMsg.ID = Convert.ToUInt32(messageToSend[8]);
            Console.WriteLine("Can send: ");
            PCANCom.Instance.printPacket(messageToSend);
            CANQueue.Instance.add(CANMsg);
            CANQueue.Instance.executeFirst();
        }
    }
}
