using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System.Collections.Generic;
using System.Linq;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class SalleDjEnutro : ABotActionConfig
    {
        public static new string Name { get; set; } = "Salle Enutrosor";

        public SalleDjEnutro(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            :base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            DonjonsActions.EnterDjEnutro(DjLvl);
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
                DonjonsActions.LeaveSaleEnutro();
                if (Play)
                    DonjonsActions.EnterDjEnutro(DjLvl);
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
                Send(ReadyFight.GetPacket());
            });
        }
    }
}
