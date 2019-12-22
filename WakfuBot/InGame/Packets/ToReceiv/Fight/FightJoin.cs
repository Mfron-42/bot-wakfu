using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Structures;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class FightJoin : FightBase
    {

        public static PacketType packetType = PacketType.FightJoin;
        public long FighterId;
        public byte FightType;
        public byte TeamId;
        public ChatacterPositionPart ChatacterPositionPart;
        public CharacterFightPart FightInfoPart;
        public FightCharacteristiquesPart CharacteristiquesPart;
        public byte[] SerializedFighterInfo;
        public byte[] SerializedEffects;

        public FightJoin(ByteReader rd)
        {
            DecodeHeader(rd);
            rd.Read(out FighterId);
            rd.Read(out FightType);
            rd.Read(out TeamId);
            rd.Read(out SerializedFighterInfo);
            {
                ByteReader serializedInfos = new ByteReader(SerializedFighterInfo);
                var serializationType = serializedInfos.ReadByte();
                ChatacterPositionPart = ChatacterPositionPart.Deserialize(serializedInfos);
                FightInfoPart = CharacterFightPart.Deserialize(serializedInfos);
                CharacteristiquesPart = FightCharacteristiquesPart.Deserialize(serializedInfos);
            }
            rd.Read(out SerializedEffects);
        }
    }
}
