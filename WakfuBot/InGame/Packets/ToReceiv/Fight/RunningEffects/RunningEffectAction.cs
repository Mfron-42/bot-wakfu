using PacketEditor.WakfuBot.Packets.Utility;
using ProtoBuf;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    public class RunningEffectAction : AFightBaseAction
    {

        public static PacketType packetType = PacketType.RunningEffectAction;

        public const int HEADER_SIZE = 17;
        public const int BINARY_WRITER_HEADER = 31;
        public bool Triggered;
        public RunningEffectType EffectType;
        public ByteReader SerializedEffect;
        public Dictionary<byte, ByteReader> Infos = new Dictionary<byte, ByteReader>();

        public RunningEffectActionMessage Message;

        public RunningEffectAction(ByteReader rd)
        {
            DecodeActionHeader(rd);
            Triggered = rd.ReadByte() == 1;
            EffectType = (RunningEffectType)rd.ReadInt();
            short effectSize = rd.ReadShort();
            SerializedEffect = new ByteReader(rd.Read(effectSize));
            Message = RunningEffectActionMessage.FromBytes(SerializedEffect.ReadAll());
        }
    }

    [ProtoContract]
    public class RunningEffectActionMessage
    {
        [ProtoMember(1)]
        public long SpellId;
        [ProtoMember(2)]
        public long SpellId2;
        [ProtoMember(3)]
        public long Uknow1;
        [ProtoMember(4)]
        public long Value;
        [ProtoMember(5)]
        public ProtoMapPositon Pos;
        [ProtoMember(6)]
        public long CasterId;
        [ProtoMember(7)]
        public long TargetId;
        [ProtoMember(8)]
        public SpellEffectInfo SpellEffect;
        [ProtoMember(9)]
        public long Unknow2;
        [ProtoMember(10)]
        public long Unknow3;
        [ProtoMember(11)]
        public AnimationTime FightTimeEnd;


        public static RunningEffectActionMessage FromBytes(byte[] data)
        {
            return Serializer.Deserialize<RunningEffectActionMessage>(new MemoryStream(data));
        }
    }

    [ProtoContract]
    public class ProtoMapPositon
    {
        [ProtoMember(1)]
        public long X;
        [ProtoMember(2)]
        public long Y;
        [ProtoMember(3)]
        public long Z;

        
        public MapPosition ToMapPosition()
            => new MapPosition((int)X, (int)Y, (short)Z);
    }
}
