using MoreLinq;
using PacketEditor.WakfuBot.Bot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToReceiv.UknowUtility;
using PacketEditor.WakfuBot.PacketTypes;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WakfuBot;
using WakfuBot.Authentication;
using WakfuBot.Authentication.PacketReceiv;
using WakfuBot.Authentication.Packets;
using WakfuBot.Authentication.PacketSend;
using WakfuBot.InGame.Packets.ToSend;
using WakfuBot.WakfuBot;
using WakfuBot.WakfuBot.Bot.Actions.ActionsConfig;
using WakfuBot.WakfuBot.Bot.Players;
using WakfuBot.WakfuBot.Packets.ToReceiv;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace PacketEditor.WakfuBot
{
    public class WakfuDatas
    {
        private Dictionary<PacketType, List<Action<object>>> ConstantActionStack = InitActionStack();
        private Dictionary<PacketType, List<Action<object>>> OneExecutionActionStack = InitActionStack();
        private List<ISelectableCharacter> SelectableCharacters = new List<ISelectableCharacter>();
        private AuthGameServer AuthGameServer;
        private AuthenticationAccount Auth;
        private byte[] Save = new byte[0];
        private Socket Socket;
        private TreeNode NodeInfos;
        private BotActions BotActions;
        private bool Sleep = false;
        private Map Map;
        
        public static Dictionary<PacketType, List<Action<object>>> InitActionStack()
        {
            var actionStack = new Dictionary<PacketType, List<Action<object>>>();
            foreach (PacketType p in Enum.GetValues(typeof(PacketType)))
                actionStack[p] = new List<Action<object>>();
            return actionStack;
        }

        public WakfuDatas(AuthenticationAccount auth, AuthGameServer authGameServer)
        {
            NodeInfos = new TreeNode("Game");
            MainForm.Invoke(() => MainForm.Tree.Nodes.Add(NodeInfos));
            Auth = auth;
            AuthGameServer = authGameServer;
            SubscribeActions();
            Map = new Map(this);
            BotActions = new BotActions(this, Map);
            UIBotInformation.Init(this, Map, BotActions);
        }

        public void Connect() => ConnectSocket(Auth.gameServer);

        private void ConnectSocket(GameServer gameServer)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPAddress ip;
            try
            {
                ip = IPAddress.Parse(gameServer.Ip);
            }
            catch (Exception e)
            {
                ip = Dns.GetHostEntry(gameServer.Ip).AddressList.First();
            }
            
            IPEndPoint serverEndPoint = new IPEndPoint(ip, gameServer.Ports.First());
            try
            {
                Socket.Connect(serverEndPoint);
                ReadSocket();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.ErrorCode);
                throw;
            }
        }

        public void Write(string msg, Color color)
        {
            TreeNode treeNode = new TreeNode(msg)
            {
                BackColor = color
            };
            MainForm.Invoke(() => NodeInfos.Nodes.Add(treeNode));
            return;
        }

        private void ReadSocket()
        {
            byte[] dest = new byte[ushort.MaxValue];
            while (Socket.Connected)
            {
                int size = Socket.Receive(dest);
                ReadData(dest.Take(size).ToArray());
            }
        }

        private void ReadData(byte[] newData)
        {
            Save = Save.Concat(newData).ToArray();
            while (Save.Length > 1)
            {
                ushort size = Save.GetUShort();
                if (size > Save.Length)
                    return;
                ByteReader rd = new ByteReader(Save.Take(size).Skip(2).ToArray());
                Save = Save.Skip(size).ToArray();
                PacketType messageType = (PacketType)rd.ReadShort();

                
                Write(messageType.ToString(), Color.Orange);

                //var searched = new byte[] { 0x08, 0xAF, 0x1D, 0x10 };
                //if (Enumerable.Range(0, rd.Data.Length).Any(i => rd.Data.Skip(i).Take(searched.Length).SequenceEqual(searched))){

                //}

                if (InGameNetwork.Constructors.TryGetValue(messageType, out Type type))
                {
                    var inst = type.GetConstructor(new[] { typeof(ByteReader) }).Invoke(new object[] { rd });
                    var constantExecution = ConstantActionStack[messageType].ToArray();
                    var singleExecution = OneExecutionActionStack[messageType].ToArray();
                    OneExecutionActionStack[messageType].Clear();
                    
                    constantExecution.ForEach(i => i.Invoke(inst));
                    singleExecution.ForEach(i => i.Invoke(inst));
                }
            }
        }

        public void BegginNearestFight()
            => Send(Map.GetFightableMobs(BotActions.MainPlayer().GetPosition()).FirstOrDefault()?.FightPacket());

        private void SubscribeActions()
        {
            AddOneExecutionAction(PacketType.DefaultResultsMessage, (DefaultResultsMessage o) =>
            {
                SendBytes(SendClientVersion.GetPacket());
            });
            AddOneExecutionAction(PacketType.ClientVersion, (ClientVersion o) =>
            {
                SendBytes(PublicKeyRequest.GetPacket(1));
            });
            AddOneExecutionAction(PacketType.PublicKey, (PublicKey o) =>
            {
                Send(GameServerKey.GetPacket(AuthGameServer.Token));
            });
            AddOneExecutionAction(PacketType.CharacterList, (CharacterList o) =>
            {
                SelectableCharacters.AddRange(o.Characters);
                MainForm.Invoke(() => MainForm.Instance.AddPlayers(o.Characters.Select(h => h.DisplayName()).ToArray()));
            });
            AddOneExecutionAction(PacketType.CompagnionList, (CompagnionList o) =>
            {
                SelectableCharacters.AddRange(o.Compagnions);
                MainForm.Invoke(() => MainForm.Instance.AddPlayers(o.Compagnions.Select(h => h.DisplayName()).ToArray()));
            });
        }

        public bool SelectPlayer(string name)
        {
            if (Map.GetPlayers().Any())
                return false;
            var character = SelectableCharacters.First(i => i.DisplayName() == name);
            if (!PlayersConstants.ExistIA(character))
                return false;
            AddPlayer(character);
            Send(SelectCharacter.GetPacket(character.Id, character.DisplayName()));
            MainForm.Invoke(() => NodeInfos.Nodes.Add("<- select player " + character.DisplayName()));
            return true;
        }

        public void SendBytes(params byte[] data)
        {
            Send(data);
            SendMessageType type = (SendMessageType)data.Skip(3).Take(2).ToArray().GetShort();
            Write("Data : " + type, Color.Pink);
        }


        public void Send(IPacket data)
        {
            Write(data.ToString(), Color.Pink);
            Send(data.GetBytes());
        }

        private void Send(byte[] data)
        {
            if (Sleep || data == null)
                return;
            Socket.BeginSend(data, 0, data.Length, SocketFlags.None, null, null);
        }

        public bool AddHero(string name)
        {
            if (Map.GetPlayers().Any(p => p.Name == name))
                return false;
            ISelectableCharacter character = SelectableCharacters.FirstOrDefault(i => i.DisplayName() == name);
            if (!PlayersConstants.ExistIA(character))
                return false;
            AddPlayer(character);
            Send(character.GetSelectionPacket());
            return true;
        }

        public void AddPlayer(ISelectableCharacter character)
        {
            var player = APlayerService.Get(character, this, Map);
            Map.AddPlayer(player);
            BotActions.AddPlayer(player);
        }

        public void SetSleep(bool sleep) => Sleep = sleep;

        public Action<object> AddConstantAction<T>(PacketType packetType, Action<T> call)
        {
            var action = new Action<object>((o) => call((T)o));
            ConstantActionStack[packetType].Add((o) => call((T)o));
            return action;
        }

        public Action<object> AddOneExecutionAction<T>(PacketType packetType, Action<T> call)
        {
            var action = new Action<object>((o) => call((T)o));
            OneExecutionActionStack[packetType].Add(action);
            return action;
        }

        public void RemoveConstantAction(Action<object> call)
        {
            ConstantActionStack = ConstantActionStack
                .ToDictionary(pair => pair.Key, pair => pair.Value.Where(v => v != call).ToList());
        }

        public ABotActionConfig CreateActionsConfig(string name, int stasisLvl)
            => BotActions.CreateBotActions(name, stasisLvl);

        public void RemoveOneExecutionAction(Action<object> call)
        {
            OneExecutionActionStack = ConstantActionStack
                .ToDictionary(pair => pair.Key, pair => pair.Value.Where(v => v != call).ToList());
        }
    }
}
