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
    public class FirstSalleDjCroco
    {
        private Dictionary<long, APlayerService> Players;
        private WakfuDatas Manager;
        private Map Map;
        private DonjonsActions DonjonsActions;

        public FirstSalleDjCroco(WakfuDatas manager, Map map, Dictionary<long, APlayerService> Players, DonjonsActions donjonsActions)
        {
            this.Map = map;
            this.Manager = manager;
            this.DonjonsActions = donjonsActions;
            this.Players = Players;
            Config();
        }

        public void Debug()
        {
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
                DonjonsActions.LeaveFirstSalleCroco(1);
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
                Manager.Send(ReadyFight.GetPacket());
            });
        }
    }
}
