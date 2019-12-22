using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.Authentication.Packets
{
    public enum AuthMessageType : short
    {
        PUBLIC_KEY = 1034,
        CLIENT_VERSION = 8,
        CLIENT_IP = 110,
        AUTH_RESULT = 1027,
        PROXY_RESULT = 1036,
        AUTH_GAME_SERVER = 1212
    };
}
