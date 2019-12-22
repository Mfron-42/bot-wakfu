using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WakfuBot.InGame.Packets.ToReceiv.Market
{
    public class MarketConsultResult
    {
        public static PacketType packetType = PacketType.MarketResult;

        public MARKET_TYPE Type;
        public int Size;
        public int ItemCount;

        public List<MarketItemInfos> Items = new List<MarketItemInfos>();

        public MarketConsultResult(ByteReader rd)
        {
            Type = (MARKET_TYPE)rd.ReadByte();
            rd.Read(out Size);
            rd.Read(out ItemCount);

            if (Type == MARKET_TYPE.MARKET_HISTORY_ENTRY)
                throw new Exception();
            for(int i = 0; i < ItemCount; i++)
            {
                Items.Add(new MarketItemInfos(rd));
            }
        }
    }

    public enum MARKET_TYPE : byte
    {
        MARKET_ENTRY,
        MARKET_HISTORY_ENTRY
    }

    public class MarketItemInfos
    {
        public long Uid;
        public long SellerId;
        public string SellerName;
        public byte PackType;
        public short PackCount;
        public int PackPrice;
        public byte Duration;
        public long ReleaseDate;
        public InventoryItem Item;

        public MarketItemInfos(ByteReader rd)
        {
            rd.Read(out Uid);
            rd.Read(out SellerId);
            rd.Read(out SellerName);
            rd.Read(out PackType);
            rd.Read(out PackCount);
            rd.Read(out PackPrice);
            rd.Read(out Duration);
            rd.Read(out ReleaseDate);
            Item = new InventoryItem(rd);
        }
    }

    public class InventoryItem
    {
        public long Uid;
        public int RefId;
        public short Quantity;

        public bool HasTimeStamp;
        public long TimeStamp;

        public bool HasPet;
        public RawPet Pet;

        public bool IsItemXp;
        public ItemXp ItemXp;

        public bool HasGems;
        public GemsItem GemsItem;

        public bool HasRentInfos;
        public RenInfos RenInfos;


        public bool HasCompanionInfos;
        public CompanionInfos CompanionInfos;


        public bool HasBind;
        public BindInfos BindInfos;

        public bool HasElements;
        public ElementsInfos ElementsInfos;

        public bool HasMergedItems;
        public MergedItems MergedItems;

        public bool Mimibioted;
        public int MimibiotSkin;

        public InventoryItem(ByteReader rd)
        {
            rd.Read(out Uid);
            rd.Read(out RefId);
            rd.Read(out Quantity);

            rd.Read(out HasPet);
            if (HasPet)
            {
                Pet = new RawPet(rd); //VERIFIED
            }
            
            rd.Read(out IsItemXp);
            if (IsItemXp)
            {
                ItemXp = new ItemXp(rd); // VERIFIED
            }

            rd.Read(out HasGems);
            if (HasGems)
            {
                GemsItem = new GemsItem(rd); // VERIFIED

            }

            rd.Read(out HasTimeStamp);
            if (HasTimeStamp)
            {
                rd.Read(out TimeStamp); //ALMOST VERIFIED
            }


            rd.Read(out HasCompanionInfos);
            if (HasCompanionInfos)
            {
                 CompanionInfos = new CompanionInfos(rd); //VERIFIED
            }


            rd.Read(out HasRentInfos);
            if (HasRentInfos)
            {
                var unknow = rd.ReadShort(); // ALMOST VERIFIED

            }
            rd.Read(out HasElements);
            if (HasElements)
            {
                ElementsInfos = new ElementsInfos(rd); // VERIFIED

            }
            rd.Read(out HasMergedItems);
            if (HasMergedItems)
            {
                MergedItems = new MergedItems(rd); // VERIFIED
            }

            rd.Read(out Mimibioted);
            if (Mimibioted)
            {
                MimibiotSkin = rd.ReadInt(); //VERIFIED

            }

            //uk
            //uk
            //BIND
            //uk
            //uk
            //uk
            //uk
            //ELEM
            //MERGED

        }
    }

    public class MergedItems
    {
        public int Version;
        public short Size;
        public byte[] Data;

        public MergedItems(ByteReader rd)
        {
            rd.Read(out Version);
            rd.Read(out Size);
            Data = rd.Read(Size);
        }
    }

    public class ElementsInfos
    {
        public byte DmgElements;
        public byte ResistanceElements;

        public ElementsInfos(ByteReader rd)
        {
            rd.Read(out DmgElements);
            rd.Read(out ResistanceElements);
        }
    }

    public class BindInfos
    {
        public byte Type;
        public long Data;

        public BindInfos(ByteReader rd)
        {
            rd.Read(out Type);
            rd.Read(out Data);
        }
    }

    public class CompanionInfos
    {
        public long Xp;

        public CompanionInfos(ByteReader rd)
        {
            rd.Read(out Xp);
        }
    }

    public class RenInfos
    {
        public int Type;
        public long Duration;
        public long Count; 

        public RenInfos(ByteReader rd)
        {
            rd.Read(out Type);
            rd.Read(out Duration);
            rd.Read(out Count);
        }
    }

    public class GemsItem
    {
        public short Size;
        public List<Gem> Gems = new List<Gem>();

        public GemsItem(ByteReader rd)
        {

            rd.Read(out Size);
            for (int i = 0; i < Size; i++)
                Gems.Add(new Gem(rd));
            var probablyHas3Runes = rd.ReadShort();
            if (probablyHas3Runes != 0)
            {
                byte unk = rd.ReadByte();
                int probablyRuneId = rd.ReadInt();
            }
        }
    }

    public class Gem
    {
        public byte Position;
        public int ReferenceId;

        public Gem(ByteReader rd)
        {
            rd.Read(out Position);
            rd.Read(out ReferenceId);
        }
    }

    public class ItemXp
    {
        public int DefinitionId;
        public long Xp;

        public ItemXp(ByteReader rd)
        {
            rd.Read(out DefinitionId);
            rd.Read(out Xp);
        }
    }

    public class RawPet
    {
        public int definitionId;
        public string name;
        public int colorItemRefId;
        public int equippedRefItemId;
        public int health;
        public int xp;
        public long lastMealDate;
        public long lastHungryDate;
        public int sleepRefItemId;
        public long sleepDate;

        public RawPet(ByteReader rd)
        {
            rd.Read(out definitionId);
            rd.Read(out name);
            rd.Read(out colorItemRefId);
            rd.Read(out equippedRefItemId);
            rd.Read(out health);
            rd.Read(out xp);
            rd.Read(out lastMealDate);
            rd.Read(out lastHungryDate);
            rd.Read(out sleepRefItemId);
            rd.Read(out sleepDate);
        }
    }
}
