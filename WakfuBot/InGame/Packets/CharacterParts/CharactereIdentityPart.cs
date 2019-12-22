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
    public class CharactereIdentityPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.IDENTITY;

        public byte CharacterType;
        public long OwnerId;

        public override void FromData(ByteReader rd)
        {
            rd.Read(out CharacterType); // char type again
            rd.Read(out OwnerId); // owner ?
        }

        public static CharactereIdentityPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereIdentityPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
