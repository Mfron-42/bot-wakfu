using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WakfuBot.InGame.Enums;

namespace PacketEditor.WakfuBot.Bot.Actions
{
    public class DonjonsActions
    {
        private WakfuDatas Manager;
        private BotActions BotActions;

        public DonjonsActions(WakfuDatas manager, BotActions botActions)
        {
            Manager = manager;
            BotActions = botActions;
        }

        public async void LeavePepePaleSalle()
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(new MapPosition(-2, 0).GoToXFirst(new MapPosition(0, 0))));
            //300ms by cell
            await Task.Delay(3000);
            // We move one cell in front of the teleporter to avoid
            // that the server refuse the TeleportAction
            Manager.Send(ActorPathRequestMessage.GetPacket(new MapPosition(0, 0).GoToXFirst(new MapPosition(1, 0))));
            Manager.Send(TeleportAction.GetPacket(23866, 2022, 11));
        }

        public void EnterPepePaleSalle()
        {
            Manager.Send(TeleportAction.GetPacket(23872, 2021, 11));
        }


        public void LeaveSaleDjCrack(byte djLvl)
        {
            var pathMove = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(1, 0));

            Manager.Send(ActorPathRequestMessage.GetPacket(pathMove));
            Manager.Send(TeleportAction.GetPacket(18689498649185536, 11));

            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o) =>
            {
                Manager.Send(TeleportAction.GetPacket(19090820393323520, djLvl));
            });

        }

        public void LeaveSalleRat(byte djLvl)
        {
            var pathMove = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(11, -87));
            Manager.Send(ActorPathRequestMessage.GetPacket(pathMove));
            Manager.Send(TeleportAction.GetPacket(29095276694511360, 11));
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o)
                => Manager.Send(TeleportAction.GetPacket(20901716044333312, 1)));
        }
        
        public async Task LeaveDjGhostBonta()
        {
            var pathMove = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition()
            {
                X = 0,
                Y = 0
            }).AddBytes(0xA2, 0xA2, 0xE2, 0xE2);//monte escaliers
            Manager.Send(ActorPathRequestMessage.GetPacket(pathMove));
            while (BotActions.MainPlayer().GetPosition() == new MapPosition(3, -5, 0))
            {
                Manager.SendBytes(new byte[] { 0x00, 0x11, 0x03, 0x00, 0xC9, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5F, 0xB3, 0x00, 0x05, 0x00, 0x00 });//utilise la sortie
                await Task.Delay(50);
            }
        }

        public void EnterDjGhostBonta(int djLvl)
        {
            Manager.Send(TeleportAction.GetPacket(16026481486991872, djLvl));
        }

        public void LeaveSaleArbraknyde(byte djLvl)
        {
            var pathMove = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(1, -8));
            Manager.Send(ActorPathRequestMessage.GetPacket(pathMove));
            Manager.SendBytes(0x00, 0x17, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x01, 0xFF, 0xFF, 0xFF, 0xF8, 0x00, 0x00, 0x07, 0x60, 0x60, 0x60, 0x60, 0x60, 0x60, 0x9F);
            Manager.Send(TeleportAction.GetPacket(18623527951516928, 11));
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o) =>
            {
                Manager.SendBytes(0x00, 0x11, 0x03, 0x00, 0xC9, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5F, 0xC1, 0x00, 0x05, 0x00, 0x00);
                Manager.Send(TeleportAction.GetPacket(18621328928261120, djLvl));
            });
        }

        public void LeaveSaleBoufCeleste(byte djLvl)
        {
            var pathMove = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(0, -10));
            Manager.Send(ActorPathRequestMessage.GetPacket(pathMove));
            Manager.SendBytes(0x00, 0x1B, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xF6, 0x00, 0x04, 0x0B, 0x60, 0x7F, 0x7F, 0x7E, 0x60, 0x60, 0x60, 0x63, 0x64, 0x62, 0x60);
            Manager.SendBytes(0x00, 0x11, 0x03, 0x00, 0xC9, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x5F, 0xC1, 0x00, 0x05, 0x00, 0x00);
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o) =>
            {
                Manager.Send(TeleportAction.GetPacket(19804403439761152, djLvl));
            });
        }

        public void LeaveDjTsar(byte djLvl)
        {
            var exit = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition()
            {
                X = 7,
                Y = 7
            });
            Manager.Send(ActorPathRequestMessage.GetPacket(exit));
            Manager.SendBytes(new byte[] { 0x00, 0x16, 0x03, 0x00, 0xCD, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x17, 0x67, 0x00, 0x00, 0x00, 0x87, 0x00, 0x00, 0x00, 0x00, 0x0B });
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o)
                => Manager.SendBytes(new byte[] { 0x00, 0x16, 0x03, 0x00, 0xCD, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x38, 0xEE, 0x00, 0x00, 0x02, 0xE3, 0x00, 0x00, 0x00, 0x00, djLvl }));//ghosto
        }

        public void LeaveFinDjChat()
        {
//            var moveToExit = new byte[] { 0x00, 0x16, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x12, 0xFF, 0xFF, 0xFF, 0xFC, 0xFF, 0xF5, 0x06, 0x00, 0x00, 0x00, 0xE0, 0xE0, 0xE0 };
//            Manager.Send(moveToExit);
            var exit = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(21,-10));
            Manager.Send(ActorPathRequestMessage.GetPacket(exit));
            Manager.Send(TeleportAction.GetPacket(14514, 704, 11));
        }

        public void LeaveFirstSalleChat()//1.66.1
        {
            var exit = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(0,0));
            Manager.Send(ActorPathRequestMessage.GetPacket(exit));
            Manager.Send(TeleportAction.GetPacket(14513, 704));
        }
        
        public void EntrerDjChat(int djLvl)//1.66.1
            => Manager.Send(TeleportAction.GetPacket(18736, 713, djLvl));

        public void LeaveDjSkoual(int djLvl)
        {
            var exit = BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition()
            {
                X = -1,
                Y = -1
            });
            Manager.Send(ActorPathRequestMessage.GetPacket(exit));
            Manager.Send(TeleportAction.GetPacket(18684001091046144, 11));
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o)
                => Manager.Send(TeleportAction.GetPacket(30501552066382336, djLvl)));
        }

        public void LeaveDjPerlouze(int djLvl)
        {
            MapPosition bossStep1 = new MapPosition()
            {
                X = -59,
                Y = -28,
                Z = -12
            };
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(bossStep1)));
            Manager.SendBytes(new byte[] { 0x00, 0x1C, 0x03, 0x10, 0x11, 0xFF, 0xFF, 0xFF, 0xC5, 0xFF, 0xFF, 0xFF, 0xE4, 0xFF, 0xF4, 0x0C, 0xDF, 0xA0, 0xA0, 0xBF, 0xE0, 0xE0, 0xE0, 0xE0, 0xE2, 0xE3, 0xE0, 0xA0 });
            Manager.Send(TeleportAction.GetPacket(18671906463140096, 11));
        }

        public void LeaveGeleeFirstSalle(int djLvl)
        {
            MapPosition bossStep1 = new MapPosition(0, 1);
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(bossStep1)));

            Manager.SendBytes(new byte[] { 0x00, 0x19, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x09, 0x60, 0x62, 0x62, 0x60, 0x7E, 0x7E, 0x60, 0x60, 0x80 });
            Manager.Send(TeleportAction.GetPacket(21071040835015680, 11));

            Manager.SendBytes(new byte[] { 0x00, 0x11, 0x03, 0x10, 0x11, 0xFF, 0xFF, 0xFF, 0xF3, 0xFF, 0xFF, 0xFF, 0xCE, 0x00, 0x14, 0x01, 0xE0 });
            Manager.Send(TeleportAction.GetPacket(21583413253559040, djLvl));
        }

        public void EnterDjPerlouze(int djLvl)
        {
            Manager.Send(TeleportAction.GetPacket(18666408905000960, djLvl));
        }

        public void LeaveSallePerlouze(int djLvl)
        {
            MapPosition moveExit = new MapPosition()
            {
                X = 1,
                Y = 0,
                Z = 0
            };
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(moveExit)));
            Manager.Send(TeleportAction.GetPacket(18667508416628992, 11));
        }

        public void LeaveBlackWabbit(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(-2, -15, -7))));
            Manager.SendBytes(new byte[] { 0x00, 0x20, 0x03, 0x10, 0x11, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xF1, 0xFF, 0xF9, 0x10, 0x40, 0x40, 0x60, 0x60, 0x60, 0x60, 0x61, 0x61, 0x61, 0x60, 0x61, 0x61, 0x60, 0x61, 0x61, 0x61 });
            Manager.Send(TeleportAction.GetPacket(21382202625689344, 11));
            Manager.Send(TeleportAction.GetPacket(21397595788477952, djLvl));
        }

        public void LeaveDjWa(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(0, -5))));
            Manager.Send(ActorPathRequestMessage.GetPacket(new MapPosition(0, -5).GoToXFirst(new MapPosition(0, 1))));
            Manager.Send(TeleportAction.GetPacket(21826405323328768, 11));
            Manager.Send(TeleportAction.GetPacket(21750539021013248, djLvl));
        }

        public void LeaveFirstSalleCroco(int djLvl)
        {
            throw new NotImplementedException();
        }

        public void LeaveDjPhorreur(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition())));
            Manager.Send(TeleportAction.GetPacket(30553229113309696, 11));
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o)
                => Manager.Send(TeleportAction.GetPacket(30547731555170560, djLvl)));
        }

        public void LeaveSaleEnutro()
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(0, 1))));
            Manager.Send(TeleportAction.GetPacket(24574084881250304, 11));
        }

        public void EnterDjEnutro(int djLvl) =>
           Manager.Send(TeleportAction.GetPacket(24997396857944320, djLvl));

        public void LeaveDjSrambad()
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(1, 0))));
            Manager.Send(TeleportAction.GetPacket(24568587323093248, 11));
        }

        public void EnterDjSrambad(int djLvl) =>
            Manager.Send(TeleportAction.GetPacket(26927039764670208, djLvl));

        public void LeaveDjHiboux()
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(0, 1))));
            Manager.Send(TeleportAction.GetPacket(27227206439154176, 11));
        }

        public void EnterDjHiboux(int djLvl) =>
            Manager.Send(TeleportAction.GetPacket(27261291299615744, djLvl));


        public void LeaveDjChaferAstrub()
        {
            var pathMove = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition()
            {
                X = 1,//idk
                Y = 0
            });
            Manager.Send(ActorPathRequestMessage.GetPacket(pathMove));
            Manager.Send(TeleportAction.GetPacket(26269531811337984, 11));
        }

        public void LeaveSalleChaferAstrub()
        {
            var exit = BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(1, 0));
            Manager.Send(ActorPathRequestMessage.GetPacket(exit));
            Manager.Send(TeleportAction.GetPacket(26264034253199104, 11));
        }

        public void EnterDjChaferAstrub(int djLvl) =>
            Manager.Send(TeleportAction.GetPacket(26415766857831936, djLvl));

        public void LeaveSaleSplit(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(0, -8))));
            Manager.SendBytes(0x00, 0x19, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xF8, 0x00, 0x00, 0x09, 0x60, 0x7E, 0x7C, 0x7C, 0x7C, 0x7C, 0x7E, 0x60, 0x60);
            Manager.Send(TeleportAction.GetPacket(15400859370435584, 11));
            Manager.Send(TeleportAction.GetPacket(15716419207610112, djLvl));
        }


        public void LeaveFirstSaleMeka(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToYFirst(new MapPosition(7, 11))));
            Manager.Send(ActorPathRequestMessage.GetPacket(new MapPosition(7, 11).GoToYFirst(new MapPosition(7, 19))));

            Manager.Send(TeleportAction.GetPacket(19816498067684352, 11));
            //   Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o)
            Manager.Send(TeleportAction.GetPacket(19830791718845184, djLvl));
        }

        public void LeaveDjSplit(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(208, 97))));
            Manager.SendBytes(new byte[] { 0x00, 0x16, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0xD0, 0x00, 0x00, 0x00, 0x61, 0x00, 0x00, 0x06, 0x01, 0x01, 0xE0, 0xE0, 0xE0, 0xE0 });
            Manager.Send(TeleportAction.GetPacket(15400859370435584, 11));
            Manager.AddOneExecutionAction(PacketType.InteractiveElementSpawn, (InteractiveElementSpawn o)
                => Manager.Send(TeleportAction.GetPacket(15716419207610112, djLvl)));
        }

        public void LeaveSalleKaniboule(int djLvl)
        {
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(0, 1))));
            Manager.Send(TeleportAction.GetPacket(28118910369374720, 11));
            Manager.Send(TeleportAction.GetPacket(28112313299557632, djLvl));
        }

        public void LeaveDjSacri(int djLvl)
        {
            if (BotActions.MainPlayer().GetPosition().Z == 4)
            {
                Manager.SendBytes(new byte[] { 0x00, 0x11, 0x03, 0x10, 0x11 }.Concat(BotActions.MainPlayer().GetPosition().GetBytes()).Concat(new byte[] { 0x01, 0x3C }).ToArray());
                BotActions.MainPlayer().GetPosition().X++;
                BotActions.MainPlayer().GetPosition().Z = 0;
            }
            Manager.Send(ActorPathRequestMessage.GetPacket(BotActions.MainPlayer().GetPosition().GoToXFirst(new MapPosition(0, 1))));
            Manager.Send(TeleportAction.GetPacket(30260759020323840, 11));
            Manager.SendBytes(new byte[] { 0x00, 0x11, 0x03, 0x10, 0x11, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xBA, 0x00, 0x00, 0x01, 0xE0 });
            Manager.Send(TeleportAction.GetPacket(30736847555150592, djLvl));
        }
    }
}
