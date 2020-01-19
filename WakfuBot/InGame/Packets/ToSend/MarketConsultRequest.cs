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

        public short ItemType;
        public int MinPrice;
        public int MaxPrice;
        public short SortType;
        public short FirstIndex;
        public bool LowestMode;

        public static MarketConsultRequest GetPacket(short itemType = -1, int minPrice = -1, int maxPrice = -1, short sortType = -1, short firstIndex = 0, bool lowestmode = true)
        {
            return new MarketConsultRequest
            {
                ItemType = itemType,
                MinPrice = minPrice,
                MaxPrice = maxPrice,
                SortType = sortType,
                FirstIndex = firstIndex,
                LowestMode = lowestmode
            };
        }

        public override byte[] GetBytes()
        {
            byte sortingType = (byte)SortType;
            return AddHeader(3, MessageType, ItemType.GetBytes().Concat(MinPrice.GetBytes()).Concat(MaxPrice.GetBytes()).Concat(sortingType.GetBytes()).Concat(FirstIndex.GetBytes()).Concat(LowestMode.GetBytes()).ToArray());
        }
    }
}
