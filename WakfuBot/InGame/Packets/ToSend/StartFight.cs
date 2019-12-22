using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System.Linq;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.PacketTypes
{
    public class StartFight : OutputOnlyProxyMessage
    {   
        public static SendMessageType MessageType = SendMessageType.StartFight;

        public static byte[] GetPacket(Character character, bool lockFight = true)
        {
            byte[] infos = character.CharacterIDPart.CharacterId.GetBytes()
                .Concat(character.ChatacterPositionPart.CharacterPositon.GetBytes())
                .Concat(new byte[] { lockFight.ToByte() })
                .ToArray();
            return AddHeader(3, MessageType, infos);
        }

        public static byte[] GetPacket(long id, MapPosition position, bool lockFight = true)
        {
            byte[] infos = id.GetBytes()
                .Concat(position.GetBytes())
                .Concat(new byte[] { lockFight.ToByte() })
                .ToArray();
            return AddHeader(3, MessageType, infos);
        }

    }
}
