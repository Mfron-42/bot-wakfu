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
        public long ElementId;
        public short ActionId;

        public static InteractiveElementAction GetPacket(long elementId, short actionId)
        {
            return new InteractiveElementAction
            {
                ElementId = elementId,
                ActionId = actionId
            };
        }

        public override byte[] GetBytes()
        {
            return AddHeader(3, MessageType, ElementId.GetBytes().Concat(ActionId).Concat((short)0).ToArray());
        }
    }
}
