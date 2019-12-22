using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class AFightBaseAction : FightBase
    {
        public int UniqueId;
        public int TriggerActionUniqueId;

        public void DecodeActionHeader(ByteReader rd)
        {
            DecodeHeader(rd);
            rd.Read(out UniqueId);
            rd.Read(out TriggerActionUniqueId);
        }
    }
}
