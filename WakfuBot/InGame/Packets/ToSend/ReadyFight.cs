using PacketEditor.WakfuBot.PacketTypes;
using System.Linq;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class ReadyFight : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.ReadyFight;

        public static byte[] GetPacket(bool ready = true)
        {
            return AddHeader(3, MessageType, new[] { ready.ToByte() } );
        }
    }
}
