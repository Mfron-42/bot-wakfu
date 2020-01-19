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

        public static byte[] GetPacket(int turnCount)
        {
            byte[] infos = turnCount.GetBytes();
            return AddHeader(3, FightType, infos);
        }
    }
}
