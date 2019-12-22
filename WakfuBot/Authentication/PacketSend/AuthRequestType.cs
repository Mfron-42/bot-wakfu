using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.Authentication.Packets
{
    public enum AuthRequestType : short
    {
        PUBLIC_KEY_REQUEST = 1033,
        SEND_CLIENT_VERSION = 7,
        LOGIN = 1026,
        PROXY_REQUEST = 1035,
        GAME_SERVER_CONNECT = 1211,
        EMPTY = 1,
    };
}
