using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public enum SendMessageType
    {
        //1.66.1
        GameServerKey = 414,
        SelectCharacter = 17655,
        InvitGroup = 1106,
        FightPlacement = 12188,
        ClearTmpInventory = 12652,//12652 TempInventoryClearRequestMessage
        FreeSaoul = 12181,
        InvokSpell = 12758,
        Suicide = 12946,
        TeleportAction = 13690,

        StartFight = 13165,
        ReadyFight = 12667,

        EndTurn = 13143,
        ConfirmTurnCount = 13583,
        ConfirmFightEnded = 12147,
        PathMoveRequest = 13515,

        AddMultiman = 13438,

        //1.63.2
        MarketConsultRequest = 15263,
        AddHero = 5568,

        //unused 
        InteractiveElementAction = 201,
        MonsterCollect = 4167,
        GuildPrivateMessage = 523,
    }
}

