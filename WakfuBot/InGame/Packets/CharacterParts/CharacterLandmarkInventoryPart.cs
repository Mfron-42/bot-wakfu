using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereLandmarkInventoryPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.LANDMARK_INVENTORY;
        public short InventorySize;
        public List<byte> Landmarks = new List<byte>();

        public override void FromData(ByteReader rd)
        {
           InventorySize = rd.ReadShort();
            for (var i = 0; i < InventorySize; ++i)
                Landmarks.Add(rd.ReadByte());
        }

        public static CharactereLandmarkInventoryPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereLandmarkInventoryPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
