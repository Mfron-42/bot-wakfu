using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public class SelectCharacter : OutputOnlyProxyMessage
    {
        public static SendMessageType RequestType = SendMessageType.SelectCharacter;

        public static byte[] GetPacket(long characterId, string characterName)
        {
            byte[] infos = characterId.GetBytes().Concat(characterName.Length).Concat(characterName).ToArray();
            return AddHeader(2, RequestType, infos);
        }
    }
}
