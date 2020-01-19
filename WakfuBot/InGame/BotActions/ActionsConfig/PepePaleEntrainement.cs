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
using WakfuBot.WakfuBot.Packets.ToSend;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class PepePaleEntrainement : ABotActionConfig
    {
        public static new string Name { get; set; } = "Pepe pale";

        public PepePaleEntrainement(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            DonjonsActions.EnterPepePaleSalle();
            base.Start();
        }

        public override void AddConfig()
        {
            AddConstantAction(PacketType.FighterTurnBegin, (FighterTurnBegin o) =>
            {
                Console.WriteLine(DateTime.Now + " -> Turn begin " + o.FighterId);
                if (Players.ContainsKey(o.FighterId))
                {
                    Players[o.FighterId].TurnStart();
                }
            });
            AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                DonjonsActions.LeavePepePaleSalle();
                if (!Play)
                    return;
                AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn p)
                    =>
                { DonjonsActions.EnterPepePaleSalle(); });
            });
            AddConstantAction(PacketType.CharacterEnterWorld, (CharacterEnterWorld o) =>
            {
                if (o.Protectors.Count == 0)
                {
                    AddOneExecutionAction(PacketType.MapInfo, (MapInfo n) =>
                    {

                        var mob = Map.GetFightableMobs(MainPlayer().GetPosition(), 1).FirstOrDefault();
                        if (mob == null)
                            return;
                        Send(mob.FightPacket());
                    });
                }
            });
            AddConstantAction(PacketType.EndFightCreation, (EndFightCreation o) =>
            {
                Send(FightPlacement.GetPacket(new MapPosition(-2, 0, 0), MainPlayer().PlayerId));
                if (Players.Count > 1)
                    Send(FightPlacement.GetPacket(new MapPosition(-2, -1, 0), Players.ElementAt(1).Value.PlayerId));
                if (Players.Count > 2)
                    Send(FightPlacement.GetPacket(new MapPosition(-2, 1, 0), Players.ElementAt(2).Value.PlayerId));
                Send(ReadyFight.GetPacket());
            });
        }
    }
}
