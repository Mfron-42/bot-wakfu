using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.PacketTypes
{
    public class LeaveInstance
    {
        public static PacketType packetType = PacketType.LeaveInstance;
        public LeaveInstance(ByteReader rd)
        {                 
        }
    }
}
