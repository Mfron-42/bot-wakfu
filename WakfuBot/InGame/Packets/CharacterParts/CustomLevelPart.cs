using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CustomLevelPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.CUSTOM_LEVEL;
        public short Level;
        public bool IsVisible;

        public override void FromData(ByteReader rd)
        {
            rd.Read(out IsVisible);
            rd.Read(out Level);
        }

        public static CustomLevelPart Deserialize(ByteReader rd)
        {
            var ret = new CustomLevelPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
