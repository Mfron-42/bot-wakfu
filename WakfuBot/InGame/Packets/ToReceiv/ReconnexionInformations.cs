using System.Collections.Generic;
using System.Linq;
using PacketEditor.WakfuBot.Packets.Utility;
using WakfuBot.WakfuBot.Structures.Character;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class ReconnexionInformation
    {
        public static PacketType packetType = PacketType.ReconnexionInformation;

        public Character Character;
        public int FightId;

        public ReconnexionInformation(ByteReader rd)
        {
            rd.Read(out FightId);
            Character = Character.CreateCharacter(rd, true);
        }
    }
}
