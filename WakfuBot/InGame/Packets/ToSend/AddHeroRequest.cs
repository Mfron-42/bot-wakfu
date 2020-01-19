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
    public class AddHeroRequest : OutputOnlyProxyMessage
    {
        public static SendMessageType MessageType = SendMessageType.AddHero;
        public long HeroId;

        public static AddHeroRequest GetPacket(long heroId)
        {
            return new AddHeroRequest
            {
                HeroId = heroId
            };
        }

        public override byte[] GetBytes()
        {
            return AddHeader(3, MessageType, HeroId.GetBytes());
        }
    }
}
