using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedCharacteristics.java
    public class FightCharacteristiquesPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.FIGHT_CHARACTERISTICS;
        public Dictionary<CHARACTERISTIQUES, Characteristiques> Characteristiques = new Dictionary<CHARACTERISTIQUES, Characteristiques>();
        
        public override void FromData(ByteReader rd)
        {
            short count = rd.ReadShort();
            for(int i = 0; i < count; i++)
            {
                byte type = rd.ReadByte();
                Characteristiques[(CHARACTERISTIQUES)type] = new Characteristiques(rd);
            }
        }

        public Characteristiques Get(CHARACTERISTIQUES carac)
        {
            Characteristiques.TryGetValue(carac, out Characteristiques caracs);
            return caracs;
        }

        public int GetCurrent(CHARACTERISTIQUES carac, int defaultValue = 0)
            => Get(carac)?.Current ?? defaultValue;

        public static FightCharacteristiquesPart Deserialize(ByteReader rd)
        {
            var ret = new FightCharacteristiquesPart();
            ret.FromData(rd);
            return ret;
        }
    }

    public class Characteristiques
    {
        public int Current;
        public int Min;
        public int Max;
        public int MaxPercentModifier;

        public Characteristiques(ByteReader rd)
        {
            rd.Read(out Current);
            rd.Read(out Min);
            rd.Read(out Max);
            rd.Read(out MaxPercentModifier);
        }
    }
}
