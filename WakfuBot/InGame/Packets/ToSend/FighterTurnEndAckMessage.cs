using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class FighterTurnEndAckMessage : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.ConfirmTurnCount;
        public int TurnCount;

        public override byte[] GetBytes()
        {
            byte[] infos = TurnCount.GetBytes();
            return AddHeader(3, FightType, infos);
        }

        public static FighterTurnEndAckMessage GetPacket(int turnCount)
        {
            return new FighterTurnEndAckMessage()
            {
                TurnCount = turnCount
            };
        }
    }
}
