using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System.Collections.Generic;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class OsamodasBasLVL : APlayerService
    {
        public OsamodasBasLVL(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }

        public override void PlaySpell()
        {
            if (Pa < 2)
            {
                EndCurrentTurn();
                return;
            }

            FighterInfo target = null;
            target = GetTarget();
            if (target == null)
            {
                EndCurrentTurn();
                return;
            }
            int dist = target.Pos.Distance2D(GetPosition());

            if (dist == 1)
            {
                CastSpell(Spell.ESPRIT_CROCODAIL, target.Pos);
            }
            else if (dist < 6 + GetCurrent(CHARACTERISTIQUES.RANGE) && Pa > 2)
            {
                CastSpell(Spell.CORBAC, target.Pos);
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
