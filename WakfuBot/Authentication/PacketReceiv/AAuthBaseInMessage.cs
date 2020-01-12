using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketReceiv
{
    public abstract class AAuthBaseInMessage
    {
        public abstract AuthMessageType MessageType { get; set; }
    }
}
