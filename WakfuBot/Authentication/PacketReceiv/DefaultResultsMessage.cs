using PacketEditor.WakfuBot.Packets;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketReceiv
{
    public class DefaultResultsMessage : AAuthBaseInMessage
    {
        public override AuthMessageType MessageType { get; set; } = AuthMessageType.DEFAULT_RESULT_MESSAGE;

        public int QueryResultCode;

        public DefaultResultsMessage(ByteReader rd)
        {
//            rd.Read(out QueryResultCode);
        }

    }
}