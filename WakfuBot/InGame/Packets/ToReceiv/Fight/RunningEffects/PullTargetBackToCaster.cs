using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    class PullTargetBackToCaster
    {
        public long TargetId;
        public long CasterId;
        public SpellEffectInfo SpellEffect;
        public RelativeFightTime FightTimeEnd;
        public MapPosition Pos;


        public PullTargetBackToCaster(Dictionary<byte, ByteReader> infos)
        {
            SpellEffect = new SpellEffectInfo(infos[0]);
            infos[1].Read(out CasterId);
            infos[2].Read(out TargetId);
            infos[3].Read(out Pos);
            //Infos[4].Read(out Unknow2);
            FightTimeEnd = new RelativeFightTime(infos[5]);
        }
    }
}
