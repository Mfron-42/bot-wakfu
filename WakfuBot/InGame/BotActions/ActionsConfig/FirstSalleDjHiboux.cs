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
    public class SalleDjHiboux : ABotActionConfig
    {
        public static new string Name { get; set; } = "Salle Hiboux";

        public SalleDjHiboux(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
        : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            DonjonsActions.EnterDjHiboux(DjLvl);
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
                DonjonsActions.LeaveDjHiboux();
                if (Play)
                    DonjonsActions.EnterDjHiboux(DjLvl);
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
                Send(FightPlacement.GetPacket(new MapPosition(-1, -2, 0), MainPlayer().PlayerId));
                Send(FightPlacement.GetPacket(new MapPosition(0, -8, 0), Players.ElementAt(1).Value.PlayerId));
                Send(FightPlacement.GetPacket(new MapPosition(-1, -14, 0), Players.ElementAt(2).Value.PlayerId));
                Send(ReadyFight.GetPacket());
            });
        }
    }
}
