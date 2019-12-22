using PacketEditor.WakfuBot.Packets.ToSend;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacketEditor.WakfuBot.Packets.Utility
{
    public class MapPosition
    {
        public int X;
        public int Y;
        public short Z;


        public MapPosition(int x, int y, short z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public MapPosition() { }

        public static bool operator ==(MapPosition a, MapPosition b)
        {
            return a?.X == b?.X && a?.Y == b?.Y && a?.Z == b?.Z;
        }

        public static bool operator !=(MapPosition a, MapPosition b) => !(a == b);

        public MapPosition(ByteReader rd)
        {
            X = rd.ReadInt();
            Y = rd.ReadInt();
            Z = rd.ReadShort();
        }

        public bool Equal2D(MapPosition pos) => Distance2D(pos) == 0;


        public byte[] CalcDef(int posStart, int posEnd, byte positiveValue, byte negativeValue)
        {
            return Enumerable.Repeat((byte)(posStart < posEnd ? positiveValue : negativeValue), Math.Abs(posStart - posEnd)).ToArray();
        }

        public PathMove GoToXFirst(MapPosition dest)
        {
            byte[] pathX = CalcDef(X, dest.X, 32, 160);
            byte[] pathY = CalcDef(Y, dest.Y, 96, 224);
            return new PathMove(this, new[] { (byte)(pathX.Length + pathY.Length) }.Concat(pathX).Concat(pathY).ToArray());
        }

        public PathMove GoToYFirst(MapPosition dest)
        {
            byte[] pathX = CalcDef(X, dest.X, 32, 160);
            byte[] pathY = CalcDef(Y, dest.Y, 96, 224);
            return new PathMove(this, new[] { (byte)(pathX.Length + pathY.Length) }.Concat(pathY).Concat(pathX).ToArray());
        }


        public byte[] GetBytes() => X.GetBytes().Concat(Y.GetBytes()).Concat(Z.GetBytes()).ToArray();

        public int Distance2D(MapPosition pos) =>  Math.Abs(pos.X - X) + Math.Abs(pos.Y - Y);

        public override string ToString() => "X:" + X + " Y:" + Y + " Z:" + Z;
        
    }
}
