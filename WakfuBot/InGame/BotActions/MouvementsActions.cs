using MoreLinq;
using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WakfuBot.WakfuBot.Bot.Actions
{
    public abstract class MouvementsActions
    {
        abstract protected Dictionary<long, APlayerService> Players { get; set; }
        virtual protected WakfuDatas Manager { get; set; }
        virtual protected Map Map { get; set; }

        public MouvementsActions(WakfuDatas manager, Map map)
        {
            this.Map = map;
            this.Manager = manager;
            this.FighterJoinUpdate();
            this.FightMoveUpdate();
            this.FightPlacementUpdate();
            this.FightTeleportMoveUpdate();
            this.WorldPlayerMoveUpdate();
        }


        private void FightTeleportMoveUpdate()
        {
            Manager.AddConstantAction(PacketType.RunningEffectAction, (RunningEffectAction o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                switch (o.EffectType)
                {
                    case RunningEffectType.EXCHANGE_POSITION:
                        {
                            var action = o.Message;
                            var caster = Map.GetPlayer(action.CasterId);
                            var target = Map.GetPlayer(action.TargetId);
                            caster?.UpdatePosition(action.SpellEffect.CasterPos.ToMapPosition());
                            target?.UpdatePosition(action.SpellEffect.TargetPos.ToMapPosition());
                            Map.UpdateFighterPos(action.TargetId, action.SpellEffect.TargetPos.ToMapPosition());
                            Map.UpdateFighterPos(action.CasterId, action.SpellEffect.CasterPos.ToMapPosition());
                            break;
                        }
                    case RunningEffectType.GET_CLOSER:
                        {
                            var action = o.Message;
                            var player = Map.GetPlayer(action.CasterId);
                            if (player != null)
                                player.UpdatePosition(action.SpellEffect.PositionInfos.Last());
                            Map.UpdateFighterPos(action.CasterId, action.SpellEffect.PositionInfos.Last());
                            break;
                        }
                    case RunningEffectType.PULL:
                        {
                            var action = o.Message;
                            var player = Map.GetPlayer(action.TargetId);
                            if (player != null)
                                player.UpdatePosition(action.SpellEffect.PositionInfos.Last());
                            Map.UpdateFighterPos(action.TargetId, action.SpellEffect.PositionInfos.Last());
                            break;
                        }
                    case RunningEffectType.PULL_ON_CASTER_BACK:
                        {
                            var action = o.Message;
                            var player = Map.GetPlayer(action.TargetId);
                            if (player != null)
                                player.UpdatePosition(action.Pos.ToMapPosition());
                            Map.UpdateFighterPos(action.TargetId, action.Pos.ToMapPosition());
                            break;
                        }
                    case RunningEffectType.PUSH:
                        {
                            var action = o.Message;
                            var player = Map.GetPlayer(action.TargetId);
                            if (player != null)
                                player.UpdatePosition(action.SpellEffect.PositionInfos.Last());
                            Map.UpdateFighterPos(action.TargetId, action.SpellEffect.PositionInfos.Last());
                            break;
                        }
                    case RunningEffectType.TELEPORT_TARGET:
                        {
                            var action = o.Message;

                            var player = Map.GetPlayer(action.TargetId);
                            if (player != null)
                                player.UpdatePosition(action.Pos.ToMapPosition());
                            Map.UpdateFighterPos(action.TargetId, action.Pos.ToMapPosition());
                            break;
                        }
                    case RunningEffectType.TELEPORT_CASTER_BEHIND_TARGET:
                        {
                            var action = o.Message;
                            var player = Map.GetPlayer(action.CasterId);
                            if (player != null)
                                player.UpdatePosition(action.Pos.ToMapPosition());
                            Map.UpdateFighterPos(action.CasterId, action.Pos.ToMapPosition());
                            break;
                        }
                    case RunningEffectType.TELEPORT_CASTER:
                        {
                            var action = o.Message;
                            var player = Map.GetPlayer(action.CasterId);
                            if (player != null)
                                player.UpdatePosition(action.Pos.ToMapPosition());
                            Map.UpdateFighterPos(action.CasterId, action.Pos.ToMapPosition());
                            break;
                        }
                }
            });
        }

        private void FightPlacementUpdate()
        {
            Manager.AddConstantAction(PacketType.FightersPlacementPositions, (FightersPlacementPositions o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                o.Placements.ForEach(placement =>
                {
                    var player = Map.GetPlayer(placement.Key);
                    if (player != null)
                        player.UpdatePosition(placement.Value);
                });
            });
        }

        private void FightMoveUpdate()
        {
            Manager.AddConstantAction(PacketType.FighterMove, (FighterMove o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                var player = Map.GetPlayer(o.FighterId);
                player?.UpdatePosition(o.Pos.Last());
                Map.UpdateFighterPos(o.FighterId, o.Pos.Last());
            });
        }

        private void FighterJoinUpdate()
        {
            Manager.AddConstantAction(PacketType.FightJoin, (FightJoin o) =>
            {
                if (o.FightId != Map.FightId)
                    return;
                var player = Map.GetPlayer(o.FighterId);
                player?.UpdatePosition(o.ChatacterPositionPart);
                player?.UpdateCharacteristiques(o.CharacteristiquesPart);
            });
        }


        private void WorldPlayerMoveUpdate()
        {
            Manager.AddConstantAction(PacketType.ActorMove, (ActorMove o) =>
            {
                var player = Map.GetPlayer(o.ActorId);
                player?.UpdatePosition(o.Pos);
                Map.UpdateWorldPos(o.ActorId, o.Pos);
            });
        }
    }
}
