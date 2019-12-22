using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharacterIDPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.ID;
        public long CharacterId;

        public override void FromData(ByteReader rd)
        {
            rd.Read(out CharacterId);
        }

        public static CharacterIDPart Deserialize(ByteReader rd)
        {
            var ret = new CharacterIDPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
