using PacketEditor.WakfuBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.Authentication.Packets
{
    public abstract class AAuthBaseOutMessage
    {

        public abstract AuthRequestType RequestType { get; set; }

        public byte[] AddHeader(byte header, byte[] data)
        {
            return ((short)(data.Length + 5))
                .GetBytes()
                .Concat(new byte[] { header })
                .Concat(((short)RequestType).GetBytes())
                .Concat(data).ToArray();
        }

        public byte[] AddHeader(byte header)
            => AddHeader(header, new byte[0]);
    }
}
