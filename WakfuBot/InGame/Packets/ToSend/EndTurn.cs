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
        public long CharacterId;
        public short TableTurnCount;

        public static EndTurn GetPacket(long characterId, short tableTurnCount)
        {
            return new EndTurn
            {
                CharacterId = characterId,
                TableTurnCount = tableTurnCount
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos =
                CharacterId.GetBytes()
                .Concat(TableTurnCount.GetBytes())
                .ToArray();
            return AddHeader(3, FightType, infos);
        }

        public override string ToString()
        {
            return "End turn of " + CharacterId + " table count : " + TableTurnCount;
        }
    }
}
