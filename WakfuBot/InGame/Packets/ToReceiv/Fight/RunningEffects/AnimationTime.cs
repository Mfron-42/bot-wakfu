using ProtoBuf;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    [ProtoContract]
    public class AnimationTime
    {
        [ProtoMember(1)]
        public bool NotifyUnapplicationForced;
        [ProtoMember(2)]
        public long RemainingTimeMs;
        [ProtoMember(3)]
        public RelativeFightTime TimeFight;
        [ProtoMember(4)]
        public long ExecutionStatus;
        [ProtoMember(5)]
        public bool Executed;

        public AnimationTime() { }

        public AnimationTime(ByteReader rd)
        {
            rd.Read(out NotifyUnapplicationForced);
            rd.Read(out ExecutionStatus);
            TimeFight = new RelativeFightTime(rd);
            rd.Read(out RemainingTimeMs);
            rd.Read(out Executed);
        }
    }
}

