using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class FullDonjonChat : ABotActionConfig
    {
        public static new string Name { get; set; } = "Full Dj Chat";

        public FullDonjonChat(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            DonjonsActions.EntrerDjChat(DjLvl);
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
                if (SaleNumber == 3)
                {
                    DonjonsActions.LeaveFinDjChat();
                    AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn p) =>
                    {
                        var moveToEntrance = new byte[] { 0x00, 0x11, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x23, 0x00, 0x00, 0x00, 0x1E, 0xFF, 0xF8, 0x01, 0xA1 };
                        Send(moveToEntrance);
                        if (Play)
                            DonjonsActions.EntrerDjChat(DjLvl);
                    });
                }
                else
                {
                    SaleNumber++;
                    var mob = Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault();
                    if (mob == null)
                        return;
                    Send(mob.FightPacket());
                }
            });
            AddConstantAction(PacketType.CharacterEnterWorld, (CharacterEnterWorld o) =>
            {
                if (o.Protectors.Count == 0)
                {
                    AddOneExecutionAction(PacketType.MapInfo, (MapInfo n) =>
                    {
                        SaleNumber = 1;
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
