using System.Collections.Generic;
using PacketEditor.WakfuBot.Packets.Utility;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class CharacterInformation
    {
        public static PacketType packetType = PacketType.CharacterInfo;
        private List<long> ReservedIds = new List<long>();
        public Character Character;

        public CharacterInformation(ByteReader rd)
        {
            var reservedIds = rd.ReadShort();
            for (var i = 0; i < reservedIds; i++)
                ReservedIds.Add(rd.ReadLong());
            Character = new Character();
            Character.UnserializePlayer(new ByteReader(rd.Read(rd.ReadInt())));
        }
    }
}
