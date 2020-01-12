using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot
{
   public static class Extensions
    {

        public static int GetInt(this IEnumerable<byte> datas)
            => BitConverter.ToInt32(datas.Take(4).Reverse().ToArray(), 0);

        public static short GetShort(this IEnumerable<byte> datas)
            => BitConverter.ToInt16(datas.Take(2).Reverse().ToArray(), 0);

        public static ushort GetUShort(this IEnumerable<byte> datas)
            => BitConverter.ToUInt16(datas.Take(2).Reverse().ToArray(), 0);

        public static long GetLong(this IEnumerable<byte> datas)
            => BitConverter.ToInt64(datas.Take(8).Reverse().ToArray(), 0);

        public static T RandomElement<T>(this IEnumerable<T> enumerable)
            => enumerable.ElementAt(new Random().Next(0, enumerable.Count()));

        public static IEnumerable<byte> Concat(this IEnumerable<byte> data, bool add)
            => data.Concat((byte)(add ? 1 : 0));
        public static IEnumerable<byte> Concat(this IEnumerable<byte> data, string add)
            => data.Concat(Encoding.UTF8.GetBytes(add));
        public static IEnumerable<byte> Concat(this IEnumerable<byte> data, byte add)
            => data.Concat(new byte[] { add });
        public static IEnumerable<byte> Concat(this IEnumerable<byte> data, int add)
            => data.Concat(add.GetBytes());
        public static IEnumerable<byte> Concat(this IEnumerable<byte> data, long add)
            => data.Concat(add.GetBytes());
        public static IEnumerable<byte> Concat(this IEnumerable<byte> data, short add)
            => data.Concat(add.GetBytes());


        public static byte[] GetBytes(this bool data)
            => ((byte)(data ? 1 : 0)).GetBytes();

        public static byte[] GetBytes(this byte data)
            => new byte[] { data };

        public static byte[] GetBytes(this int data)
            => BitConverter.GetBytes(data).Reverse().ToArray();

        public static byte[] GetBytes(this uint data)
            => BitConverter.GetBytes(data).Reverse().ToArray();

        public static byte[] GetBytes(this short data)
            => BitConverter.GetBytes(data).Reverse().ToArray();

        public static byte[] GetBytes(this long data)
            => BitConverter.GetBytes(data).Reverse().ToArray();

        public static byte[] GetBytes(this string data)
            => new[] { ((byte)data.Length) }.Concat(UTF8Encoding.ASCII.GetBytes(data)).ToArray();

        public static byte[] GetBytes(this ushort data)
            => BitConverter.GetBytes(data).Reverse().ToArray();

        public static byte ToByte(this bool b) => b ? (byte)1 : (byte)0;

        public static string ToHxString(this byte[] array)
        {
            StringBuilder hex = new StringBuilder(array.Length * 3);
            foreach (byte b in array)
                hex.AppendFormat("{0:X2}" + (hex.Length % (16 * 3) == 0 ? Environment.NewLine : " "), b);
            return hex.ToString();
        }

        public static bool ContainHeader(this List<byte[]> headers, byte[] data)
            => headers.Any(head => head.SequenceEqual(data.Take(head.Length)));
    }
}