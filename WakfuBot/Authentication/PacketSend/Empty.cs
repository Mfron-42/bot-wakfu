//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WakfuBot.Authentication.Packets;
//
//namespace WakfuBot.Authentication.PacketSend
//{
//    public class Empty : AAuthBaseOutMessage
//    {
//        public override AuthRequestType RequestType { get; set; } = AuthRequestType.EMPTY;
//
//        public static byte[] GetPacket()
//        {
//            return new Empty().AddHeader(0);
//        }
//    }
//}
