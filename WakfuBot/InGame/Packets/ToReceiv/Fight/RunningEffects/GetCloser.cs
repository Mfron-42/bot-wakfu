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
    public class GetCloser
    {
        public long TargetId;
        public long CasterId;
        public SpellEffectInfo SpellEffect;
        public RelativeFightTime FightTimeEnd;
        public List<MapPosition> Path = new List<MapPosition>();


        public GetCloser(Dictionary<byte, ByteReader> infos)
        {
            SpellEffect = new SpellEffectInfo(infos[0]);
            infos[1].Read(out CasterId);
            infos[2].Read(out TargetId);
            short size = infos[3].ReadShort();
            for (int i = 0; i < size; i++)
                Path.Add(new MapPosition(infos[3]));
            //Infos[4].Read(out Unknow2);
            FightTimeEnd = new RelativeFightTime(infos[5]);
        }
    }
}
