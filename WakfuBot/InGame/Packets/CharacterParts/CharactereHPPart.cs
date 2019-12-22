using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereHPPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.HP;
        public int MaxHp;

        public override void FromData(ByteReader rd)
        {
            rd.Read(out MaxHp);
        }

        public static CharactereHPPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereHPPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
