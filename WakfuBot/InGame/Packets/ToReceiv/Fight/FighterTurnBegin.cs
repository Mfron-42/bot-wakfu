using PacketEditor.WakfuBot.Bot;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FighterTurnBegin : AFightBaseAction
    {

        public static PacketType packetType = PacketType.FighterTurnBegin;
        public long FighterId;

        public FighterTurnBegin(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out FighterId);
        }
    }
}
