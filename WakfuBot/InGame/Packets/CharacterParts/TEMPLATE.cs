using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereUNKNOWPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.CUSTOM_TEMPLATE;


        public override void FromData(ByteReader rd)
        {
        }

        public static CharactereUNKNOWPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereUNKNOWPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
