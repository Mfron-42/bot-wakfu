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
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class FirstSalleDjWaConfig
    {
        private Dictionary<long, APlayerService> Players;
        private WakfuDatas Manager;
        private Map Map;
        private DonjonsActions DonjonsActions;

        public FirstSalleDjWaConfig(WakfuDatas manager, Map map, Dictionary<long, APlayerService> Players, DonjonsActions donjonsActions)
        {
            this.Map = map;
            this.Manager = manager;
            this.DonjonsActions = donjonsActions;
            this.Players = Players;
            Config();
        }

        private APlayerService MainPlayer() => Players.First().Value;

        public void Debug()
        {
            Manager.Send(TeleportAction.GetPacket(21750539021013248, 1));
        }

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
                var dest = new MapPosition(-27, -11);
                if (dest.Distance2D(MainPlayer().GetPosition()) < 50)
                    Manager.Send(ActorPathRequestMessage.GetPacket(MainPlayer().GetPosition().GoToYFirst(dest)));
                DonjonsActions.LeaveDjWa(1);
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
                Manager.Send(FightPlacement.GetPacket(new MapPosition(-3, -11), MainPlayer().PlayerId));
                Manager.Send(ReadyFight.GetPacket());
            });
        }
    }
}
