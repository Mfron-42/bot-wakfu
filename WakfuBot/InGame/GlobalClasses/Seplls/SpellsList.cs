using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.Seplls
{
    public static class SpellsList
    {

        private static Dictionary<Spell, SpellCracs> Dico = new Dictionary<Spell, SpellCracs>()
        {
            {Spell.MICROBOT, new SpellCracs(Spell.MICROBOT, 1)},
            {Spell.STEAMELLE, new SpellCracs(Spell.STEAMELLE, 0)},
            {Spell.VISION_STASIS, new SpellCracs(Spell.VISION_STASIS, 3, false)},
            {Spell.COEUR_STEAMER, new SpellCracs(Spell.COEUR_STEAMER, 5, false)},
            {Spell.RAYON_STASIS, new SpellCracs(Spell.RAYON_STASIS, 2, false)},
            {Spell.EXPLOSIS, new SpellCracs(Spell.EXPLOSIS, 6, false)},
            {Spell.A_LA_MASSE, new SpellCracs(Spell.A_LA_MASSE, 4)},
            {Spell.ECRASER, new SpellCracs(Spell.ECRASER, 2)},

            {Spell.MOT_RETABLISSANT, new SpellCracs(Spell.MOT_RETABLISSANT, 2)},
            {Spell.MOT_REVIGORANT, new SpellCracs(Spell.MOT_REVIGORANT, 4)},
            {Spell.MOT_SOIGNANT, new SpellCracs(Spell.MOT_SOIGNANT, 3)},
            {Spell.CONTRE_NATURE, new SpellCracs(Spell.CONTRE_NATURE, 0)},

            {Spell.AILE_DE_SCARA, new SpellCracs(Spell.AILE_DE_SCARA, 2)},
            {Spell.SURNOISERIE_BWORK, new SpellCracs(Spell.SURNOISERIE_BWORK, 3)},
            {Spell.CORBAC, new SpellCracs(Spell.CORBAC, 3)},
            {Spell.FRAPPE_CRAQUELEUR, new SpellCracs(Spell.FRAPPE_CRAQUELEUR, 5)},
            {Spell.FORCE_DU_TAURE, new SpellCracs(Spell.FORCE_DU_TAURE, 5)},
            {Spell.ESPRIT_CROCODAIL, new SpellCracs(Spell.ESPRIT_CROCODAIL, 2)},
            {Spell.SYMBIOSE, new SpellCracs(Spell.SYMBIOSE, 2)},

            {Spell.ATTAQUE_PERFIDE, new SpellCracs(Spell.ATTAQUE_PERFIDE, 3)},
            {Spell.SAIGNE_MORTELLE, new SpellCracs(Spell.SAIGNE_MORTELLE, 3)},
            {Spell.OUVRIR_VEINES, new SpellCracs(Spell.OUVRIR_VEINES, 2)},
            {Spell.CHATIMENT, new SpellCracs(Spell.CHATIMENT, 4)},
        };

        public static SpellCracs GetInfos(Spell spell)
        {
            return Dico[spell];
        }
    }

    public class SpellCracs
    {
        public bool UseId;
        public int Cost;
        public int MinRange;
        public int MaxRange;
        public Spell SpellId;

        public SpellCracs(Spell spellId, int cost = 0, bool useId = true, int maxRange = 0, int minRange = 0)
        {
            SpellId = spellId;
            UseId = useId;
            MaxRange = maxRange;
            MinRange = minRange;
            Cost = cost;
        }

        public void Cast(APlayerService player, MapPosition pos)
        {
            long spellId = UseId ? player.GetSpellId(SpellId) : (long)SpellId;
            MainForm.Manager.Send(InvokSpell.GetPacket(player.PlayerId, spellId, pos));
            player.Pa -= Cost;
        }

    }
}
