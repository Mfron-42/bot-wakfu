using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketSend
{

    public class PublicKeyRequest : AAuthBaseOutMessage
    {
        public override AuthRequestType RequestType { get; set; } = AuthRequestType.PUBLIC_KEY_REQUEST;

        public static byte[] GetPacket(byte archTarget = 8)
        {
            return new PublicKeyRequest().AddHeader(archTarget);
        }
    }
}
