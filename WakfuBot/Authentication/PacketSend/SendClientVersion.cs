using PacketEditor.WakfuBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Properties;

namespace WakfuBot.Authentication.Packets
{
    public class SendClientVersion : AAuthBaseOutMessage
    {
        public override AuthRequestType RequestType { get; set; } = AuthRequestType.SEND_CLIENT_VERSION;

        public static byte Version;
        public static short Revision;
        public static byte Change;
        public static byte[] Build = new byte[0];

        public static byte[] GetPacket()
        {
            Version = Settings.Default.Version;
            Revision = Settings.Default.Revision;
            Change = Settings.Default.Change;
            Build = Settings.Default.Build.GetBytes();
            return new SendClientVersion().AddHeader(0, Version.GetBytes().Concat(Revision).Concat(Change).Concat((byte)Build.Length).Concat(Build).ToArray());
        }
    }
}
