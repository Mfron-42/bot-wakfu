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

        public static byte[] GetPacket(byte[] key)
        {
            byte[] infos = key.Length.GetBytes().Concat(key).ToArray();
            return AddHeader(1, RequestType, infos);
        }
    }
}
