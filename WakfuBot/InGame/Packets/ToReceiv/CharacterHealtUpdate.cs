using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class CharacterHealtUpdate
    {
        public static PacketType packetType = PacketType.CharacterHealtUpdate;

        public int Healt;
        public int HealtRegen;
   

        public CharacterHealtUpdate(ByteReader rd)
        {
            rd.Read(out Healt);
            rd.Read(out HealtRegen);
        }
    }
}
