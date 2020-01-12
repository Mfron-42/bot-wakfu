using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.Utility
{
    public class RawSpell
    {
        public long SpellId;
        public int RefSpell;
        public ushort Level;


        public RawSpell(ByteReader rd)
        {
            rd.Read(out SpellId);
            rd.Read(out RefSpell);
            rd.Read(out Level);
        }
    }
}
