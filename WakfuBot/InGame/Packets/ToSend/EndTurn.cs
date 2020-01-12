using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class EndTurn : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.EndTurn;

        public static byte[] GetPacket(long characterId, short tableTurnCount)
        {
            byte[] infos =
                characterId.GetBytes()
                .Concat(tableTurnCount.GetBytes())
                .ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
