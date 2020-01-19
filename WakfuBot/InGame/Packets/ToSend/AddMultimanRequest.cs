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
    public class AddCompagnionRequest : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.AddMultiman;
        public long MultimanId;

        public static AddCompagnionRequest GetPacket(long multimanId)
        {
            return new AddCompagnionRequest()
            {
                MultimanId = multimanId
            };
        }

        public override byte[] GetBytes()
        {
            return AddHeader(3, MessageType, MultimanId.GetBytes());
        }
    }
}
