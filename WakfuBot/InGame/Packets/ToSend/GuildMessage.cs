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
    public class GuildMessage : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.GuildPrivateMessage;

        public static byte[] GetPacket(long groupId, string message)
        {
            return AddHeader(6, MessageType, groupId.GetBytes().Concat(message.GetBytes()).ToArray());
        }
    }
}
