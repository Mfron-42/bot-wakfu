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
        public long CharacterId;
        public string CharacterName;

        public static SelectCharacter GetPacket(long characterId, string characterName)
        {
            return new SelectCharacter
            {
                CharacterId = characterId,
                CharacterName = characterName
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = CharacterId.GetBytes().Concat(CharacterName.Length).Concat(CharacterName).ToArray();
            return AddHeader(2, RequestType, infos);
        }
    }
}
