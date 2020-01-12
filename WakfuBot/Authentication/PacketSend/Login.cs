using PacketEditor.WakfuBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketSend
{
    public class Login : AAuthBaseOutMessage
    {
        public override AuthRequestType RequestType { get; set; } = AuthRequestType.LOGIN;

        public static byte[] GetPacket(string login, string password, long salt, byte[] publicKey)
        {
            var encrypted = AuthEncrypt.AuthData(login, password, salt, publicKey);
            return new Login().AddHeader(8, encrypted.Length.GetBytes().Concat(encrypted).ToArray());
        }
    }
}
