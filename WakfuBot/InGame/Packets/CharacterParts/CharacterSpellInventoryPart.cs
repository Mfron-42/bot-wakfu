using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharacterSpellInventoryPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.SPELL_INVENTORY;
        public short InventorySize;
        public List<SpellInfo> Spells = new List<SpellInfo>();

        public override void FromData(ByteReader rd)
        {
            InventorySize = rd.ReadShort();
            for (var i = 0; i < InventorySize; ++i)
                Spells.Add(new SpellInfo(rd));
        }

        public static CharacterSpellInventoryPart Deserialize(ByteReader rd)
        {
            var ret = new CharacterSpellInventoryPart();
            ret.FromData(rd);
            return ret;
        }
    }

    public class SpellInfo
    {
        public long UniqueId;
        public int SpellId;
        public short Level;

        public SpellInfo(ByteReader rd)
        {
            rd.Read(out UniqueId);
            rd.Read(out SpellId);
            rd.Read(out Level);
        }
    }
}
