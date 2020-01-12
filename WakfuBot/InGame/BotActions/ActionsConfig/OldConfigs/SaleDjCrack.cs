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
    public class SaleDjCrack
    {
        private Dictionary<long, APlayerService> Players;
        private WakfuDatas Manager;
        private Map Map;
        private DonjonsActions DonjonsActions;
        private int sale = 1;

        public SaleDjCrack(WakfuDatas manager, Map map, Dictionary<long, APlayerService> Players, DonjonsActions donjonsActions)
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
            Manager.Send(TeleportAction.GetPacket(19090820393323520, 20));
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

                DonjonsActions.LeaveSaleDjCrack(20);

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
                        Manager.SendBytes(new byte[] { 00 ,07 ,03, 0x32, 0xC9, 0x66, 0x72 });
                        Manager.Send(mob.FightPacket());
                    });
                }
            });
            Manager.AddConstantAction(PacketType.EndFightCreation, (EndFightCreation o) =>
            {
                    Manager.Send(FightPlacement.GetPacket(new MapPosition(-4, -3, 20), MainPlayer().PlayerId));
                    Manager.Send(ReadyFight.GetPacket());
            });
        }
    }
}
