using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public abstract class ABotActionConfig
    {
        protected Dictionary<long, APlayerService> Players;
        private WakfuDatas Manager;
        protected Map Map;
        protected DonjonsActions DonjonsActions;
        protected int DjLvl;
        protected int SaleNumber;
        protected bool Play = false;
        public static string Name { get; set; } = "Unamed";

        private List<Action<object>> SavedConstantExecutionActions = new List<Action<object>>();
        private List<Action<object>> SavedOneExecutionActions = new List<Action<object>>();

        public ABotActionConfig(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
        {
            DjLvl = djLvl;
            Map = map;
            Manager = manager;
            DonjonsActions = donjonsActions;
            Players = players;
        }

        protected void Send(params byte[] bytes)
            => Manager.SendBytes(bytes);

        protected void Write(string message)
            => Manager.Write(message);

        public abstract void AddConfig();

        public void Load()
        {
            AddConfig();
        }

        public void Unload()
        {
            RemoveConfig();
        }

        public virtual void Stop() => Play = false;

        public virtual void Start() => Play = true;

        protected void AddConstantAction<T>(PacketType packetType, Action<T> call)
        {
            SavedConstantExecutionActions.Add(Manager.AddConstantAction(packetType, call));
        }

        protected void AddOneExecutionAction<T>(PacketType packetType, Action<T> call)
        {
            SavedOneExecutionActions.Add(Manager.AddOneExecutionAction(packetType, call));
        }
        
        private void RemoveConfig()
        {
            SavedConstantExecutionActions.ForEach(a => Manager.RemoveConstantAction(a));
            SavedOneExecutionActions.ForEach(a => Manager.RemoveOneExecutionAction(a));
        }

        protected APlayerService MainPlayer() => Players.First().Value;
    }
}
