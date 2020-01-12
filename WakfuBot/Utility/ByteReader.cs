using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets
{
    public class ByteReader
    {
        public byte[] Data;
        public int Index = 0;

        public ByteReader(byte[] data)
            => Data = data;

        public ByteReader(byte[] data, int size)
            => Data = data.Take(size).ToArray();

        public ByteReader()
        {
            this.Data = new byte[0];
        }

        public void AddRange(IEnumerable<byte> range)
        {
            this.Data = Data.Skip(Index).Concat(range).ToArray();
            Index = 0;
        }

        public byte[] ReadAll()
        {
            return this.Read(this.Remaining());
        }

        public int ReadInt()
        {
            var ret = BitConverter.ToInt32(Data.Skip(Index).Take(4).Reverse().ToArray(), 0);
            Index += 4;
            return ret;
        }

        public ushort ReadUShort()
        {
            var ret = BitConverter.ToUInt16(Data.Skip(Index).Take(2).Reverse().ToArray(), 0);
            Index += 2;
            return ret;
        }

        public short ReadShort()
        {
            var ret = BitConverter.ToInt16(Data.Skip(Index).Take(2).Reverse().ToArray(), 0);
            Index += 2;
            return ret;
        }

        public bool ReadBool() => ReadByte() == 1;

        public byte ReadByte() => Data[Index++];

        public void Read(out int value) => value = this.ReadInt();
        public void Read(out byte value) => value = this.ReadByte();
        public void Read(out long value) => value = this.ReadLong();
        public void Read(out ushort value) => value = this.ReadUShort();
        public void Read(out short value) => value = this.ReadShort();
        public void Read(out bool value) => value = this.ReadByte() == 1;
        public void Read(out string value) => value = ReadString();
        public void Read(out byte[] value) => value = Read(ReadShort());
        public void Read(out MapPosition value) => value = new MapPosition(this);

        public byte[] Read(int size)
        {
            var ret = Data.Skip(Index).Take(size).ToArray();
            Skip(size);
            return ret;
        }


        public ByteReader Skip(int skip)
        {
            Index += skip;
            return this;
        }

        public int Remaining() => Data.Length - Index;

        public long ReadLong()
        {
            var ret = BitConverter.ToInt64(Data.Skip(Index).Take(8).Reverse().ToArray(), 0);
            Index += 8;
            return ret;
        }

        public string ReadString() => Encoding.UTF8.GetString(Read(ReadShort()));
    }
}
