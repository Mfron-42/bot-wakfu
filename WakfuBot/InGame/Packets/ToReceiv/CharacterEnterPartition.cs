using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class CharacterEnterPartition
    {
        public static PacketType packetType = PacketType.CharacterEnterPartition;

        public int posX;
        public int posY;

        public CharacterEnterPartition(ByteReader rd)
        {
            rd.Read(out posX);
            rd.Read(out posY);
        }
    }
}
