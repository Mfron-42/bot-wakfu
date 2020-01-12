using ProtoBuf;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    [ProtoContract]
    public class RelativeFightTime
    {
        [ProtoMember(1)]
        public long TableTurn;
        [ProtoMember(2)]
        public long FighterId;
        [ProtoMember(3)]
        public bool AtEndOfTurn;

        public RelativeFightTime() { }

        public RelativeFightTime(ByteReader rd)
        {
            rd.Read(out FighterId);
            rd.Read(out TableTurn);
            rd.Read(out AtEndOfTurn);
        }
    }
}
