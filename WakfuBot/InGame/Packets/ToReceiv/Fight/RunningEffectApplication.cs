using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class RunningEffectApplication : AFightBaseAction
    {
        public static PacketType packetType = PacketType.RunningEffectApplication;
        
        public int RunningEffectId;
        public byte[] SerializedEffect;

        public RunningEffectApplication(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out RunningEffectId);
            SerializedEffect = rd.Read(rd.ReadShort());
        }
    }
}
