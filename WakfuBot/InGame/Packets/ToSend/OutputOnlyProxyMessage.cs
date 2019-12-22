using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class OutputOnlyProxyMessage
    {
        public static short HEADER_SIZE = 5;

        public static byte[] AddHeader(byte architectureTarget, SendMessageType packetId, byte[] data)
        {
            return((short)(HEADER_SIZE + data.Length)).GetBytes()
                .Concat(new[] { architectureTarget })
                .Concat(((short)packetId).GetBytes())
                .Concat(data).ToArray();
        }

        public static byte[] AddHeader(byte architectureTarget, SendMessageType packetId)
            => AddHeader(architectureTarget, packetId, new byte[0]);
    }
}
