using PacketEditor.WakfuBot.Packets.Utility;
using ProtoBuf;
using System.Linq;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    [ProtoContract]
    public class SpellEffectInfo
    {
        [ProtoMember(15)]
        public ProtoMapPositon CasterPos;
        [ProtoMember(23)]
        public ProtoMapPositon TargetPos;
        [ProtoMember(33)]
        public long Spell;
        [ProtoMember(70)]
        public PositionInfos PositionInfos;


        public long Uid;
        public int Value;

        public SpellEffectInfo() { }

        public SpellEffectInfo(ByteReader rd)
        {
            rd.Read(out Uid);
            rd.Read(out Uid);
            rd.Read(out Spell);
            //rd.Read(out Pos);
            rd.Read(out Value);
        }
    }

    [ProtoContract]
    public class PositionInfos
    {
        [ProtoMember(1)]
        public ProtoMapPositon[] Positions;

        public MapPosition Last()
        {
            return Positions?.LastOrDefault()?.ToMapPosition();
        }
    }
}

