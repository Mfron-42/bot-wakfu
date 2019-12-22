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
    public class CharacterAppearancePart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.APPEARANCE;
        public byte Gender;
        public byte SkinColorIndex;
        public byte HairColorIndex;
        public byte PupilColorIndex;
        public byte SkinColorFactor;
        public byte HairColorFactor;
        public byte ClothIndex;
        public byte FaceIndex;
        public short CurrentTitle;


        public override void FromData(ByteReader rd)
        {
            rd.Read(out Gender);
            rd.Read(out SkinColorIndex);
            rd.Read(out HairColorIndex);
            rd.Read(out PupilColorIndex);
            rd.Read(out SkinColorFactor);
            rd.Read(out HairColorFactor);
            rd.Read(out ClothIndex);
            rd.Read(out FaceIndex);
            rd.Read(out CurrentTitle);
        }

        public static CharacterAppearancePart Deserialize(ByteReader rd)
        {
            var ret = new CharacterAppearancePart();
            ret.FromData(rd);
            return ret;
        }
    }
}
