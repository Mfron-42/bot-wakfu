using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class PublicCaractsPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.PUBLIC_CHARACTERISTICS;

        public short DataSize;
        public byte[] Data;

        public override void FromData(ByteReader rd)
        {
            DataSize = rd.ReadShort();
            Data = rd.Read(DataSize);
        }

        public static PublicCaractsPart Deserialize(ByteReader rd)
        {
            var ret = new PublicCaractsPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
