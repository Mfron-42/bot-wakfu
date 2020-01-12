using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class ActorMove
    {
        public static PacketType packetType = PacketType.ActorMove;

        public long ActorId;
        public MapPosition Pos;
        private byte Direction;

        public ActorMove(ByteReader rd)
        {
            rd.Read(out ActorId);
            Pos = new MapPosition(rd);
            rd.Read(out Direction);
        }
    }
}
