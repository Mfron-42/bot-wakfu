using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Text;
using WakfuBot.Authentication.Packets;

namespace WakfuBot.Authentication.PacketReceiv
{
    public class AuthResult : AAuthBaseInMessage
    {
        public override AuthMessageType MessageType { get; set; } = AuthMessageType.AUTH_RESULT;

        public byte ResultCode;
        public bool HasInformation;
        public int Community;
        public bool IsAdmin;
        public long AccountId;
        public string Name;
        public Dictionary<int, int> Rights = new Dictionary<int, int>();
        public byte[] AccountStatus;

        public AuthResult(ByteReader rd)
        {
            rd.Read(out ResultCode);
            rd.Read(out HasInformation);
            if (!HasInformation)
                return;
            rd.Read(out Community);
            rd.Read(out IsAdmin);
            if (IsAdmin)
            {
                int size = rd.ReadInt();
                rd.Read(out AccountId);
                int nameSize = rd.ReadInt();
                Name = Encoding.UTF8.GetString(rd.Read(nameSize));
                int rightsSize = rd.ReadInt();
                for (int i = 0; i < rightsSize; i++)
                    Rights[rd.ReadInt()] = rd.ReadInt();
            }
            AccountStatus = rd.ReadAll();
        }
    }
}
