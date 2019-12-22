using PacketEditor.WakfuBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketSend
{
    public class GameServerConnect : AAuthBaseOutMessage
    {
        public override AuthRequestType RequestType { get; set; } = AuthRequestType.GAME_SERVER_CONNECT;

        public static byte[] GetPacket(int serverId, long accountId)
        {
            return new GameServerConnect().AddHeader(8, serverId.GetBytes().Concat(accountId).ToArray());
        }
    }
}
