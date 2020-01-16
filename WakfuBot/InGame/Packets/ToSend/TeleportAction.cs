using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Packets.ToSend
{
    public class TeleportAction : OutputOnlyProxyMessage
    {
        public static SendMessageType FightType = SendMessageType.TeleportAction;

        public static bool DungeonAutoMode = false;

        public static byte[] GetPacket(long elemId, int exitId)
        {
            return GetPacket(elemId, exitId, 11);
        }

        public static byte[] GetPacket(long elemId, int exitId, int difficulty)
        {
            byte[] infos = elemId.GetBytes()
                .Concat(exitId)
                .Concat(DungeonAutoMode)
                .Concat(difficulty)
                .ToArray();
                
            return AddHeader(3, FightType, infos);
        }
    }
}
