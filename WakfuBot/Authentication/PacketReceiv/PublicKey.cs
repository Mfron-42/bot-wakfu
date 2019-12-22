using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketReceiv
{
    public class PublicKey : AAuthBaseInMessage
    {
        public override AuthMessageType MessageType { get; set; } = AuthMessageType.PUBLIC_KEY;

        public long Salt;
        public byte[] Key;

        public PublicKey(ByteReader rd)
        {
            rd.Read(out Salt);
            Key = rd.ReadAll();
        }

    }
}
