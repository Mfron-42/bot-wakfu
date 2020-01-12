using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketReceiv
{
    public class AuthGameServer : AAuthBaseInMessage
    {
        public override AuthMessageType MessageType { get; set; } = AuthMessageType.AUTH_GAME_SERVER;

        public byte Result;
        public byte[] Token;

        public AuthGameServer(ByteReader rd)
        {
            rd.Read(out Result);
            Token = rd.Read(rd.ReadInt());
        }
    }
}
