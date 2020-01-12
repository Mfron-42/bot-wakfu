using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class DefaultEniEau : APlayerService
    {
        private bool contreNature = false;
        public DefaultEniEau(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }

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
            

            if(Pa >= 4 && dist <= 3 + GetCurrent(CHARACTERISTIQUES.RANGE))
            {
                if (contreNature)
                    CastSpell(Spell.MOT_REVIGORANT, target.Pos);
                else
                    CastContreNature();
            }
            else if (Pa >= 3 && dist <= 5 + GetCurrent(CHARACTERISTIQUES.RANGE))
            {
                if (contreNature)
                    CastSpell(Spell.MOT_SOIGNANT, target.Pos);
                else
                    CastContreNature();
            }
            else if (Pa >= 2 && dist <= 6 + GetCurrent(CHARACTERISTIQUES.RANGE))
            {
                if (contreNature)
                    CastSpell(Spell.MOT_SOIGNANT, target.Pos);
                else
                    CastContreNature();
            }
            else if (Pa >= 3)
            {
                if (!contreNature)
                    CastSpell(Spell.MOT_SOIGNANT, GetPosition());
                else
                    CastContreNature();
            }
            else
                EndCurrentTurn();
        }


        private void CastContreNature()
        {
            contreNature = !contreNature;
            CastSpell(Spell.CONTRE_NATURE, GetPosition());
        }

        protected override void PlayTurn()
        {
            if (Map.TableTurnCount == 1)
                contreNature = false;
            base.PlayTurn();
        }


        public FighterInfo GetTarget()
        {
            var mobs = Map.GetMobsAndSumms().Where(i => i.Pos.Distance2D(GetPosition()) <= 6 + GetCurrent(CHARACTERISTIQUES.RANGE, 2));
            if (mobs.Count() < 1)
                return null;
            return mobs.OrderBy(i => i.Pos.Distance2D(GetPosition())).ThenByDescending(i => i.Level).First();
        }
    }
}
