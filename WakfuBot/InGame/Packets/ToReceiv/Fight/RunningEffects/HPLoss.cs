using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    [ProtoContract]
    public class HPLoss
    {
        public long SourceId;
        public long TargetId;
        public SpellEffectInfo SpellEffect;
        public long Unknow1;
        public RelativeFightTime FightTimeEnd;
    }
}

