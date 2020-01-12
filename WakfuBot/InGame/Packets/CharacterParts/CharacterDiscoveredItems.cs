using PacketEditor.WakfuBot.Packets;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CharactereDiscoveredItemsPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.DISCOVERED_ITEMS;

        public short ZaapCount;
        public List<int> Zaaps = new List<int>();
        public short DragoCount;
        public List<int> Dragos = new List<int>();
        public short BoatsCount;
        public List<int> Boats = new List<int>();
        public short CannonCount;
        public List<int> Cannons = new List<int>();
        public short PhenixCount;
        public List<int> Phenix = new List<int>();
        public int SelectedPhenix;

        public override void FromData(ByteReader rd)
        {
            ZaapCount = rd.ReadShort();
            for (var i = 0; i < ZaapCount; ++i)
                Zaaps.Add(rd.ReadInt());

            DragoCount = rd.ReadShort();
            for (var i = 0; i < DragoCount; ++i)
                Dragos.Add(rd.ReadInt());

            BoatsCount = rd.ReadShort();
            for (var i = 0; i < BoatsCount; ++i)
                Boats.Add(rd.ReadInt());

            CannonCount = rd.ReadShort();
            for (var i = 0; i < CannonCount; ++i)
                Cannons.Add(rd.ReadInt());

            PhenixCount = rd.ReadShort();
            for (var i = 0; i < PhenixCount; ++i)
                Phenix.Add(rd.ReadInt());

            rd.Read(out int SelectedPhenix);
        }

        public static CharactereDiscoveredItemsPart Deserialize(ByteReader rd)
        {
            var ret = new CharactereDiscoveredItemsPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
