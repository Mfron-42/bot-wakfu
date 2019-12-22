using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CollectPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.COLLECT;

        public short AivableActionsCount;
        public List<int> AivableActions = new List<int>();

        public override void FromData(ByteReader rd)
        {
            AivableActionsCount = rd.ReadShort();
            for (var i = 0; i < AivableActionsCount; ++i)
                AivableActions.Add(rd.ReadInt());
        }

        public static CollectPart Deserialize(ByteReader rd)
        {
            var ret = new CollectPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
