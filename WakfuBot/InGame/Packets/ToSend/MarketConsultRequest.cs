using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToSend
{
    public class MarketConsultRequest : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.MarketConsultRequest;

        public static byte[] GetPacket(short itemType = -1, int minPrice = -1, int maxPrice = -1, short sortType = -1, short firstIndex = 0, bool lowestmode = true)
        {
            byte sortingType = (byte)sortType;
            return AddHeader(3, MessageType, itemType.GetBytes().Concat(minPrice.GetBytes()).Concat(maxPrice.GetBytes()).Concat(sortingType.GetBytes()).Concat(firstIndex.GetBytes()).Concat(lowestmode.GetBytes()).ToArray());
        }
    }
}
