using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class InteractiveElementSpawn
    {
        public static PacketType packetType = PacketType.InteractiveElementSpawn;

        public List<InteractiveElement> Elements = new List<InteractiveElement>();

        public InteractiveElementSpawn(ByteReader rd)
        {
            rd.Read(out short count);
            for (int i = 0; i < count; i++)
                Elements.Add(new InteractiveElement(rd));
        }
    }

    public class InteractiveElement
    {

        public long Id;
        public byte[] Infos;

        public InteractiveElement(ByteReader rd)
        {
            rd.Read(out Id);
            Infos = rd.Read(rd.ReadUShort());
        }
    }
}
