using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.UknowUtility
{
    public class ItemIdCacheUpdate
    {
        public static PacketType packetType = PacketType.ItemIdCacheUpdate;


        public bool Squashing;
        public List<long> uids = new List<long>();

        public ItemIdCacheUpdate(ByteReader rd)
        {
            Squashing = rd.ReadByte() == 0;
            rd.Read(out byte uidCount);
            for (int i = 0; i < uidCount; i++)
                uids.Add(rd.ReadLong());
        }
    }
}
