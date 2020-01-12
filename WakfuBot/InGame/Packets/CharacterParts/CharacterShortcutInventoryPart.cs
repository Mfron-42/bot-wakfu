using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharacterShortcutInventory : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.SHORTCUT_INVENTORIES;
        public List<InventoryShortcut> InventoryShortcut = new List<InventoryShortcut>();
        public short InventorySize;

        public override void FromData(ByteReader rd)
        {
            var InventorySize = rd.ReadShort();
            for (var i = 0; i < InventorySize; ++i)
            {
                byte type = rd.ReadByte();
                var contentsSize = rd.ReadShort();
                for (var x = 0; x < contentsSize; ++x)
                {
                    InventoryShortcut.Add(new InventoryShortcut(rd));
                }
            }
        }

        public static CharacterShortcutInventory Deserialize(ByteReader rd)
        {
            var ret = new CharacterShortcutInventory();
            ret.FromData(rd);
            return ret;
        }
    }

    public class InventoryShortcut
    {
        public short Position;
        public byte Type;
        public long TargetId;
        public int TargetReference;
        public int GfxId;

        public InventoryShortcut(ByteReader rd)
        {
            rd.Read(out Position);
            rd.Read(out Type);
            rd.Read(out TargetId);
            rd.Read(out TargetReference);
            rd.Read(out GfxId);
        }
    }
}
