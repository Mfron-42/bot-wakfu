using Newtonsoft.Json;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.InGame.Packets.ToSend;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public abstract class OutputOnlyProxyMessage : IPacket
    {
        public static short HEADER_SIZE = 5;

        public static byte[] AddHeader(byte architectureTarget, SendMessageType packetId, byte[] data)
        {
            return((short)(HEADER_SIZE + data.Length)).GetBytes()
                .Concat(new[] { architectureTarget })
                .Concat(((short)packetId).GetBytes())
                .Concat(data).ToArray();
        }

        public static byte[] AddHeader(byte architectureTarget, SendMessageType packetId)
            => AddHeader(architectureTarget, packetId, new byte[0]);

        public abstract byte[] GetBytes();

        public override string ToString()
        {
            var className = GetType().Name;
            var fields = GetType().GetFields();
            var fieldsInfos = fields.Select(field =>
            {
                var fieldName = field.Name;
                var fieldValue = field.GetValue(this);
                return fieldName + " : " + fieldValue;
            }).Aggregate((a, b) => a + " - " + b);
            return className + " [" + fieldsInfos + "]";
        }
    }
}
