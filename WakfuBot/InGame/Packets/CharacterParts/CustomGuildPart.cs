using PacketEditor.WakfuBot.Packets;
using WakfuBot.WakfuBot.Packets.ToSend;
using WakfuBot.WakfuBot.Structures.Character;

namespace WakfuBot.WakfuBot.Structures
{
    //https://github.com/hussein-aitlahcen/wakfu-src/blob/0b9f7717bd2ead22785b71b6837eb84dac84a0fc/com/ankamagames/wakfu/common/datas/CharacterSerializedAppearance.java
    public class CustomGuildPart : CharacterSerializedPart
    {
        public override CHARACTER_PART CharacterPart { get; set; } = CHARACTER_PART.CUSTOM_GUILD;

        public long BlazonUid;
        public long GuildUid;

        public override void FromData(ByteReader rd)
        {
            rd.Read(out BlazonUid);
            rd.Read(out GuildUid);
        }

        public static CustomGuildPart Deserialize(ByteReader rd)
        {
            var ret = new CustomGuildPart();
            ret.FromData(rd);
            return ret;
        }
    }
}
