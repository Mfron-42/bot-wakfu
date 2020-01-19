using PacketEditor.WakfuBot.PacketTypes;
using System.Linq;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class ReadyFight : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.ReadyFight;
        public bool IsReady;

        public static ReadyFight GetPacket(bool isReady = true)
        {
            return new ReadyFight()
            {
                IsReady = isReady
            };
        }

        public override byte[] GetBytes()
        {
            return AddHeader(3, MessageType, IsReady.GetBytes());
        }
    }
}
