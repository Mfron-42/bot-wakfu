using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public sealed class FightPlacement : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.FightPlacement;
        public MapPosition MapPosition;
        public long CharacterId;

        public static FightPlacement GetPacket(MapPosition pos, long characterId)
        {
            return new FightPlacement
            {
                MapPosition = pos,
                CharacterId = characterId
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = CharacterId.GetBytes().Concat(MapPosition.GetBytes()).ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}