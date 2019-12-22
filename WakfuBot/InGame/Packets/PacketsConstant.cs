using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects;
using PacketEditor.WakfuBot.Packets.ToReceiv.UknowUtility;
using PacketEditor.WakfuBot.PacketTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WakfuBot.Authentication.PacketReceiv;
using WakfuBot.InGame.Packets.ToReceiv.Market;
using WakfuBot.WakfuBot.Packets.ToReceiv;

namespace PacketEditor.WakfuBot
{
    public static class InGameNetwork
    {
        public static readonly Dictionary<PacketType, Type> Constructors = new Dictionary<PacketType, Type>(){
            {MapInfo.packetType, typeof(MapInfo)},
            {MarketConsultResult.packetType, typeof(MarketConsultResult)},
            {ReconnexionInformation.packetType, typeof(ReconnexionInformation)},
            {FighterChangeStatus.packetType, typeof(FighterChangeStatus)},
            {SpellCastNotification.packetType, typeof(SpellCastNotification) },
            {FighterMove.packetType, typeof(FighterMove) },
            {Despawn.packetType, typeof(Despawn) },
            {LeaveInstance.packetType, typeof(LeaveInstance) },
            {ChangeDirection.packetType, typeof(ChangeDirection) },
            {ActorMove.packetType, typeof(ActorMove) },
            {CharacterHealtUpdate.packetType, typeof(CharacterHealtUpdate) },
            {VicinityMessage.packetType, typeof(VicinityMessage) },
            {ItemIdCacheUpdate.packetType, typeof(ItemIdCacheUpdate) },
            {CharacterEnterWorld.packetType, typeof(CharacterEnterWorld) },
            {CharacterEnterPartition.packetType, typeof(CharacterEnterPartition) },
            {InteractiveElementSpawn.packetType, typeof(InteractiveElementSpawn) },
            {MonsterStateInfo.packetType, typeof(MonsterStateInfo) },
            {ActorStopMove.packetType, typeof(ActorStopMove) },
            {RunningEffectAction.packetType, typeof(RunningEffectAction) },
            {RunningEffectUnapplication.packetType, typeof(RunningEffectUnapplication) },
            {RunningEffectApplication.packetType, typeof(RunningEffectApplication) },
            {ExternalFightCreation.packetType, typeof(ExternalFightCreation) },
            {FightEnd.packetType, typeof(FightEnd) },
            {FighterTurnBegin.packetType, typeof(FighterTurnBegin) },
            {FighterTurnEnd.packetType, typeof(FighterTurnEnd) },
            {FightCreation.packetType, typeof(FightCreation) },
            {EndFightCreation.packetType, typeof(EndFightCreation) },
            {FightPlacementStart.packetType, typeof(FightPlacementStart) },
            {TableTurnBeggin.packetType, typeof(TableTurnBeggin) },
            {FightersPlacementPositions.packetType, typeof(FightersPlacementPositions) },
            {FightJoin.packetType, typeof(FightJoin) },
            {GameServerAuthResult.packetType, typeof(GameServerAuthResult) },
            {FightActionSequenceExecute.packetType, typeof(FightActionSequenceExecute) },
            {CharacterInformation.packetType, typeof(CharacterInformation) },
            {HeroCharacterInformation.packetType, typeof(HeroCharacterInformation) },
            {CharacterList.packetType, typeof(CharacterList) },
            {CompagnionList.packetType, typeof(CompagnionList) },
            {PacketType.ClientVersion, typeof(ClientVersion) },
            {PacketType.ClientIp, typeof(ClientIp) },
            {PacketType.PublicKey, typeof(PublicKey) },
        };
    }

    public enum PacketType : short
    {
        MarketResult = 20100,
        ReconnexionInformation = 8044,
        CompagnionList = 2077,
        HeroCharacterInfo = 5565,
        CharacterInfo = 4098,
        MapInfo = 4102,
        FightActionSequenceExecute = 8200,
        CharacterList = 2048,
        GameServerAuthResult = 1025,
        ClientIp = 110,
        ClientVersion = 8,
        PublicKey = 1034,
        EffectApplication = 8124,
        FighterMove = 4524,
        SpellCastNotif = 8116,
        FighterStatusChange = 4520,
        ActorMove = 4127,
        ChangeDirection = 4118,
        LeaveInstance = 4128,
        Despawn = 4104,
        CharacterHealtUpdate = 4124,
        VicinityChat = 3152,
        CharacterEnterWorld = 4100,
        ItemIdCacheUpdate = 5300,
        CharacterEnterPartition = 4125,
        InteractiveElementSpawn = 200,
        MonsterStateInfo = 4112,
        ActorStopMove = 4115,
        RunningEffectAction = 8120,
        RunningEffectUnapplication = 8122,
        RunningEffectApplication = 8124,
        ExternalFightCreation = 8006,
        FighterTurnBegin = 8104,
        FighterTurnEnd = 8106,
        FightEnd = 8300,
        EndFightCreation = 8202,
        FightCreation = 8000,
        FightPlacementStart = 8026,
        TableTurnBeggin = 8100,
        FightersPlacementPositions = 7906,
        FightJoin = 8002
    };
}
