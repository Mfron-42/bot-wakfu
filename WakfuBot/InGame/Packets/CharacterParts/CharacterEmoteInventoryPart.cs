using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereEmoteInventoryPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.EMOTE_INVENTORY;

        public short InventorySize;
        public List<int> Emotes = new List<int>();

        public override void FromData(ByteReader rd)
        {
            InventorySize = rd.ReadShort();
            for (var i = 0; i < InventorySize; ++i)
                Emotes.Add(rd.ReadInt());
        }

        public static CharactereEmoteInventoryPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereEmoteInventoryPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
