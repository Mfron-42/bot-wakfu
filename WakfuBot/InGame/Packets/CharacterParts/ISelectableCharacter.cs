using WakfuBot.InGame.Packets.ToSend;
using WakfuBot.WakfuBot.Packets.ToSend;
using WakfuBot.WakfuBot.Structures.Character;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public interface ISelectableCharacter
    {
        long Id { get; set; }
        BREED Breed { get; set; }
        string DisplayName();

        IPacket GetSelectionPacket();
    }
}