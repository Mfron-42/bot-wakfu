using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class MonsterStateInfo
    {
        public static PacketType packetType = PacketType.MonsterStateInfo;

        public long CharacterId;
        public byte StateId;

        public MonsterStateInfo(ByteReader rd)
        {
            rd.Read(out CharacterId);
            rd.Read(out StateId);
        }
    }
}
