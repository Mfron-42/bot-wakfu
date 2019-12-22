using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class SpellCastNotification : AFightBaseAction
    {

        public static PacketType packetType = PacketType.SpellCastNotif;
        public long CasterId;

        public bool Crit;
        public bool Miss;

        public int RefSpell;

        public RawSpell spell;
        public MapPosition pos;

        public SpellCastNotification(ByteReader rd)
        {
            DecodeActionHeader(rd);
            CasterId = rd.ReadLong();
            RefSpell = rd.ReadInt();
            Crit = rd.ReadByte() == 1;
            Miss = rd.ReadByte() == 1;
            spell = new RawSpell(rd);
            pos = new MapPosition(rd);
        }
    }
}
