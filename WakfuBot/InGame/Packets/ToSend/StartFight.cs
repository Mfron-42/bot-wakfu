using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System.Linq;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.PacketTypes
{
    public class StartFight : OutputOnlyProxyMessage
    {   
        public static SendMessageType MessageType = SendMessageType.StartFight;
        public long CharacterId;
        public MapPosition MapPosition;
        public bool LockFight;

        public static StartFight GetPacket(Character character, bool lockFight = true)
        {
            return GetPacket(character.CharacterIDPart.CharacterId, character.ChatacterPositionPart.CharacterPositon, lockFight);
        }

        public static StartFight GetPacket(long characterId, MapPosition mapPosition, bool lockFight = true)
        {
            return new StartFight
            {
                CharacterId = characterId,
                MapPosition = mapPosition,
                LockFight = lockFight
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = CharacterId.GetBytes()
                .Concat(MapPosition.GetBytes())
                .Concat(LockFight.GetBytes())
                .ToArray();
            return AddHeader(3, MessageType, infos);
        }
    }
}
