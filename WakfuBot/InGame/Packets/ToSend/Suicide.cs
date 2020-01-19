using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public class Suicide : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.Suicide;

        public static Suicide GetPacket()
        {
            return new Suicide();
        }

        public override byte[] GetBytes()
        {
            return AddHeader(3, MessageType);
        }
    }
}
