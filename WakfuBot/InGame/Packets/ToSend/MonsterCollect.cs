using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System.Linq;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.PacketTypes
{
    public class MonsterCollect : OutputOnlyProxyMessage
    {   
        public static SendMessageType MessageType = SendMessageType.MonsterCollect;
        public long CharacterId;
        public MapPosition Position;
        public bool LockFight;

        public static MonsterCollect GetPacket(Character character, bool lockFight = true)
        {
            return GetPacket(character.CharacterIDPart.CharacterId, character.ChatacterPositionPart.CharacterPositon, lockFight);
        }

        public static MonsterCollect GetPacket(long characterId, MapPosition position, bool lockFight = true)
        {
            return new MonsterCollect
            {
                CharacterId = characterId,
                Position = position,
                LockFight = lockFight
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = CharacterId.GetBytes()
                 .Concat(Position.GetBytes())
                 .Concat(LockFight.GetBytes())
                 .ToArray();
            return AddHeader(3, MessageType, infos);
        }
    }
}
