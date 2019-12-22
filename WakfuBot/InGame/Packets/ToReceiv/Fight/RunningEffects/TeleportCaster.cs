using PacketEditor.WakfuBot.Packets.Utility;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    [ProtoContract]
    public class TeleportCaster
    {
        [ProtoMember(1)]
        public long SpellId;
        [ProtoMember(2)]
        public long SpellId2;
        [ProtoMember(3)]
        public int SpellType;
        [ProtoMember(4)]
        public short Value;
        [ProtoMember(5)]
        public MapPosition Pos;
        [ProtoMember(6)]
        public long CasterId;
        [ProtoMember(7)]
        public long TargetId;
        [ProtoMember(8)]
        public SpellEffectInfo SpellEffect;
        [ProtoMember(9)]
        public long unknow4;
        [ProtoMember(10)]
        public long unknow5;
        [ProtoMember(11)]
        public AnimationTime FightTimeEnd;
        //public long TargetId;
        //public long CasterId;
        //public SpellEffectInfo SpellEffect;
        //public MapPosition Pos;
        //public byte Direction;

        //public RelativeFightTime FightTimeEnd;
        
        public static TeleportCaster FromProtobuf(ByteReader rd)
        {
            return Serializer.Deserialize<TeleportCaster>(new MemoryStream(rd.ReadAll()));
        }
    }
}
