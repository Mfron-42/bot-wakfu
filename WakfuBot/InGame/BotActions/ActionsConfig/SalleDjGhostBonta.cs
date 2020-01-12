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
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class SalleDjGhostBonta : ABotActionConfig
    {
        public static new string Name { get; set; } = "Salle Ghosto Bonta";

        public SalleDjGhostBonta(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            DonjonsActions.EnterDjGhostBonta(DjLvl);
            base.Start();
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
                Task.Run(async () =>
                {
                    await DonjonsActions.LeaveDjGhostBonta();
                    if (Play)
                        DonjonsActions.EnterDjGhostBonta(DjLvl);
                });
            });
            AddConstantAction(PacketType.CharacterEnterWorld, (CharacterEnterWorld o) =>
            {
                if (o.Protectors.Count == 0)
                {
                    AddOneExecutionAction(PacketType.MapInfo, (MapInfo n) =>
                    {

                        var mob = Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault();
                        if (mob == null)
                            return;
                        Send(mob.FightPacket());
                    });
                }
            });
            AddConstantAction(PacketType.EndFightCreation, (EndFightCreation o) =>
            {
                Send(FightPlacement.GetPacket(new MapPosition(3, -5, 0), MainPlayer().PlayerId));
                Send(ReadyFight.GetPacket());
            });
        }
    }
}
