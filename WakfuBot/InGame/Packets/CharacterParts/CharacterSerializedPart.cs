using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    public abstract class CharacterSerializedPart
    {
        public abstract CHARACTER_PART CharacterPart { get; set; }
        public abstract void FromData(ByteReader rd);
    }
}
