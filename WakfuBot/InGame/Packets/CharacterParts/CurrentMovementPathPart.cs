using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CurrentMovementPathPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.CURRENT_MOVEMENT_PATH;

        public bool HasInformations;
        public byte EncodedPathSize;
        public byte[] EncodedPath;

        public override void FromData(ByteReader rd)
        {
            HasInformations = rd.ReadBool();
            if (!HasInformations)
                return;
            EncodedPathSize = rd.ReadByte();
            EncodedPath = rd.Read(EncodedPathSize);
        }

        public static CurrentMovementPathPart Deserialize(ByteReader rd)
        {
            var ret = new CurrentMovementPathPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
