using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedFight.java
    public class CharacterFightPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.FIGHT;
        public int FightId;
        public bool IsKo;
        public bool IsDead;
        public bool IsSummoned;
        public bool IsFleeing;
        public byte ObstacleId;
        public bool HasSummonData;
        public SummonDataPart SummonData;


        public override void FromData(ByteReader rd)
        {
            rd.Read(out FightId);
            rd.Read(out IsKo);
            rd.Read(out IsDead);
            rd.Read(out IsSummoned);
            rd.Read(out IsFleeing);
            rd.Read(out ObstacleId);
            rd.Read(out HasSummonData);
            if (HasSummonData)
                SummonData = SummonDataPart.Deserialize(rd);

        }

        public static CharacterFightPart Deserialize(ByteReader rd)
        {
            var ret = new CharacterFightPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
