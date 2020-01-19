using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class FreeSaoul : OutputOnlyProxyMessage
    {
        public static SendMessageType Type = SendMessageType.FreeSaoul;

        public static FreeSaoul GetPacket()
        {
            return new FreeSaoul();
        }

        public override byte[] GetBytes()
        {
            return AddHeader(3, Type, new byte[0]);
        }
    }
}
