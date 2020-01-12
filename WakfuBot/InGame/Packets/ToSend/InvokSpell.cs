using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class InvokSpell : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.InvokSpell;

        public static byte[] GetPacket(long characterId, long spellId, MapPosition pos)
            => GetPacket(characterId, spellId, pos.X, pos.Y, pos.Z);

        public static byte[] GetPacket(long characterId, long spellId, int posX, int posY, short posZ)
        {
            byte[] infos =
                characterId.GetBytes()
                .Concat(spellId.GetBytes())
                .Concat(posX.GetBytes())
                .Concat(posY.GetBytes())
                .Concat(posZ.GetBytes())
                .ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
