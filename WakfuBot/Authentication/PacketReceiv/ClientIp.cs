//using PacketEditor.WakfuBot.Packets;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WakfuBot.Authentication.Packets;
//
//namespace WakfuBot.Authentication.PacketReceiv
//{
//    public class ClientIp : AAuthBaseInMessage
//    {
//        public override AuthMessageType MessageType { get; set; } = AuthMessageType.CLIENT_IP;
//
//        public int Ip;
//
//        public ClientIp(ByteReader rd)
//        {
//            rd.Read(out Ip);
//        }
//    }
//}
