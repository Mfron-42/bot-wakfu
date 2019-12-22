using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketSend
{
    public class ProxyRequest : AAuthBaseOutMessage
    {
        public override AuthRequestType RequestType { get; set; } = AuthRequestType.PROXY_REQUEST;

        public static byte[] GetPacket()
        {
            return new ProxyRequest().AddHeader(8);
        }
    }
}
