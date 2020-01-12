using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    class CharacterEnterWorld
    {
        public static PacketType packetType = PacketType.CharacterEnterWorld;


        public byte[] serializedCharInfo;

        public List<byte[]> ProtectorsInfo = new List<byte[]>();
        public List<byte[]> Protectors = new List<byte[]>();

        public CharacterEnterWorld(ByteReader rd)
        {
            serializedCharInfo = rd.Read(rd.ReadShort());
            rd.Read(out short ProtectorSize);
            rd.Read(out short protectorCount);
            for (int i = 0; i < protectorCount; i++)
            {
                Protectors.Add(rd.Read(rd.ReadShort()));
            }
            rd.Read(out short ProtectorInfoSize);
            rd.Read(out short protectorInfoCount);
            //for (int i = 0; i < protectorInfoCount; i++)
            //{
            //    ProtectorsInfo.Add(rd.Read(rd.ReadShort()));
            //}
        }
    }
}
