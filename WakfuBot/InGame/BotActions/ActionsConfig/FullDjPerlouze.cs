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
    public class FullDjPerlouzeToFix : ABotActionConfig
    {
        public static new string Name { get; set; } = "Full Dj Perlouze";

        public FullDjPerlouzeToFix(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            DonjonsActions.EnterDjPerlouze(DjLvl);
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
                if (o.FightId != Map.FightId)
                    return;
                SaleNumber++;
                if (SaleNumber == 2)
                {
                    MapPosition step = new MapPosition()
                    {
                        X = -26,
                        Y = -1,
                        Z = -0
                    };
                    Send(PathMoveRequest.GetPacket(MainPlayer().GetPosition().GoToYFirst(step)));
                    TryFight();
                }
                else if (SaleNumber == 3)
                {
                    MapPosition step = new MapPosition()
                    {
                        X = -33,
                        Y = -8,
                        Z = -0
                    };
                    Send(PathMoveRequest.GetPacket(MainPlayer().GetPosition().GoToXFirst(step)));
                    Send(0x00, 0x1E, 0x03, 0x10, 0x11, 0xFF, 0xFF, 0xFF, 0xDF, 0xFF, 0xFF, 0xFF, 0xF8, 0x00, 0x00, 0x0E, 0xE0, 0xE0, 0xE0, 0xFE, 0xFC, 0xFC, 0xFE, 0xE0, 0xE0, 0xE0, 0xE0, 0xE0, 0xE0, 0xE0);
                    TryFight();
                }
                else if (SaleNumber == 4)
                {
                    MapPosition step = new MapPosition()
                    {
                        X = -52,
                        Y = -29,
                        Z = -12
                    };
                    Send(PathMoveRequest.GetPacket(MainPlayer().GetPosition().GoToYFirst(step)));
                    TryFight();
                }
                else if (SaleNumber >= 5)
                {
                    DonjonsActions.LeaveDjPerlouze(DjLvl);
                    AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn p) =>
                    {
                        if (Play)
                            DonjonsActions.EnterDjPerlouze(DjLvl);
                    });
                }
            });
            AddConstantAction(PacketType.CharacterEnterWorld, (CharacterEnterWorld o) =>
            {
                if (o.Protectors.Count == 0)
                {
                    SaleNumber = 1;
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
                if (SaleNumber == 1)
                {
                    Send(FightPlacement.GetPacket(new MapPosition(-5, 3, 0), MainPlayer().PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-5, 1, 0), Players.ElementAt(1).Value.PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-5, -1, 0), Players.ElementAt(2).Value.PlayerId));
                }
                if (SaleNumber == 2)
                {

                    Send(FightPlacement.GetPacket(new MapPosition(-28, 2, 0), MainPlayer().PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-28, 0, 0), Players.ElementAt(1).Value.PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-28, -1, 0), Players.ElementAt(2).Value.PlayerId));
                }
                if (SaleNumber == 4)
                {

                    Send(FightPlacement.GetPacket(new MapPosition(-53, -26, -12), MainPlayer().PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-53, -29, -12), Players.ElementAt(1).Value.PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-53, -31, -12), Players.ElementAt(2).Value.PlayerId));
                }
                Send(ReadyFight.GetPacket());
            });
        }

        private void TryFight()
        {
            var mob = Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault();
            if (mob != null)
            {
                Send(mob.FightPacket());
                return;
            }
            AddOneExecutionAction(PacketType.MapInfo, (MapInfo n) =>
            {
                mob = Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault();
                Send(mob.FightPacket());
            });
        }
    }
}
