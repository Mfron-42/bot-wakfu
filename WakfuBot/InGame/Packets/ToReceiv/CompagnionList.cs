using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.InGame.Packets.ToSend;
using WakfuBot.WakfuBot.Packets.ToSend;
using WakfuBot.WakfuBot.Structures.Character;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class CompagnionList
    {
        public static PacketType packetType = PacketType.CompagnionList;

        public List<CompagnionInfos> Compagnions = new List<CompagnionInfos>();

        public long ActorId;
        public MapPosition Pos;

        public CompagnionList(ByteReader rd)
        {
            byte size = rd.ReadByte();
            for (byte i = 0; i < size; i++)
                Compagnions.Add(new CompagnionInfos(rd));
        }
    }

    public class CompagnionInfos : ISelectableCharacter
    {
        public long Id { get; set; }
        public BREED Breed { get; set; }
        public long OwnerId;
        public long Xp;
        public string Name;
        public bool IsUnlocked;
        public int CurrentHp;
        public int MaxHp;
        public int SerializationVersion;
        public byte[] Unknow;

        public CompagnionInfos(ByteReader rd)
        {
            Id = rd.ReadLong();
            Breed = (BREED)rd.ReadShort();
            rd.Read(out OwnerId);
            rd.Read(out Xp);
            rd.Read(out Name);
            rd.Read(out IsUnlocked);
            rd.Read(out CurrentHp);
            rd.Read(out MaxHp);
            rd.Read(out SerializationVersion);
            Unknow = rd.Read(4);
        }

        public IPacket GetSelectionPacket()
            => AddCompagnionRequest.GetPacket(Id);

        public string DisplayName()
        {
            return "MM : " + Breed;
        }
    }
}
