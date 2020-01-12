using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    public class TeleportBehindTarget
    {
        public SpellEffectInfo SpellEffect;
        public MapPosition Pos;
        public byte Direction;
        public long TargetId;
        public long CasterId;
        public RelativeFightTime FightTimeEnd;


        public TeleportBehindTarget(Dictionary<byte, ByteReader> infos)
        {
            SpellEffect = new SpellEffectInfo(infos[0]);
            infos[1].Read(out CasterId);
            infos[2].Read(out TargetId);
            Pos = new MapPosition(infos[3]);
            infos[3].Read(out Direction);
            //Infos[4].Read(out Unknow2);
            FightTimeEnd = new RelativeFightTime(infos[5]);
        }
    }
}
