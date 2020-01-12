using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.PacketTypes;
using System.Threading;
using PacketEditor.WakfuBot.Packets.Utility;
using MoreLinq;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class Despawn
    {
        public static PacketType packetType = PacketType.Despawn;

        public bool ApplyApsOnDespawn;
        public bool FightDespawn;
        public byte ActorCount;
        public Dictionary<long, byte> Actors = new Dictionary<long, byte>();

        public Despawn(ByteReader rd)
        {
            ApplyApsOnDespawn = rd.ReadByte() == 1;
            FightDespawn = rd.ReadByte() == 1;
            ActorCount = rd.ReadByte();
            while(rd.Remaining() > 0) {
                rd.Read(out byte type);
                Actors[rd.ReadLong()] = type;
            }
        }
    }    
}
