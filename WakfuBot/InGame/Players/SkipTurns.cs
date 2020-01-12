using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class SkipTurns : APlayerService
    {
        public SkipTurns(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }
    }
}
