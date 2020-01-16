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
    public class InvitGroup : OutputOnlyProxyMessage//GroupClientInvitationRequestMessage
    {
        public static SendMessageType MessageType = SendMessageType.InvitGroup;

        public static byte groupType = 1;//m_groupType
        public static long groupId = 0;//m_groupId
        public static bool fromPartySearch = false;//m_fromPartySearch
        public static long occupationId = 0;//m_occupationId
        
        public static byte byName = 0;

        public static byte[] GetPacket(string name)
        {
            byte[] infos = groupType.GetBytes()
                .Concat(groupId)
                .Concat(fromPartySearch)
                .Concat(occupationId)
                .Concat(byName)
                .Concat((byte)name.Length)
                .Concat(name)
                .ToArray();
            return AddHeader(6, MessageType, infos);
        }

    }
}
