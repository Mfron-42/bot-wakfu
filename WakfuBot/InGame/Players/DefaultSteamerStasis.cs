using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Character;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class DefaultSteamerStasis : APlayerService
    {
        private int SpellCount;
        public DefaultSteamerStasis(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }

        public override void PlaySpell()
        {
            if (Pa < 2) {
                EndCurrentTurn();
                return;
            }

            FighterInfo target = null;
            target = GetTarget();
            if (target == null)  {
                EndCurrentTurn();
                return;
            }
            var dist = target.Pos.Distance2D(GetPosition());
            SpellCount++;

            //remove false

            if (Map.GetMobsAndSumms().Count(i => i.Pos.Distance2D(GetPosition()) < 3) > 2 && Pa > 5)
                CastSpell(Spell.EXPLOSIS, GetPosition());
            else if (dist == 1)
            {
                if (Pa > 4)
                    CastSpell(Spell.COEUR_STEAMER, target.Pos);
                else if (Pa > 1)
                    CastSpell(Spell.RAYON_STASIS, target.Pos);
            }
            else if (dist < 5 + GetCurrent(CHARACTERISTIQUES.RANGE) && Pa > 2)
                CastSpell(Spell.VISION_STASIS, target.Pos);
            else if (dist < 5 + GetCurrent(CHARACTERISTIQUES.RANGE) && Pa > 1)
               CastSpell(Spell.RAYON_STASIS, target.Pos);
            else
                EndCurrentTurn();
        }


        public FighterInfo GetTarget()
        {
            var rangedMobds = Map.GetMobsAndSumms()
                .Where(i => i.Pos.Distance2D(GetPosition()) < 5 + GetCurrent(CHARACTERISTIQUES.RANGE))
                .OrderBy(i => i.Pos.Distance2D(GetPosition()));
            return rangedMobds.FirstOrDefault();
          //  return rangedMobds.FirstOrDefault(e => e.RefId == BREED.POZ) ?? rangedMobds.FirstOrDefault(e => e.RefId == BREED.SYCLICK) ?? rangedMobds.FirstOrDefault();
        }


        protected override void PlayTurn()
        {
            SpellCount = 0;
            if (Map.TableTurnCount % 5 == 1)
            {
                CastUniquSpell(Spell.MICROBOT, GetPosition());
                CastUniquSpell(Spell.STEAMELLE, GetPosition());
            }
            base.PlayTurn();
        }
    }
}
