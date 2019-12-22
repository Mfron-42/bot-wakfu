using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    class FightersPlacementPositions : FightBase
    {

        public static PacketType packetType = PacketType.FightersPlacementPositions;
        public bool teleported;

        public Dictionary<long, MapPosition> Placements = new Dictionary<long, MapPosition>();

        public FightersPlacementPositions(ByteReader rd)
        {
            DecodeHeader(rd);
            short size = rd.ReadShort();
            for (int i = 0; i < size; ++i)
            {
                Placements[rd.ReadLong()] = new MapPosition(rd);
            }
            rd.Read(out teleported);
        }
    }
}
