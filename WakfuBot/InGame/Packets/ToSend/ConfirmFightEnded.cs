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
        public static SendMessageType FightType = SendMessageType.ConfirmFightEnded;
        public int FightId;

        public static ConfirmFightEnded GetPacket(int fightId)
        {
            return new ConfirmFightEnded
            {
                FightId = fightId
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = FightId.GetBytes().Concat(new byte[] { 1 }).ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
