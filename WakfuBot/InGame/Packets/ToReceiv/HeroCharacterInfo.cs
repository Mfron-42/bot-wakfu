using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.PacketTypes;
using System.Threading;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Packets.ToSend;
using MoreLinq;
using PacketEditor.WakfuBot.Players;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class HeroCharacterInformation
    {
        public static PacketType packetType = PacketType.HeroCharacterInfo;
        public Character Character;
        public int Unknow1;


        public HeroCharacterInformation(ByteReader rd)
        {
            rd.Read(out Unknow1);
            Character = new Character();
            Character.UnserializePlayer(rd);
        }
    }
}
