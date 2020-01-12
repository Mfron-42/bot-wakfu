using PacketEditor.WakfuBot.Packets;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Structures
{
    public class SummonDataPart
    {
        public int gfxId;
        public byte sex;
        public byte clothIndex;
        public byte faceIndex;
        public byte doubleType;
        public int Direction;
        public long ParentId;
        public int invokCurrentHp;
        public long id;
        public long currentXP;
        public short cappedLevel;
        public short forcedLevel;
        public byte obstacleId;
        public string name;
        public List<Characteristiques> Characts = new List<Characteristiques>();
        public short SummomTypeId;
        public SubInvocation SubInvoc;
        
        public void FromData(ByteReader rd)
        {
            rd.Read(out SummomTypeId);
            rd.Read(out name);
            rd.Read(out invokCurrentHp);
            rd.Read(out id);
            rd.Read(out currentXP);
            rd.Read(out cappedLevel);
            rd.Read(out forcedLevel);
            rd.Read(out obstacleId);
            if (rd.ReadBool())
                SubInvoc = new SubInvocation(rd);
            if (rd.ReadBool())
            {
                rd.Read(out gfxId);
                rd.Read(out sex);
                // RawCharacteristics
                FightCharacteristiquesPart characts = FightCharacteristiquesPart.Deserialize(rd);
            }
            rd.Read(out Direction);
            rd.Read(out ParentId);
        }

        public static SummonDataPart Deserialize(ByteReader rd)
        {
            var ret = new SummonDataPart();
            ret.FromData(rd);
            return ret;
        }
        

        public class SubInvocation
        {

            public int power;
            public int gfxId;
            public byte sex;
            public byte haircolorindex;
            public byte haircolorfactor;
            public byte skincolorindex;
            public byte skincolorfactor;
            public byte pupilcolorindex;
            public byte pupilcolorFactor;
            public byte clothIndex;
            public byte faceIndex;
            public byte doubleType;
            public FightCharacteristiquesPart CharacteristiquesPart;
            public List<SpellInfo> Spells = new List<SpellInfo>();
            public Dictionary<byte, int> StuffApparence = new Dictionary<byte, int>();

            public SubInvocation(ByteReader rd)
            {
                rd.Read(out power);
                rd.Read(out gfxId);
                rd.Read(out sex);
                rd.Read(out haircolorindex);
                rd.Read(out haircolorfactor);
                rd.Read(out skincolorindex);
                rd.Read(out skincolorfactor);
                rd.Read(out pupilcolorindex);
                rd.Read(out clothIndex);
                rd.Read(out faceIndex);
                rd.Read(out doubleType);


                // RawSpellLevelInventory
                var contents = rd.ReadShort();
                for (var i = 0; i < contents; ++i)//raw spell inventory
                {
                    Spells.Add(new SpellInfo(rd));
                }
                // RawCharacteristics
                CharacteristiquesPart = FightCharacteristiquesPart.Deserialize(rd);

                var equipmentAppareances = rd.ReadShort();
                for (var i = 0; i < equipmentAppareances; ++i)
                    StuffApparence[rd.ReadByte()] = rd.ReadInt();
            }
        }
    }

}
