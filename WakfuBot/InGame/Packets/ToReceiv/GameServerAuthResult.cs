using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Packets.ToReceiv
{
    public class GameServerAuthResult
    {
        public static PacketType packetType = PacketType.GameServerAuthResult;

        public byte Result;
        public int BanDelay;
        public byte BlockNumber;
        public byte BlockId;
        public byte BlockStart;
        public long AccountId;
        public int SubscriptionLevel;
        public int AntiAddictLevel;
        public int AdditionalSlot;
        public long AccountExpirationDate;
        public string AccountNickName;
        public int AccountCommunityId;

        public Dictionary<int, long> Heros = new Dictionary<int, long>();
        public Dictionary<byte, long> Unk = new Dictionary<byte, long>();
        public List<int> AdminRights = new List<int>();


        public GameServerAuthResult(ByteReader rd)
        {
            rd.Read(out Result);
            if (Result == 5)
            {
                rd.Read(out BanDelay);
                return;
            }
            if (Result != 0)

                return;
            short blockSize = rd.ReadShort();
            rd.Read(out BlockNumber);
            rd.Read(out BlockId);
            rd.Read(out BlockStart);
            rd.Read(out BlockId);
            rd.Read(out AccountId);
            rd.Read(out SubscriptionLevel);
            rd.Read(out AntiAddictLevel);
            rd.Read(out AdditionalSlot);
            rd.Read(out AccountExpirationDate);
            int heroCount = rd.ReadInt();
            for (var h = 0; h < heroCount; ++h)
            {
                Heros.Add(rd.ReadInt(), rd.ReadLong());
            }
            for (var i = 0; i < 100; ++i)
                AdminRights.Add(rd.ReadInt());
            var unknow = rd.Skip(4);
            AccountNickName = Encoding.UTF8.GetString(rd.Read(rd.ReadByte()));
            rd.Read(out AccountCommunityId);
            var unkSize = rd.ReadShort();
            for (var j = 0; j < unkSize; ++j)
            {
                Unk.Add(rd.ReadByte(), rd.ReadLong());
            }
        }
    }
}
