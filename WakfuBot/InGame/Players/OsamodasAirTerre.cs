using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System.Collections.Generic;
using System.Linq;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Structures.Character;
using WakfuBot.WakfuBot.Structures.Enums;

namespace WakfuBot.WakfuBot.Bot.Players.newPlayer
{
    class OsamodasAirTerre : APlayerService
    {
        public OsamodasAirTerre(long id, WakfuDatas manager, Map map) : base(id, manager, map) { }

        public int FightRangeBonus = 0;

        public List<long> BackMonster = new List<long>();

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


            if (Map.GetMobsAndSumms().Count(i => i.Pos.Distance2D(GetPosition()) < 3) > 2 && Pa > 5)
                CastSpell(Spell.FRAPPE_CRAQUELEUR, GetPosition());
            else if (dist == 1)
            {
                if (Pa > 4)
                    CastSpell(Spell.FORCE_DU_TAURE, target.Pos);
                else
                    CastSpell(Spell.ESPRIT_CROCODAIL, target.Pos);
            }
            else if (dist == 5 + GetCurrent(CHARACTERISTIQUES.RANGE) + FightRangeBonus && Pa > 2)
            {
                CastSpell(Spell.CORBAC, target.Pos);
            }
            else if (dist < 5 + GetCurrent(CHARACTERISTIQUES.RANGE) + FightRangeBonus && Pa > 2)
            {
                if (BackMonster.Contains(target.Id))
                {
                    CastSpell(Spell.CORBAC, target.Pos);
                }
                else
                {
                    CastSpell(Spell.SURNOISERIE_BWORK, target.Pos);
                    BackMonster.Add(target.Id);
                }
            }
            else if (dist < 4 + GetCurrent(CHARACTERISTIQUES.RANGE) + FightRangeBonus && Pa > 1)
                CastSpell(Spell.AILE_DE_SCARA, target.Pos);
            else
                EndCurrentTurn();
        }


        public FighterInfo GetTarget()
        {
            var rangedMobds = Map.GetMobsAndSumms()
                .Where(i => i.Pos.Distance2D(GetPosition()) < 5 + GetCurrent(CHARACTERISTIQUES.RANGE) + FightRangeBonus)
                .OrderBy(i => i.Pos.Distance2D(GetPosition()));
            return rangedMobds.FirstOrDefault(e => e.RefId == BREED.SYCLICK) ?? rangedMobds.FirstOrDefault(e => e.RefId == BREED.POZ) ?? rangedMobds.FirstOrDefault();
        }


        protected override void PlayTurn()
        {
            if (Map.TableTurnCount == 1)
            {
                CastUniquSpell(Spell.SYMBIOSE, GetPosition());
                FightRangeBonus = 1;
            }
            Pa++;
            BackMonster.Clear();
            base.PlayTurn();
        }
    }
}
