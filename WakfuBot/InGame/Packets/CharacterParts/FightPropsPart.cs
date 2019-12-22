using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class FightPropsPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.FIGHT_PROPERTIES;
        public bool HasInformations;
        public short PropsSize;
        public List<(byte unknow1, byte unknow2)> FightProps = new List<(byte unknow1, byte unknow2)>();

        public override void FromData(ByteReader rd)
        {
            HasInformations = rd.ReadBool();
            if (!HasInformations)
                return;
            PropsSize = rd.ReadShort();
            for (var i = 0; i < PropsSize; ++i)
                FightProps.Add((rd.ReadByte(), rd.ReadByte()));
        }

        public static FightPropsPart Deserialize(ByteReader rd)
        {
            var ret = new FightPropsPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
