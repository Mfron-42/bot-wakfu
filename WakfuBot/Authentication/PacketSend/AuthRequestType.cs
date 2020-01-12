using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.Authentication.Packets
{
    public enum AuthRequestType : short
    {
        PUBLIC_KEY_REQUEST = 487,
        SEND_CLIENT_VERSION = 9,
        LOGIN = 444,
        PROXY_REQUEST = 567,
        GAME_SERVER_CONNECT = 461,
    };
}
