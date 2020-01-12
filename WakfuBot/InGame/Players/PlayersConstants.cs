using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using WakfuBot.WakfuBot.Bot.Players.newPlayer;
using WakfuBot.WakfuBot.Packets.ToReceiv;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Bot.Players
{
    public static class PlayersConstants
    {
        private static readonly Dictionary<string, Type> ExistingPlayers = new Dictionary<string, Type>
        {
                //{ "Steam-Meurt", typeof(DefaultSteamerTerre) },
                //{ "Ylona", typeof(OsamodasBasLVL) },
                //{ "Anoly", typeof(OsamodasBasLVL) },
                { "Thudene", typeof(SkipTurns) },
        };

        private static readonly Dictionary<BREED, Type> ExistingBreeds = new Dictionary<BREED, Type>
        {
            { BREED.STEAMER, typeof(DefaultSteamerStasis) },
            //{ BREED.STEAMER, typeof(DefaultSteamerTerre) },
            { BREED.LUMINO, typeof(SkipTurns) },
            { BREED.KROSMOGLOB, typeof(SkipTurns) },
            { BREED.OMBRE, typeof(SkipTurns) },
            { BREED.ENIERIPSA, typeof(DefaultEniEau) },

             { BREED.SRAM, typeof(SkipTurns) },

            { BREED.OSAMODAS, typeof(OsamodasAirTerre) },
        };

        public static bool ExistIA(ISelectableCharacter character)
        {
            return ExistingPlayers.ContainsKey(character.DisplayName()) || ExistingBreeds.ContainsKey(character.Breed);
        }

        public static bool ExistIA(CompagnionInfos compagnion)
        {
            return ExistingPlayers.ContainsKey(compagnion.Name) || ExistingBreeds.ContainsKey(compagnion.Breed);
        }

        public static APlayerService GetPlayerIA(ISelectableCharacter character, WakfuDatas manager, Map map)
        {
            ExistingPlayers.TryGetValue(character.DisplayName(), out var playerIa);
            ExistingBreeds.TryGetValue(character.Breed, out var breedIa);
            APlayerService player = (APlayerService)(playerIa ?? breedIa)
                .GetConstructor(new[] { typeof(long), typeof(WakfuDatas), typeof(Map) })
                .Invoke(new object[] { character.Id, manager, map });
            player.Name = character.DisplayName();
            return player;
        }
    }
}
