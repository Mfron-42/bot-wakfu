using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class TeleportAction : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.TeleportAction;
        public static byte[] UNKNOW = new byte[5];

        public static byte[] GetPacket(long elemId, int exitId)
        {
            byte[] infos = UNKNOW.Concat(elemId.GetBytes()).Concat(exitId.GetBytes()).ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
