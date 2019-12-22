using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketReceiv
{
    public class ProxyResult : AAuthBaseInMessage
    {
        public override AuthMessageType MessageType { get; set; } = AuthMessageType.PROXY_RESULT;

        public List<GameServer> GameServers = new List<GameServer>();
        public List<ServerConfig> ServerConfigs = new List<ServerConfig>();

        public ProxyResult(ByteReader rd)
        {
            int size = rd.ReadInt();
            for (int i = 0; i < size; i++)
            {
                GameServers.Add(new GameServer(rd));
            }
            size = rd.ReadInt();
            for (int i = 0; i < size; i++)
            {
                ServerConfigs.Add(new ServerConfig(rd));
            }
        }
    }

    public class GameServer
    {
        public int Id;
        public string Name;
        public int Community;
        public string Ip;
        public List<int> Ports = new List<int>();
        public byte Order;

        public GameServer(ByteReader rd)
        {
            rd.Read(out Id);
            int nameSize = rd.ReadInt();
            Name = Encoding.UTF8.GetString(rd.Read(nameSize));
            rd.Read(out Community);
            int ipSize = rd.ReadInt();
            Ip = Encoding.UTF8.GetString(rd.Read(ipSize));
            int portSize = rd.ReadInt();
            for (int i = 0; i < portSize; i++)
                Ports.Add(rd.ReadInt());
            rd.Read(out Order);
        }
    }


    public class ServerConfig
    {
        public int Id;
        public byte Version;
        public short Revision;
        public byte Change;
        public byte[] Build;
        public bool Locked;

        public Dictionary<short, string> Configs = new Dictionary<short, string>();

        public ServerConfig(ByteReader rd)
        {
            rd.Read(out Id);
            int versionSize = rd.ReadInt();
            rd.Read(out Version);
            rd.Read(out Revision);
            rd.Read(out Change);
            Build = rd.Read(rd.ReadByte());
            int configSize = rd.ReadInt();//configSize twice ?
            configSize = rd.ReadInt();
            for(int i = 0; i < configSize; i++)
            {
                short key = rd.ReadShort();
                int sringSize = rd.ReadInt();
                string config = Encoding.UTF8.GetString(rd.Read(sringSize));
                Configs[key] = config;
            }
            rd.Read(out Locked);
        }
    }
}
