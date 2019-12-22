using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public class ClearTmpInventory : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.ClearTmpInventory;

        public static byte[] GetPacket()
        {
            return AddHeader(3, MessageType);
        }
    }
}
