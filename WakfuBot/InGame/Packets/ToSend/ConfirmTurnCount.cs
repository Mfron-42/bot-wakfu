using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class ConfirmTurnCount : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.ConfirmTurnCount;
        public int TurnCount;

        public override byte[] GetBytes()
        {
            byte[] infos = TurnCount.GetBytes();
            return AddHeader(3, FightType, infos);
        }

        public static ConfirmTurnCount GetPacket(int turnCount)
        {
            return new ConfirmTurnCount()
            {
                TurnCount = turnCount
            };
        }

        public override string ToString()
        {
            return "Confirm turn end : " + TurnCount;
        }
    }
}
