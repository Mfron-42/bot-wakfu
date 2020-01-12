using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FightEnd : AFightBaseAction
    {

        public static PacketType packetType = PacketType.FightEnd;
        public List<long> Winners = new List<long>();
        public List<long> Loosers = new List<long>();
        public List<long> Escaped = new List<long>();
        public bool Flee;

        public FightEnd(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out Flee);
            if (Flee)
                return;
            Push(rd.ReadByte(), Winners, rd);
            Push(rd.ReadByte(), Loosers, rd);
            Push(rd.ReadByte(), Escaped, rd);
        }

        public void Push(int count, List<long> list, ByteReader rd)
        {
            for (int i = 0; i < count; i++)
                list.Add(rd.ReadLong());
        }
    }
}
