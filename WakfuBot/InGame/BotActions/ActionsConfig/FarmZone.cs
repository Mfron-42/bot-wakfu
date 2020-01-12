using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class FarmZone : ABotActionConfig
    {
        public new static string Name { get; set; } = "Farm zone";

        private int MaxGroupSize = 10;
        private int MaxGroupLevel = 9000;

        public FarmZone(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            Send(Map.GetFightableMobs(MainPlayer().GetPosition(), MaxGroupSize, MaxGroupLevel).FirstOrDefault()?.FightPacket());
        }

        public override void AddConfig()
        {
            AddConstantAction(PacketType.FighterTurnBegin, (FighterTurnBegin o) =>
            {
                if (Players.ContainsKey(o.FighterId))
                {
                    Players[o.FighterId].TurnStart();
                }
            });
            AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                Send(Map.GetFightableMobs(MainPlayer().GetPosition(), MaxGroupSize).FirstOrDefault()?.FightPacket());
                Task.Delay(100).ContinueWith(async (t) =>
                {
                    if (!Play)
                        return;
                    IEnumerable<Character> mobs = Map.GetFightableMobs(MainPlayer().GetPosition(), MaxGroupSize);
                    while (!Map.IsFighting() && mobs.Count() > 0)
                    {
                        Send(mobs.First().FightPacket());
                        mobs = mobs.Skip(1);
                        await Task.Delay(100);
                    }
                });
            });
            AddConstantAction(PacketType.EndFightCreation, (EndFightCreation o) =>
            {
                Send(ReadyFight.GetPacket());
            });
        }
    }
}
