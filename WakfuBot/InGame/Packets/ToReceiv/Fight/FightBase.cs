using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FightBase
    {
        public int FightId;

        public void DecodeHeader(ByteReader rd)
        {
            rd.Read(out FightId);
        }
    }
}
