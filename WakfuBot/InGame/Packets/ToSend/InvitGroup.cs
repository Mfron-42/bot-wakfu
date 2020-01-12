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
    public class InvitGroup : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.InvitGroup;

        public static byte Unknow1 = 1;
        public static bool ById = false;
        public static long Unknow2 = 0;
        public static long Unknow3 = 0;
        public static byte Unknow4 = 0;

        public static byte[] GetPacket(string name)
        {
            byte[] infos = Unknow1.GetBytes()
                .Concat(ById)
                .Concat(Unknow2)
                .Concat(Unknow3)
                .Concat(Unknow4)
                .Concat((byte)name.Length)
                .Concat(name)
                .ToArray();
            return AddHeader(6, MessageType, infos);
        }

    }
}
