using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class FirstSalleDjSacriConfig
    {
        private Dictionary<long, APlayerService> Players;
        private WakfuDatas Manager;
        private Map Map;
        private DonjonsActions DonjonsActions;

        public FirstSalleDjSacriConfig(WakfuDatas manager, Map map, Dictionary<long, APlayerService> Players, DonjonsActions donjonsActions)
        {
            this.Map = map;
            this.Manager = manager;
            this.DonjonsActions = donjonsActions;
            this.Players = Players;
            Config();
        }
        
        public void Debug()
        {
            Manager.Send(TeleportAction.GetPacket(30736847555150592, 1));
        }

        private APlayerService MainPlayer() => Players.First().Value;

        private void Config()
        {
            Manager.AddConstantAction(PacketType.FighterTurnBegin, (FighterTurnBegin o) =>
            {
                if (Players.ContainsKey(o.FighterId))
                {
                    Players[o.FighterId].TurnStart();
                }
            });
            Manager.AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                if (o.Loosers.Contains(MainPlayer().PlayerId))
                {
                    Manager.Send(FreeSaoul.GetPacket());
                    Manager.Send(ActorPathRequestMessage.GetPacket(new MapPosition(-2, -68).GoToXFirst(new MapPosition(0, -71))));
                    Manager.Send(TeleportAction.GetPacket(30736847555150592, 1));
                    return;
                }
                DonjonsActions.LeaveDjSacri(1);
            });
            Manager.AddConstantAction(PacketType.CharacterEnterWorld, (CharacterEnterWorld o) =>
            {
                if (o.Protectors.Count == 0)
                {
                    Manager.AddOneExecutionAction(PacketType.MapInfo, (MapInfo n) =>
                    {

                        var mob = Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault();
                        if (mob == null)
                            return;
                        Manager.Send(mob.FightPacket());
                    });
                }
            });
            Manager.AddConstantAction(PacketType.EndFightCreation, (EndFightCreation o) =>
            {
                Manager.Send(FightPlacement.GetPacket(new MapPosition(0, -8), MainPlayer().PlayerId));
                Manager.Send(FightPlacement.GetPacket(new MapPosition(-3, -8), Players.Skip(1).First().Value.PlayerId));
                Manager.Send(FightPlacement.GetPacket(new MapPosition(3, -8), Players .Skip(2).First().Value.PlayerId));
                Manager.Send(ReadyFight.GetPacket());
            });
        }
    }
}
