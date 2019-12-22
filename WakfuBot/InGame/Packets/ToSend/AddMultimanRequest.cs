using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public class AddCompagnionRequest : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.AddMultiman;

        public static byte[] GetPacket(long multimanId)
        {
            return AddHeader(3, MessageType, multimanId.GetBytes());
        }
    }
}
