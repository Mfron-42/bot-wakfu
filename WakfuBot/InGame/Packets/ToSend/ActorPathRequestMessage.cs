using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.InGame.Enums;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class ActorPathRequestMessage : OutputOnlyProxyMessage
    {
        public static SendMessageType Type = SendMessageType.PathMoveRequest;
        public PathMove PathMove;
        public DeplacementType DeplacementType;
        
        public static ActorPathRequestMessage GetPacket(PathMove pathMove, DeplacementType deplacementType = DeplacementType.RUN)
        {
            return new ActorPathRequestMessage()
            {
                DeplacementType = deplacementType,
                PathMove = pathMove
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = ((int)DeplacementType).GetBytes().Concat(PathMove.StartPos.GetBytes()).Concat(PathMove.EncodedPath).ToArray();
            return AddHeader(3, Type, infos);
        }
    }

    public class PathMove
    {
        public MapPosition StartPos;
        public byte[] EncodedPath;

        public PathMove(MapPosition startPos, byte[] encodedPath)
        {
            StartPos = startPos;
            EncodedPath = encodedPath;
        }

        public PathMove AddBytes(params byte[] bytes)
        {
            var newPath = new byte[] { (byte)(EncodedPath[0] + bytes.Length) }.Concat(EncodedPath.Skip(1).Concat(bytes)).ToArray();
            EncodedPath = newPath;
            return this;
        }
    }
}
