using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereBreedPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.BREED;
        public BREED Breed;

        public override void FromData(ByteReader rd)
        {
            Breed = (BREED)rd.ReadShort();
        }

        public static CharactereBreedPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereBreedPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
