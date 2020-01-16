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
        public static readonly Dictionary<PacketType, Type> Constructors = new Dictionary<PacketType, Type>{
//            {MarketConsultResult.packetType, typeof(MarketConsultResult)},
//            {ReconnexionInformation.packetType, typeof(ReconnexionInformation)},
//            {VicinityMessage.packetType, typeof(VicinityMessage) },
//            {ItemIdCacheUpdate.packetType, typeof(ItemIdCacheUpdate) },
//            {CharacterEnterPartition.packetType, typeof(CharacterEnterPartition) },
//            {ExternalFightCreation.packetType, typeof(ExternalFightCreation) },
//            {HeroCharacterInformation.packetType, typeof(HeroCharacterInformation) },
            {FighterChangeStatus.packetType, typeof(FighterChangeStatus)},
            {SpellCastNotification.packetType, typeof(SpellCastNotification) },
            {FighterMove.packetType, typeof(FighterMove) },
            {Despawn.packetType, typeof(Despawn) },
            {LeaveInstance.packetType, typeof(LeaveInstance) },
            {ChangeDirection.packetType, typeof(ChangeDirection) },
            {ActorMove.packetType, typeof(ActorMove) },
            {CharacterHealtUpdate.packetType, typeof(CharacterHealtUpdate) },
            {InteractiveElementSpawn.packetType, typeof(InteractiveElementSpawn) },
            {MonsterStateInfo.packetType, typeof(MonsterStateInfo) },
            {ActorStopMove.packetType, typeof(ActorStopMove) },
            {RunningEffectAction.packetType, typeof(RunningEffectAction) },
            {RunningEffectUnapplication.packetType, typeof(RunningEffectUnapplication) },
            {RunningEffectApplication.packetType, typeof(RunningEffectApplication) },
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
            {MapInfo.packetType, typeof(MapInfo)},
            {CharacterEnterWorld.packetType, typeof(CharacterEnterWorld) },
            {CharacterInformation.packetType, typeof(CharacterInformation) },
            {CharacterList.packetType, typeof(CharacterList) },
            {CompagnionList.packetType, typeof(CompagnionList) },
            {PacketType.ClientVersion, typeof(ClientVersion) },
            {PacketType.PublicKey, typeof(PublicKey) },
            {PacketType.DefaultResultsMessage, typeof(DefaultResultsMessage) }
        };
    }

    public enum PacketType : short
    {
        ClientVersion = 11,
        DefaultResultsMessage = 373,// packet envoyé a l'établissement de la connection
        PublicKey = 422,
        GameServerAuthResult = 515,//515: ClientAuthenticationResultsMessage
        CharacterInfo = 12696, //12696: CharacterInformationMessage
        FightJoin = 13381, //13381: FightJoinMessage
        CharacterEnterWorld = 13197, //13197: CharacterEnterWorldMessage
        ItemIdCacheUpdate = 13649, //13649: ItemIdCacheUpdateMessage
        CharacterEnterPartition = 13915, //13915: CharacterEnterPartitionMessage
        CharacterList = 16873,//16873: ServerCharactersListMessage
        CompagnionList = 17770, //17770: CompanionListMessage
        MarketResult = 14409,//14409: MarketConsultResultMessage
        ReconnexionInformation = 12354,//12354: CharacterDataForReconnectionMessage
        HeroCharacterInfo = 13011,//13011 HeroAddedMessage
        MapInfo = 13402,//13402 ?ActorSpawnMessage?
        FightActionSequenceExecute = 13120,//13120: FightActionSequenceExecuteMessage
        FighterMove = 12585,//12585: FighterMoveMessage
        SpellCastNotif = 12104, //12104: SpellCastNotificationMessage
        FighterStatusChange = 13631,//13631: FighterActivityChangeMessage
        ActorMove = 13695,//13695: ActorMoveToMessage //TODO /!\ le packet a changé => 1bit a la fin pour indiquer le type de déplacement (monture/nager...)
        ChangeDirection = 13770,//13770: ActorChangeDirectionMessage
        LeaveInstance = 13380,//13380: ActorLeaveInstanceMessage
        Despawn = 13185,//13185: ActorDespawnMessage
        CharacterHealtUpdate = 12363,//12363: CharacterHealthUpdateMessage
        VicinityChat = 614,//614: VicinityContentMessage
        InteractiveElementSpawn = 12183,//12183: InteractiveElementSpawnMessage
        MonsterStateInfo = 13738,//13738: MonsterStateMessage
        ActorStopMove = 13637,//13637: ActorStopMovementMessage
        RunningEffectAction = 13366, //13366: RunningEffectActionMessage
        RunningEffectUnapplication = 12373,//12373: RunningEffectUnapplicationMessage
        RunningEffectApplication = 13848,//12183: InteractiveElementSpawnMessage
        ExternalFightCreation = 12118,//12118: ExternalFightCreationMessage
        FighterTurnBegin = 13030,//13030: FighterTurnBeginMessage
        FighterTurnEnd = 12131,//12131: FighterTurnEndMessage
        FightEnd = 13116,//13116: EndFightMessage
        EndFightCreation = 12340,//12340: EndFightCreationMessage
        FightCreation = 13723,//13723 FightCreationMessage
        FightPlacementStart = 12719,//12719: FightPlacementStartMessage
        TableTurnBeggin = 13898,//13898: TableTurnBeginMessage
        FightersPlacementPositions = 12970,//12970: FightersPlacementPositionMessage
    };
}
