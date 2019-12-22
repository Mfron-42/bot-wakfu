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
using WakfuBot.WakfuBot.Packets.ToSend;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class SalleDjPerlouze : ABotActionConfig
    {
        public static new string Name { get; set; } = "Salle Perlouze";

        public SalleDjPerlouze(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
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
            AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                if (o.Loosers.Contains(MainPlayer().PlayerId))
                {
                    Send(FreeSaoul.GetPacket());
                    Task.Delay(1000).ContinueWith(t => Send(PathMoveRequest.GetPacket(MainPlayer().GetPosition().GoToYFirst(new MapPosition(-32, -69)))));
                    Task.Delay(2000).ContinueWith(t => DonjonsActions.EnterDjPerlouze(DjLvl));
                }
            });
            AddConstantAction(PacketType.FighterTurnBegin, (FighterTurnBegin o) =>
            {
                if (Players.ContainsKey(o.FighterId))
                {
                    Players[o.FighterId].TurnStart();
                }
            });
            AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                DonjonsActions.LeaveSallePerlouze(DjLvl);
                if (!Play)
                    return;
                AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn p)
                    => DonjonsActions.EnterDjPerlouze(DjLvl));
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
                if (Players.Count > 1)
                {
                    Send(FightPlacement.GetPacket(new MapPosition(-6, 1, 0), MainPlayer().PlayerId));
                    Send(FightPlacement.GetPacket(new MapPosition(-6, 0, 0), Players.ElementAt(1).Value.PlayerId));
                }
                if (Players.Count > 2)
                    Send(FightPlacement.GetPacket(new MapPosition(-6, 2, 0), Players.ElementAt(2).Value.PlayerId));
                Send(ReadyFight.GetPacket());
            });
        }
    }
}
