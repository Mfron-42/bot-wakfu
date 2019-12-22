using MoreLinq;
using Newtonsoft.Json;
using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Bot.Actions;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight;
using PacketEditor.WakfuBot.Packets.ToSend;
using PacketEditor.WakfuBot.Packets.Utility;
using PacketEditor.WakfuBot.Players;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WakfuBot.InGame.Packets.ToReceiv.Market;
using WakfuBot.WakfuBot.Packets.ToSend;

namespace WakfuBot.WakfuBot.Bot.Actions.ActionsConfig
{
    public class MarketPlaceDataSniffer : ABotActionConfig
    {
        public static new string Name { get; set; } = "Sniffer Market";
        
        public List<MarketItemInfos> Items = new List<MarketItemInfos>();
        public short Index;

        public MarketPlaceDataSniffer(WakfuDatas manager, Map map, Dictionary<long, APlayerService> players, DonjonsActions donjonsActions, int djLvl)
            : base(manager, map, players, donjonsActions, djLvl)
        {
        }

        public override void Start()
        {
            Index = 0;
            Send(InteractiveElementAction.GetPacket(21015, 12));
            base.Start();
        }

        public void Reset() {
            Index = 0;
            PostData(Items);
            Items.Clear();
            Send(MarketConsultRequest.GetPacket(-1, -1, -1, -1, Index, true));
        }

        public void PostData(List<MarketItemInfos> items)
        {
            string jsonData = JsonConvert.SerializeObject(items.Select(i => new
            {
                Price = i.PackPrice,
                PackType = i.PackType,
                Quantity = i.PackCount,
                RefItem = i.Item.RefId,
                Seller = i.SellerName
            }));
            var request = (HttpWebRequest)WebRequest.Create("https://wakfu-market-helper.herokuapp.com/api/bot");
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var stream = request.GetRequestStream())
            {
                stream.Write(Encoding.ASCII.GetBytes(jsonData), 0, jsonData.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        public override void AddConfig()
        {
            AddConstantAction(PacketType.MarketResult, (MarketConsultResult o) =>
            {
                if (o.Items.Count == 0)
                {
                    Reset();
                    return;
                }
                Items.AddRange(o.Items);
                Index += 10;
                Send(MarketConsultRequest.GetPacket(-1, -1, -1, -1, Index, true));
            });
        }
    }
}
