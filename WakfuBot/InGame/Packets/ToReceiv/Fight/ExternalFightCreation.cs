using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class ExternalFightCreation : AFightBaseAction
    {
        public static PacketType packetType = PacketType.ExternalFightCreation;

        public byte FightType;
        public long BattleGroundEffectBorder;
        public long BattleGroundEffectBorderUid;
        public List<long> CreatorIds = new List<long>();
        public Dictionary<long, byte> Players = new Dictionary<long, byte>();
        public byte FightStatus;

        public List<Tuple<short, short>> Partition = new List<Tuple<short, short>>();
        public byte[] SerializedMap;

        public ExternalFightCreation(ByteReader rd)
        {
            rd.Read(out FightType);
            rd.Read(out BattleGroundEffectBorder);
            rd.Read(out BattleGroundEffectBorderUid);
            for (int i = 0; i < rd.ReadByte(); i++)
                CreatorIds.Add(rd.ReadLong());
            for (int i = 0; i < rd.ReadByte(); i++)
                Players[rd.ReadLong()] = rd.ReadByte();
            rd.Read(out FightStatus);
            for (int i = 0; i < rd.ReadByte(); i++)
                Partition.Add(new Tuple<short, short>(rd.ReadShort(), rd.ReadShort()));
            SerializedMap = rd.Read(rd.Remaining());
        }
    }
}
