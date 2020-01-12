using PacketEditor.WakfuBot.Bot;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects.HPLoss;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects
{
    public class ExchangePosition
    {
        public MapPosition TargetPos;
        public MapPosition CasterPos;
        public long TargetId;
        public long CasterId;
        public SpellEffectInfo SpellEffect;
        public RelativeFightTime FightTimeEnd;


        public ExchangePosition(Dictionary<byte, ByteReader> infos)
        {
            SpellEffect = new SpellEffectInfo(infos[0]);
            infos[1].Read(out CasterId);
            infos[2].Read(out TargetId);
            TargetPos = new MapPosition(infos[3]);
            CasterPos = new MapPosition(infos[3]);
            //Infos[4].Read(out Unknow2);
            FightTimeEnd = new RelativeFightTime(infos[5]);
         
        }
    }
}
