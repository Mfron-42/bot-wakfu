using PacketEditor.WakfuBot.Packets.ToSend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Structures;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FightCreation : AFightBaseAction
    {
        public static PacketType packetType = PacketType.FightCreation;

        public byte FightType;
        public int WorldId;
        public long BattlegroundBorderEffect;
        public byte[] SerializedMap;
        public byte[] TimeLineSerialized;
        public long AttackerID;
        public long DefenderID;
        public bool ForReconnection;
        public List<FighterCreated> Fighters = new List<FighterCreated>();
        public List<EffectUser> EffectsUsers = new List<EffectUser>();
        public List<byte> LockedTeams = new List<byte>();
        public List<byte[]> SerializedEffectArea = new List<byte[]>();

        public FightCreation(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out FightType);
            rd.Read(out WorldId);
            rd.Read(out BattlegroundBorderEffect);
            SerializedMap = rd.Read(rd.ReadInt());
            TimeLineSerialized = rd.Read(rd.ReadShort());
            rd.Read(out AttackerID);
            rd.Read(out DefenderID);
            rd.Read(out ForReconnection);
            byte fighterCount = rd.ReadByte();
            for (int i = 0; i < fighterCount; i++)
                Fighters.Add(new FighterCreated(rd, ForReconnection));
            byte effectCount = rd.ReadByte();
            for (int i = 0; i < effectCount; i++)
                EffectsUsers.Add(new EffectUser(rd));

            byte lockedTeamCount = rd.ReadByte();
            for (int i = 0; i < lockedTeamCount; i++)
                LockedTeams.Add(rd.ReadByte());

            int serializedEffectCount = rd.ReadInt();
            for (int i = 0; i < serializedEffectCount; i++)
                SerializedEffectArea.Add(rd.Read(rd.ReadInt()));
        }
    }

    public class FighterCreated
    {
        public long FighterId;
        public byte FighterType;
        public byte TeamId;
        public byte PlayState;
        public byte[] SerializedFighterDatas;
        public byte[] SerializedEffectUserDatas;
        public FightCharacteristiquesPart CharacteristiquesPart;
        public CharacterFightPart FightInfoPart;
        public ChatacterPositionPart ChatacterPositionPart;

        public FighterCreated(ByteReader rd, bool ForReconnection)
        {
            rd.Read(out FighterId);
            rd.Read(out FighterType);
            rd.Read(out TeamId);
            rd.Read(out PlayState);
            if (!ForReconnection)
            {
                short serializedDataSize = rd.ReadShort();
                SerializedFighterDatas = rd.Read(serializedDataSize);
                var fighterDataReader = new ByteReader(SerializedFighterDatas);
                byte serializationType = fighterDataReader.ReadByte();
                ChatacterPositionPart = ChatacterPositionPart.Deserialize(fighterDataReader);
                FightInfoPart = CharacterFightPart.Deserialize(fighterDataReader);
                CharacteristiquesPart = FightCharacteristiquesPart.Deserialize(fighterDataReader);


                short serializedEffectSize = rd.ReadShort();
                SerializedEffectUserDatas = rd.Read(serializedEffectSize);
            }
        }
    }

    public class EffectUser
    {
        public byte EffectTypeId;
        public long EffectId;

        public EffectUser(ByteReader rd)
        {
            rd.Read(out EffectTypeId);
            rd.Read(out EffectId);
        }
    }
}
