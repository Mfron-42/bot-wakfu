using System.Collections.Generic;
using System.Linq;
using PacketEditor.WakfuBot.Packets.Utility;
using WakfuBot.WakfuBot.Structures.Character;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class MapInfo
    {
        public static PacketType packetType = PacketType.MapInfo;

        public byte CharacterCount;
        public bool WorldSpawn;

        public byte CharacterType;

        public List<Character> Units = new List<Character>();

        public MapInfo(ByteReader rd)
        {
            WorldSpawn = rd.ReadByte() == 0;
            rd.Read(out CharacterCount);
            for (int i = 0; i < CharacterCount; i++)
            {
                byte characterType = rd.ReadByte();
                Units.Add(Character.CreateCharacter(rd, characterType == 0));
            }
        }
    }
}
