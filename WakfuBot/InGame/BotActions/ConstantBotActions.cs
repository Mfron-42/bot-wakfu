using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using WakfuBot;
using WakfuBot.WakfuBot.Bot.Actions.ActionsConfig;

namespace PacketEditor.WakfuBot.Bot
{
    public class BotActions : BaseBotActions
    {
        private static Dictionary<string, Type> ConfigList = new Dictionary<string, Type>
        {
            { SalleDjSrambad.Name, typeof(SalleDjSrambad) },
            { MarketPlaceDataSniffer.Name, typeof(MarketPlaceDataSniffer) },
            { PepePaleEntrainement.Name, typeof(PepePaleEntrainement) },
            { FullDonjonChat.Name, typeof(FullDonjonChat) },
            { FarmZone.Name , typeof(FarmZone) },
            { SalleDjGhostBonta.Name , typeof(SalleDjGhostBonta) },
            { SalleDjChat.Name , typeof(SalleDjChat) },
            { SalleDjPerlouze.Name , typeof(SalleDjPerlouze) },
            { SalleDjHiboux.Name , typeof(SalleDjHiboux) },
            { SalleDjEnutro.Name , typeof(SalleDjEnutro) },
             { SalleDjChaferAstrub.Name , typeof(SalleDjChaferAstrub) }
        };

        public DonjonsActions DonjonsActions;

        public BotActions(WakfuDatas manager, Map map) : base(manager, map)
        {
            DonjonsActions = new DonjonsActions(Manager, this);
        }

        public ABotActionConfig CreateBotActions(string name, int stasisLvl)
        {
            if (!BotActions.ConfigList.TryGetValue(name, out Type botActionsClass))
                return null;
            return (ABotActionConfig)botActionsClass
                .GetConstructor(new[] { typeof(WakfuDatas), typeof(Map),  typeof(Dictionary<long, APlayerService>), typeof(DonjonsActions), typeof(int) })
                .Invoke(new object[] { Manager, Map, Players, DonjonsActions, stasisLvl });
        }

        public static string[] GetConfigNameArray()
            => ConfigList.Select(p => p.Key).ToArray();
    }
}
