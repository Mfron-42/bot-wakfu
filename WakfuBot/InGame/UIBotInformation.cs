using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using System.Threading;

namespace WakfuBot.WakfuBot
{
    static class UIBotInformation
    {
        public static WakfuDatas Manager;
        public static Map Map;
        public static BotActions BotActions;
        public static int RefreshTime = 100;

        public static void Init(WakfuDatas manager, Map map, BotActions botactions)
        {
            Map = map;
            BotActions = botactions;
            Manager = manager;
            new Thread(() => {
                while (true) {
                    MainForm.Invoke(() => MainForm.Instance.UpdateInfos(Manager, Map, BotActions));
                    Thread.Sleep(RefreshTime);
                }
            }).Start();
        }
    }
}
