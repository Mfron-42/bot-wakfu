using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class ConfirmFightEnded : OutputOnlyProxyMessage
    {
        private static SendMessageType fightType = SendMessageType.ConfirmFightEnded;

        public static SendMessageType FightType { get => fightType; set => fightType = value; }

        public static byte[] GetPacket(int fightId)
        {
            byte[] infos = fightId.GetBytes().Concat(new byte[] { 1 }).ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
