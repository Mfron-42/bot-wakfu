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

        public static byte[] GetPacket(MapPosition pos, long characterId)
        {
            byte[] infos = characterId.GetBytes().Concat(pos.GetBytes()).ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}