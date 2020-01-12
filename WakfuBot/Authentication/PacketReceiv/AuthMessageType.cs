using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.Authentication.Packets
{
    public enum AuthMessageType : short
    {
        PUBLIC_KEY = 422,
        CLIENT_VERSION = 11,
        AUTH_RESULT = 542,
        PROXY_RESULT = 573,
        AUTH_GAME_SERVER = 428,
        DEFAULT_RESULT_MESSAGE = 373
    };
}
