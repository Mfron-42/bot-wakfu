using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FighterTurnEnd : AFightBaseAction
    {

        public static PacketType packetType = PacketType.FighterTurnEnd;
        public long FighterId;
        public int TimeScoreGain;
        public int AddedRemainingSeconds;

        public FighterTurnEnd(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out FighterId);
            rd.Read(out TimeScoreGain);
            rd.Read(out AddedRemainingSeconds);
        }
    }
}
