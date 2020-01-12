using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FighterChangeStatus : AFightBaseAction
    {
        public static PacketType packetType = PacketType.FighterStatusChange;
        public long FighterId;
        public byte Status;


        public FighterChangeStatus(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out FighterId);
            rd.Read(out Status);
        }

    }
}
