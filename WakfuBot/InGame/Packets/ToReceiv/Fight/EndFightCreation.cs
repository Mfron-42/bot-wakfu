using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class EndFightCreation 
    {
        public static PacketType packetType = PacketType.EndFightCreation;

        public int FightId;

        public EndFightCreation(ByteReader rd)
        {
            rd.Read(out FightId);
        }
    }
}
