using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class RunningEffectUnapplication : AFightBaseAction
    {
        public static PacketType packetType = PacketType.RunningEffectUnapplication;
        
        public int RunningEffectId;
        public byte[] SerializedEffect;
        public long Ruid;
        public long TargetId;

        public RunningEffectUnapplication(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out RunningEffectId);
            SerializedEffect = rd.Read(rd.ReadShort());
            rd.Read(out TargetId);
            rd.Read(out Ruid);
            //WakfuDatas.AddInfos("UNAPPLI", RunningEffectId.ToString(), Ruid.ToString(), TargetId.ToString(), "uneffect");
        }
        
    }
}
