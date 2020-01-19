using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.InGame.Packets.ToSend
{
    public interface IPacket
    {
        string ToString();

        byte[] GetBytes();
    }
}
