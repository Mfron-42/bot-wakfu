using MoreLinq;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.PacketTypes;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.WakfuBot.Bot.Actions;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot.Bot.Actions
{
    public abstract class BaseBotActions : MouvementsActions
    {
        override protected Dictionary<long, APlayerService> Players { get; set; } = new Dictionary<long, APlayerService>();

        public BaseBotActions(WakfuDatas manager, Map map) : base(manager, map)
        {
            AddPlayerInfos();
            AutoClearTmpInventory();
            AddSummonFight();
            ConfirmEndFight();
            MapInfoUpdate();
            RemoveDeadFighter();
            UpdateDespawn();
            UpdateFightStartInfo();
            UpdateMapFightStart();
            UpdateFightTurnCount();
            UpdateTableTurnCount();
            UpdateFightEndInfos();
            AddCompagnionAlias();
            UpdateStats();
        }

        public APlayerService MainPlayer()
          => Players.First().Value;

        public void AddPlayer(APlayerService player)
            => Players[player.PlayerId] = player;

        public void AddPlayerInfos()
        {
            Manager.AddConstantAction(PacketType.CharacterInfo, (CharacterInformation o) =>
            {
                Players[o.Character.CharacterIDPart.CharacterId].AddInfos(o.Character);
            });
            Manager.AddConstantAction(PacketType.HeroCharacterInfo, (HeroCharacterInformation o) =>
            {
                Players[o.Character.CharacterIDPart.CharacterId].AddInfos(o.Character);
            });
        }


        public void UpdateStats()
        {
            Manager.AddConstantAction(PacketType.ReconnexionInformation, (ReconnexionInformation o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                if (!Players.TryGetValue(o.Character.CharacterIDPart.CharacterId, out var player))
                    return;
                player.UpdateCharacteristiques(o.Character.CharacteristiquesPart);
            });
        }

        public void AddCompagnionAlias()
        {
            Manager.AddConstantAction(PacketType.MapInfo, (MapInfo o) =>
            {
                o.Units.Where(u => u.CompanionControllerIdPart != null)
                    .Where(u => Players.ContainsKey(u.CompanionControllerIdPart.CompanionId))
                    .ForEach(u =>
                {
                    var compagnionId = u.CompanionControllerIdPart.CompanionId;
                    var fighterId = u.CharacterIDPart.CharacterId;
                    var player = Players[compagnionId];
                    player.PlayerId = fighterId;
                    Players.Remove(compagnionId);
                    Players[fighterId] = player;
                });
                Manager.AddOneExecutionAction(PacketType.FightEnd, (FightEnd p) =>
                {
                    o.Units.Where(u => u.CompanionControllerIdPart != null)
                        .Where(u => Players.ContainsKey(u.CharacterIDPart.CharacterId))
                        .ForEach(u =>
                    {
                        var compagnionId = u.CompanionControllerIdPart.CompanionId;
                        var fighterId = u.CharacterIDPart.CharacterId;
                        var player = Players[fighterId];
                        player.PlayerId = compagnionId;
                        Players.Remove(fighterId);
                        Players[compagnionId] = player;
                    });
                });
            });
        }

        public void AutoClearTmpInventory()
        {
            Manager.AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                Manager.Send(ClearTmpInventory.GetPacket());
            });
        }

        public void MapInfoUpdate()
        {
            Manager.AddConstantAction(PacketType.MapInfo, (MapInfo o) =>
            {
                if (! o.InFightSpawn)
                    Map.AddWorldCharacters(o.Units);
                else
                    Map.AddFighters(o.Units);
                o.Units.ForEach(i => {
                    var player = Map.GetPlayer(i.CharacterIDPart.CharacterId);
                    if (player == null)
                        return;
                    player.UpdatePosition(i.ChatacterPositionPart);
                });
            });
        }

        public void RemoveDeadFighter()
        {
            Manager.AddConstantAction(PacketType.FighterStatusChange, (FighterChangeStatus o) =>
            {
                if (o.Status == 2)
                    Map.RemoveFighterOrSumm(o.FighterId);
            });
        }

        public void ConfirmEndFight()
        {
            Manager.AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                //Manager.Send(ConfirmFightEnded.GetPacket(Map.FightId));
                Map.StopFight();
                Map.FightCount++;
            });
        }

        public void UpdateFightEndInfos()
        {
            Manager.AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                if (!o.Loosers.Contains(MainPlayer().PlayerId))
                    Map.WinCount++;
                else
                    Map.LostCount++;

            });
        }

        public void FightEveryActorWhoMove()
        {
            Manager.AddConstantAction(PacketType.ActorMove, (ActorMove o) =>
            {
                if (!Map.IsFighting() && o.ActorId != MainPlayer().PlayerId)
                    Manager.Send(StartFight.GetPacket(o.ActorId, o.Pos));
            });
        }

        public void UpdateTableTurnCount()
        {
            Manager.AddConstantAction(PacketType.TableTurnBeggin, (TableTurnBeggin o) =>
            {
                Map.TableTurnCount = o.NumTurn;
            });
        }

        public void UpdateDespawn()
        {
            Manager.AddConstantAction(PacketType.Despawn, (Despawn o) =>
            {
                if (o.FightDespawn)
                    o.Actors.Keys.ForEach(i => Map.RemoveFighterOrSumm(i));
                else
                    o.Actors.Keys.ForEach(i => Map.RemoveWorldCharacter(i));
            });
        }

        public void UpdateMapFightStart()
        {
            Manager.AddConstantAction(PacketType.FightPlacementStart, (FightPlacementStart o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                Map.StartFight();
            });
        }

        public void UpdateFightStartInfo()
        {
            Manager.AddConstantAction(PacketType.FightCreation, (FightCreation o) =>
            {
                Map.FightId = o.FightId;
                o.Fighters.ForEach(f => {
                    var player = Map.GetPlayer(f.FighterId);
                    if (player == null)
                        return;
                    player.UpdateCharacteristiques(f.CharacteristiquesPart);
                    player.UpdatePosition(f.ChatacterPositionPart);
                });
            });
        }

        public void UpdateFightTurnCount()
        {
            Manager.AddConstantAction(PacketType.FighterTurnEnd, (FighterTurnEnd o) =>
            {
                Manager.Send(ConfirmTurnCount.GetPacket(Map.TurnCount++));
            });
        }

        public void AddSummonFight()
        {
            Manager.AddConstantAction(PacketType.RunningEffectAction, (RunningEffectAction o) =>
            {
                if (o.EffectType != RunningEffectType.SUMMON)
                    return;
                return;//running effect dosent work
                //Summon summon = (Summon)o.instance;
                //Map.AddSummon(summon);
            });
        }

        public void FightWhenEnterOnNewMap()
        {
            Manager.AddConstantAction(PacketType.MapInfo, (MapInfo info) =>
            {
                if (Map.IsFighting())
                    return;
                Manager.Send(Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault()?.FightPacket());
            });
        }

        public void FightNextOnFightEnd()
        {
            Manager.AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                Manager.Send(Map.GetFightableMobs(MainPlayer().GetPosition()).FirstOrDefault()?.FightPacket());
            });
        }


        public void AutoRespawn()
        {
            Manager.AddConstantAction(PacketType.FightEnd, (FightEnd o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                if (o.Loosers.Contains(MainPlayer().PlayerId))
                    Manager.Send(FreeSaoul.GetPacket());
            });
        }

        public void ReadyOnStart()
        {
            Manager.AddConstantAction(PacketType.FightPlacementStart, (FightPlacementStart o) =>
            {
                Manager.Send(ReadyFight.GetPacket());
            });
        }
    }
}
