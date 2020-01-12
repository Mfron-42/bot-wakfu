using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class DefaultSteamerTerre : APlayerService
    {
        public DefaultSteamerTerre(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }

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
            if(Pa >= 4 && dist <= 4 + GetCurrent(CHARACTERISTIQUES.RANGE, 1))
            {
                CastSpell(Spell.A_LA_MASSE, target.Pos);
                return;
            }
            else if (dist <= 3 + GetCurrent(CHARACTERISTIQUES.RANGE, 1))
            {
                CastSpell(Spell.ECRASER, target.Pos);
                return;
            }
            EndCurrentTurn();
        }


        public FighterInfo GetTarget()
        {
            var mobs = Map.GetMobsAndSumms().Where(i => i.Pos.Distance2D(GetPosition()) < 5 + GetCurrent(CHARACTERISTIQUES.RANGE, 1));
            if (mobs.Count() < 1)
                return null;
            return mobs.OrderBy(i => i.Pos.Distance2D(GetPosition())).ThenByDescending(i => i.Level).First();
        }
    }
}
