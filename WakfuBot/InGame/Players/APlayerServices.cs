using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WakfuBot;
using WakfuBot.WakfuBot.Bot.Actions.Seplls;
using WakfuBot.WakfuBot.Bot.Players;
using WakfuBot.WakfuBot.Packets.ToReceiv;
using WakfuBot.WakfuBot.Structures;
using WakfuBot.WakfuBot.Structures.Enums;

namespace PacketEditor.WakfuBot.Players
{
    public abstract class APlayerService : APlayerInformations
    {
        public string Name { get; set; }
        public long PlayerId { get; set; }
        virtual protected WakfuDatas Manager { get; set; }
        virtual protected Map Map { get; set; }
        public int Pa;


        protected APlayerService(long id, WakfuDatas manager, Map map)
        {
            PlayerId = id;
            Manager = manager;
            Map = map;
        }

        public void AddInfos(Character playerInfos)
        {
            UpdatePosition(playerInfos.ChatacterPositionPart);
            UpdateSpellInventory(playerInfos.CharacterSpellInventoryPart);
            CustomGuildPart = playerInfos.CustomGuildPart;
        }

        protected async void CastSpell(Spell spell, MapPosition castPos)
        {
            Console.WriteLine(DateTime.Now + " -> Spell " + spell + " launched at " + castPos);
            SpellsList.GetInfos(spell).Cast(this, castPos);
            bool executed = false;
            Manager.AddOneExecutionAction(PacketType.SpellCastNotif, (SpellCastNotification o) =>
            {
                if (executed)
                    return;
                executed = true;
                Manager.AddOneExecutionAction(PacketType.FightActionSequenceExecute,
                    (FightActionSequenceExecute p) => { Task.Delay(10).ContinueWith(t => { PlaySpell(); }); });
            });
            Task.Delay(100).ContinueWith(t =>
            {
                if (executed)
                    return;
                executed = true;
                PlaySpell();
            });
        }

        public void TurnStart()
        {
            Pa = Get(CHARACTERISTIQUES.AP)?.Max ?? 6;
            PlayTurn();
        }

        protected virtual void PlayTurn()
        {
            PlaySpell();
        }

        public void CastUniquSpell(Spell spell, MapPosition castPos)
        {
            SpellsList.GetInfos(spell).Cast(this, castPos);
        }

        public virtual void PlaySpell()
            => EndCurrentTurn();

        public void EndCurrentTurn()
        {
            Console.WriteLine(DateTime.Now + " -> End turn");
            Manager.Send(EndTurn.GetPacket(PlayerId, Map.TableTurnCount));
        }

    public static APlayerService Get(ISelectableCharacter character, WakfuDatas manager, Map map)
            => PlayersConstants.GetPlayerIA(character, manager, map);
    }
}
