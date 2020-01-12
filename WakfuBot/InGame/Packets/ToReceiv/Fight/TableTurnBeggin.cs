using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv.Fight
{
    public class TableTurnBeggin : AFightBaseAction
    {
        public static PacketType packetType = PacketType.TableTurnBeggin;

        public short NumTurn;
        public byte[] ShortTimeLineSerialize;

        public TableTurnBeggin(ByteReader rd)
        {
            DecodeActionHeader(rd);
            rd.Read(out NumTurn);
            if (rd.Remaining() > 0)
                ShortTimeLineSerialize = rd.Read(rd.ReadShort());
        }
    }
}