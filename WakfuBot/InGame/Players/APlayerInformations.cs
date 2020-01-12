using PacketEditor.WakfuBot.Packets.Utility;
using System.Collections.Generic;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures;
using WakfuBot.WakfuBot.Structures.Enums;

namespace PacketEditor.WakfuBot.Players
{
    public abstract class APlayerInformations
    {

        public ChatacterPositionPart ChatacterPositionPart { get; set; }
        public FightCharacteristiquesPart CharacteristiquesPart { get; set; }
        public CharacterSpellInventoryPart CharacterSpellInventoryPart { get; set; }
        public CustomGuildPart CustomGuildPart { get; set; }

        public void UpdatePosition(MapPosition pos)
        {
            if (ChatacterPositionPart == null)
                ChatacterPositionPart = new ChatacterPositionPart();
            ChatacterPositionPart.CharacterPositon = pos;
        }

        public void UpdatePosition(ChatacterPositionPart chatacterPositionPart)
            => ChatacterPositionPart = chatacterPositionPart;

        public void UpdateCharacteristiques(FightCharacteristiquesPart characteristiquesPart)
            => CharacteristiquesPart = characteristiquesPart;

        public void UpdateSpellInventory(CharacterSpellInventoryPart spellInventoryPart)
            => CharacterSpellInventoryPart = spellInventoryPart;

        public MapPosition GetPosition()
            => ChatacterPositionPart?.CharacterPositon;

        public long GetSpellId(Spell spell)
            => CharacterSpellInventoryPart.Spells.FirstOrDefault(s => s.SpellId == (int)spell).UniqueId;

        public Characteristiques Get(CHARACTERISTIQUES carac)
            => CharacteristiquesPart?.Get(carac);

        public int GetCurrent(CHARACTERISTIQUES carac, int defaultValue = 0)
            => CharacteristiquesPart.GetCurrent(carac, defaultValue);

    }
}