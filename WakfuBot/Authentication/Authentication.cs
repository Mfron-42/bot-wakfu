using MoreLinq;
using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using WakfuBot.Authentication.PacketReceiv;
using WakfuBot.Authentication.Packets;
using WakfuBot.Authentication.PacketSend;
using WakfuBot.Properties;

namespace WakfuBot.Authentication
{
    public class AuthenticationAccount
    {
        private static IPEndPoint AuthServer = new IPEndPoint(IPAddress.Parse(Settings.Default.AuthIp), Settings.Default.AuthPort);
        private Dictionary<AuthMessageType, List<Action<object>>> ConstantActionStack = InitActionStack();
        private Dictionary<AuthMessageType, List<Action<object>>> OneExecutionActionStack = InitActionStack();
        private ByteReader Data = new ByteReader(new byte[0]);
        private Socket Socket;
        private AuthResult AuthRes;
        public GameServer gameServer;
        public WakfuDatas Manager;
        private string Account;
        private string Password;
        private TreeNode NodeInfos;
        
        
        public AuthenticationAccount(string account, string password)
        {
            NodeInfos = new TreeNode("Authentication");
            MainForm.Invoke(() => MainForm.Tree.Nodes.Add(NodeInfos));
            Account = account;
            Password = password;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            Socket.Connect(AuthServer);
            SubscribeActions();
            Send(SendClientVersion.GetPacket());
            ReadSocket();
        }

        private void SubscribeActions()
        {
            AddOneExecutionAction(AuthMessageType.PUBLIC_KEY, (PublicKey o) =>
            {
                Send(Login.GetPacket(Account, Password, o.Salt, o.Key));
            });
            AddOneExecutionAction(AuthMessageType.CLIENT_VERSION, (ClientVersion o) =>
            {
                Send(PublicKeyRequest.GetPacket());
            });
            AddOneExecutionAction(AuthMessageType.AUTH_RESULT, (AuthResult o) =>
            {
                if (o.ResultCode != 0)
                    throw new Exception("Login Error");
                Send(ProxyRequest.GetPacket());
                AuthRes = o;
            });
            AddOneExecutionAction(AuthMessageType.PROXY_RESULT, (ProxyResult o) =>
            {
                gameServer = o.GameServers.FirstOrDefault(i => i.Name == Settings.Default.ServerName);
                Send(GameServerConnect.GetPacket(gameServer.Id, AuthRes.AccountId));
            });
            AddOneExecutionAction(AuthMessageType.AUTH_GAME_SERVER, (AuthGameServer o) =>
            {
                Socket.Disconnect(false);
                Manager = new WakfuDatas(this, o);
                new Thread(() => Manager.Connect()).Start();
            });
        }

        private void Send(byte[] data)
        {
            MainForm.Invoke(() => NodeInfos.Nodes.Add(data.ToHxString()));
            Socket.Send(data);
        }

        private void ReadSocket()
        {
            while (Socket.Connected)
            {
                var rd = new ByteReader(new byte[Socket.Available]);
                Socket.Receive(rd.Data);
                ReadData(rd);
            }
        }

        private void ReadData(ByteReader rd)
        {
            Data.AddRange(rd.ReadAll());
            while (Data.Remaining() > 1)
            {
                short size = Data.ReadShort();
                if (size > Data.Remaining() + 2)
                    return;
                AuthMessageType messageType = (AuthMessageType)Data.ReadShort();
                ByteReader packet = new ByteReader(Data.Read(size - 4));

                MainForm.Invoke(() => NodeInfos.Nodes.Add(messageType.ToString()));
                if (AuthNetworkMessages.Constructors.TryGetValue(messageType, out Type type))
                {
                    var inst = type.GetConstructor(new[] { typeof(ByteReader) }).Invoke(new object[] { packet });
                    ConstantActionStack[messageType].ToArray().ForEach(i => i.Invoke(inst));
                    var save = OneExecutionActionStack[messageType].ToArray();
                    OneExecutionActionStack[messageType].Clear();
                    save.ForEach(i => i.Invoke(inst));
                }
            }
        }

        private static Dictionary<AuthMessageType, List<Action<object>>> InitActionStack()
        {
            var actionStack = new Dictionary<AuthMessageType, List<Action<object>>>();
            foreach (AuthMessageType p in Enum.GetValues(typeof(AuthMessageType)))
                actionStack[p] = new List<Action<object>>();
            return actionStack;
        }


        private void AddConstantAction<T>(AuthMessageType messageType, Action<T> call)
        {
            ConstantActionStack[messageType].Add((obj) => call((T)obj));
        }

        private void AddOneExecutionAction<T>(AuthMessageType messageType, Action<T> call)
        {
            OneExecutionActionStack[messageType].Add((obj) => call((T)obj));
        }
    }

}
