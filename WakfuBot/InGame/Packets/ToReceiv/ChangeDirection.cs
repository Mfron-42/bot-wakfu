using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class ChangeDirection
    {
        public static PacketType packetType = PacketType.ChangeDirection;

        public long CharacterId;
        private byte Direction;

        public ChangeDirection(ByteReader rd)
        {
            rd.Read(out CharacterId);
            rd.Read(out Direction);
        }
    }
}
