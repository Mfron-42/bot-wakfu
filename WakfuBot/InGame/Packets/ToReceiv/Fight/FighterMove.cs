using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FighterMove : AFightBaseAction
    {

        public static PacketType packetType = PacketType.FighterMove;
        public long FighterId;
        public byte DirectionEnd;
        public byte MovementType;

        public List<MapPosition> Pos = new List<MapPosition>();

        public FighterMove(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out FighterId);
            rd.Read(out DirectionEnd);
            rd.Read(out MovementType);
            while (rd.Remaining() > 0)
                Pos.Add(new MapPosition(rd));
        }
    }
}
