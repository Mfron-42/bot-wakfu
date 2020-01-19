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
    public class GameServerKey : OutputOnlyProxyMessage
    {
        public static SendMessageType RequestType = SendMessageType.GameServerKey;
        public byte[] Key;

        public static GameServerKey GetPacket(byte[] key)
        {
            return new GameServerKey
            {
                Key = key
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = Key.Length.GetBytes().Concat(Key).ToArray();
            return AddHeader(1, RequestType, infos);
        }
    }
}
