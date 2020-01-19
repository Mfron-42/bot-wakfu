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
        public long CharacterId;
        public long SpellId;
        public MapPosition TargetCell;

        public static InvokSpell GetPacket(long characterId, long spellId, MapPosition targetCell)
        {

            return new InvokSpell
            {
                CharacterId = characterId,
                SpellId = spellId,
                TargetCell = targetCell
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos =
                CharacterId.GetBytes()
                .Concat(SpellId.GetBytes())
                .Concat(TargetCell.GetBytes())
                .ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
