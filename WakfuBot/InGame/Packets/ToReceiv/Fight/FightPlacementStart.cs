using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FightPlacementStart : FightBase
    {
        public static PacketType packetType = PacketType.FightPlacementStart;

        public int RemainingTime;

        public FightPlacementStart(ByteReader rd)
        {
            DecodeHeader(rd);
            rd.Read(out RemainingTime);
        }
    }
}