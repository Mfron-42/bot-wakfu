using MoreLinq;
using PacketEditor.WakfuBot.Bot;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Structures.Character;

namespace PacketEditor.WakfuBot.Packets.ToReceiv
{
    public class Map
    {
        private Character[] WorldCharacters = new Character[0];
        private Character[] FightCharacters = new Character[0];
        protected Dictionary<long, APlayerService> Players = new Dictionary<long, APlayerService>();
        private Summon[] Summons = new Summon[0];
        public int FightId;
        private bool _IsFighting = false;
        public short TableTurnCount = 0;
        public int TurnCount = 1;
        public int FightCount = 0;
        public int WinCount = 0;
        public int LostCount = 0;
        public DateTime StartFightTime;
        public DateTime InitMapDate = DateTime.UtcNow;
        private WakfuDatas Manager;
        
        public Map(WakfuDatas manager)
        {
            Manager = manager;
        }

        public void AddPlayer(APlayerService player)
            => Players[player.PlayerId] = player;

        public Character[] WorldMobs()
            => this.WorldCharacters.Where(i => i.CharactereIdentityPart.CharacterType == 1).ToArray();

        public Character[] GetFightableMobs(MapPosition pos, int minGroupLevel = 2, int maxGroupSize = 10, int maxGroupLvl = 9000)
        {
            if (pos == null)
                return null;
            var mobs = WorldCharacters
                .Where(i => i.CharactereIdentityPart.CharacterType == 1)
                .Where(i => i.GroupPart.GroupLevel() >= i.GroupPart.Group.Count)
                .Where(i => i.ChatacterPositionPart.CharacterPositon.Distance2D(pos) < 30)
                .Where(i => i.GroupPart.MemberCount <= maxGroupSize)
                .Where(i => i.GroupPart.GroupLevel() <= maxGroupLvl)
                .Where(i => i.GroupPart.GroupLevel() >= minGroupLevel)
                .OrderBy(i => i.ChatacterPositionPart.CharacterPositon.Distance2D(pos))
                .ToArray();
            return mobs;
        }

        public bool IsPlayer(long id) => Players.ContainsKey(id);

        public APlayerService[] GetPlayers() => Players.Values.ToArray();

        public APlayerService GetPlayer(long id)
        {
            Players.TryGetValue(id, out var player);
            return player;
        }

        public void UpdateWorldPos(long characterId, MapPosition pos)
        {
            Character character = WorldCharacters.FirstOrDefault(i => i.CharacterIDPart.CharacterId == characterId);
            if (character == null)
                return;
            character.ChatacterPositionPart.CharacterPositon = pos;
        }

        public void UpdateFighterPos(long characterId, MapPosition pos)
        {
            Character character = FightCharacters.FirstOrDefault(i => i.CharacterIDPart.CharacterId == characterId);
            if (character != null)
                character.ChatacterPositionPart.CharacterPositon = pos;
            Summon summon = Summons.FirstOrDefault(i => i.Id == characterId);
            if (summon != null)
                summon.Pos = pos;
            if (Players.TryGetValue(characterId, out APlayerService player))
                player.UpdatePosition(pos);
        }

        public FighterInfo NearestMobOrSumm(MapPosition pos)
            => GetMobsAndSumms().MinBy(i => i.Pos.Distance2D(pos));

        public FighterInfo NearestFightMob(MapPosition pos, int offset = 0)
            => GetMobs().MinBy(i => i.Pos.Distance2D(pos));

        public FighterInfo[] GetMobsAndSumms()
        {
            return FightCharacters.Where(i => i.CharactereIdentityPart.CharacterType == 1)
            .Select(i => new FighterInfo(i))
            .Concat(Summons.Select(j => new FighterInfo(j)))
            .ToArray();
        }

        public FighterInfo[] GetMobs()
            => FightCharacters.Where(i => i.CharactereIdentityPart.CharacterType == 1).Select(i => new FighterInfo(i)).ToArray();

        public void AddFighters(List<Character> Fighters)
        {
            FightCharacters = FightCharacters.Where(i => !Fighters.Any(c => c.CharacterIDPart.CharacterId == i.CharacterIDPart.CharacterId)).ToArray();
            FightCharacters = FightCharacters.Concat(Fighters).ToArray();
            WorldCharacters = WorldCharacters.Where(i => !FightCharacters.Any(c => c.CharacterIDPart.CharacterId == i.CharacterIDPart.CharacterId)).ToArray();
        }

        public void AddSummon(Summon summon)
            => Summons = Summons.Concat(summon).ToArray();

        public void RemoveFighterOrSumm(long id)
        {
            Summons = Summons.Where(i => i.Id != id).ToArray();
            FightCharacters = FightCharacters.Where(i => i.CharacterIDPart.CharacterId != id).ToArray();
        }

        public void AddWorldCharacters(List<Character> newCharacters)
        {
            WorldCharacters = WorldCharacters.Where(i => !newCharacters.Any(c => c.CharacterIDPart.CharacterId == i.CharacterIDPart.CharacterId)).ToArray();
            WorldCharacters = WorldCharacters.Concat(newCharacters).ToArray();
        }

        public void RemoveWorldCharacter(long id)
        {
            WorldCharacters = WorldCharacters.Where(i => i.CharacterIDPart.CharacterId != id).ToArray();
        }

        public bool IsFighting() => _IsFighting;

        public void StartFight()
        {
            TableTurnCount = 0;
            TurnCount = 1;
            _IsFighting = true;
            StartFightTime = DateTime.UtcNow;
        }

        public void StopFight() { 
            TableTurnCount = 0;
            TurnCount = 1;
            _IsFighting = false;
            FightCharacters = new Character[0];
            Summons = new Summon[0];
        }

    }

    public class FighterInfo
    {
        public int Level;
        public MapPosition Pos;
        public long Id;
        public BREED RefId;

        public FighterInfo(Character character)
        {
            Level = character.CustomLevelPart.Level;
            Pos = character.ChatacterPositionPart.CharacterPositon;
            Id = character.CharacterIDPart.CharacterId;
            RefId = character.CharactereBreedPart.Breed;
        }

        public FighterInfo(Summon summon)
        {
            Level = summon.Characteristic.CappedLevel;
            Pos = summon.Pos;
            Id = summon.Id;
            RefId = summon.Characteristic.TypeId;
        }
    }
}
