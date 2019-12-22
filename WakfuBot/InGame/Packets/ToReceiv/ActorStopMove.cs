using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class ActorStopMove
    {
        public static PacketType packetType = PacketType.ActorStopMove;

        public long ActorId;
        public MapPosition Pos;

        public ActorStopMove(ByteReader rd)
        {
            rd.Read(out ActorId);
            Pos = new MapPosition(rd);
        }
    }
}
