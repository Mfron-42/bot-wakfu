using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using System.Linq;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class GroupPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.GROUP;

        public long GroupId;
        public short MemberCount;
        public List<(short unknow1, short level)> Group = new List<(short unknow1, short level)>();

        public override void FromData(ByteReader rd)
        {
            rd.Read(out GroupId);
            MemberCount = rd.ReadShort();
            for (var i = 0; i < MemberCount; ++i)
                Group.Add((rd.ReadShort(), rd.ReadShort()));
        }

        public int GroupLevel() => Group.Sum(c => c.level);

        public static GroupPart Deserialize(ByteReader rd)
        {
            var ret = new GroupPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
