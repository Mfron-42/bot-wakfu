using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.PacketReceiv;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication
{
    public static class AuthNetworkMessages
    {
        public static Dictionary<AuthMessageType, Type> Constructors = new Dictionary<AuthMessageType, Type>
        {
            { AuthMessageType.PUBLIC_KEY, typeof(PublicKey) },
            { AuthMessageType.CLIENT_VERSION, typeof(ClientVersion) },
            { AuthMessageType.AUTH_RESULT, typeof(AuthResult) },
            { AuthMessageType.PROXY_RESULT, typeof(ProxyResult) },
            { AuthMessageType.AUTH_GAME_SERVER, typeof(AuthGameServer) },
            { AuthMessageType.DEFAULT_RESULT_MESSAGE, typeof(DefaultResultsMessage) },
        };
    }
}
