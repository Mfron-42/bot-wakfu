using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class SramMultiBasLvl : APlayerService
    {
        public SramMultiBasLvl(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }

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
            
            if (dist == 1 && Pa > 3)
            {
                CastSpell(Spell.CHATIMENT, GetPosition());
            }
            else if (Pa > 3 && dist < 4 + GetCurrent(CHARACTERISTIQUES.RANGE))
            {
                CastSpell(Spell.ATTAQUE_PERFIDE, target.Pos);
            }
            else
                EndCurrentTurn();
        }


        public FighterInfo GetTarget()
        {
            return Map.GetMobsAndSumms().OrderBy(i => i.Pos.Distance2D(GetPosition())).ThenByDescending(i => i.Level).FirstOrDefault();
        }
    }
}
