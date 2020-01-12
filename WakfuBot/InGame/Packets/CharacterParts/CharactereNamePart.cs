using PacketEditor.WakfuBot.Packets;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereNamePart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.NAME;
        public string Name;

        public override void FromData(ByteReader rd)
        {
            rd.Read(out Name);
        }

        public static CharactereNamePart Deserialize(ByteReader rd)
        {
            var ret = new CharactereNamePart();
            ret.FromData(rd);
            return ret;
        }
    }
}
