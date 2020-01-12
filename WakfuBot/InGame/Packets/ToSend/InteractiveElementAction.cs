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
    public class InteractiveElementAction : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.InteractiveElementAction;

        public static byte[] GetPacket(long elementId, short actionId)
        {
            return AddHeader(3, MessageType, elementId.GetBytes().Concat(actionId).Concat((short)0).ToArray());
        }

    }
}
