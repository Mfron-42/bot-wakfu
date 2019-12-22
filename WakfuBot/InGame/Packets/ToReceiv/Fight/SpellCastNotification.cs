using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FightActionSequenceExecute : FightBase
    {
        public static PacketType packetType = PacketType.FightActionSequenceExecute;

        public FightActionSequenceExecute(ByteReader rd)
        {
            DecodeHeader(rd);
        }
    }
}
