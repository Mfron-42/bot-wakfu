using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Structures.Character;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    public class Summon
    {
        public SpellEffectInfo SpellEffect;
        public long SourceId;
        public long TargetId;
        public RelativeFightTime FightTimeEnd;
        public bool IsOwnController;
        public RawInvocationCharacteristic Characteristic;
        public RawProperties Properties;
        public MapPosition Pos;
        public long Id;
        public byte TeamId;

        public Summon(Dictionary<byte, ByteReader> infos)
        {
            SpellEffect = new SpellEffectInfo(infos[0]);
            infos[1].Read(out SourceId);
            infos[2].Read(out TargetId);
            infos[3].Read(out IsOwnController);
            Characteristic = new RawInvocationCharacteristic(infos[3]);
            Properties = new RawProperties(infos[3]);
            infos[3].Read(out TeamId);
            //Infos[4].Read(out Unknow);
            FightTimeEnd = new RelativeFightTime(infos[5]);
            Pos = SpellEffect.CasterPos.ToMapPosition();
            Id = Characteristic.SummonId;
        }
    }

    public class RawProperties
    {

        public Dictionary<byte, byte> Props = new Dictionary<byte, byte>();
        public RawProperties(ByteReader rd)
        {
            rd.Read(out short size);
            for (int i = 0; i < size; ++i)
                Props[rd.ReadByte()] = rd.ReadByte();
        }
    }

    public class RawInvocationCharacteristic
    {
        public BREED TypeId;
        public string Name;
        public int CurrentHp;
        public long SummonId;
        public long CurrentXP;
        public short CappedLevel;
        public short ForcedLevel;
        public byte ObstacleId;
        public int Direction;
        public long SummonerId;

        public RawInvocationCharacteristic(ByteReader rd)
        {
            TypeId = (BREED)rd.ReadShort();
            rd.Read(out Name);
            rd.Read(out CurrentHp);
            rd.Read(out SummonId);
            rd.Read(out CurrentXP);
            rd.Read(out CappedLevel);
            rd.Read(out ForcedLevel);
            rd.Read(out ObstacleId);
            rd.Read(out bool doubleInvokPresent);
            rd.Read(out bool doubleImageInvokPresent);
            rd.Read(out Direction);
            rd.Read(out SummonerId);
        }
    }
}
