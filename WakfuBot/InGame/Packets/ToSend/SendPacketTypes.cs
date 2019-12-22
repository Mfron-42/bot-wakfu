using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public enum SendMessageType
    {
        GuildPrivateMessage = 523,
        InteractiveElementAction = 201,
        ClearTmpInventory = 5217,
        InvitGroup = 501,
        Suicide = 4120,
        AddHero = 5568,
        MarketConsultRequest = 15263,
        AddMultiman = 5554,
        SelectCharacter = 2049,
        StartFight = 8001,
        GameServerKey = 1213,
        InvokSpell = 8109,
        ReadyFight = 8149,
        EndTurn = 8105,
        ConfirmTurnCount = 8112,
        TeleportAction = 205,
        ConfirmFightEnded = 8041,
        PathMoveRequest = 4113,
        FreeSaoul = 12553,
        FightPlacement = 8161,
        MonsterCollect = 4167
    }
}
