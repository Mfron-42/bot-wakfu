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
        public long ElementId;
        public int ExitId;
        public int Difficulty;

        public static TeleportAction GetPacket(long elemId, int exitId)
        {
            return GetPacket(elemId, exitId);
        }

        public static TeleportAction GetPacket(long elemId, int exitId, int difficulty)
        {
            return new TeleportAction
            {
                ElementId = elemId,
                ExitId = exitId,
                Difficulty = difficulty
            };
        }

        public override byte[] GetBytes()
        {
            byte[] infos = ElementId.GetBytes()
                .Concat(ExitId)
                .Concat(DungeonAutoMode)
                .Concat(Difficulty)
                .ToArray();
            return AddHeader(3, FightType, infos);
        }
    }
}
