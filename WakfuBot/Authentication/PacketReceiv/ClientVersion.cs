using PacketEditor.WakfuBot.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WakfuBot.Authentication.Packets;
using WakfuBot.Properties;

namespace WakfuBot.Authentication.PacketReceiv
{

    public class ClientVersion : AAuthBaseInMessage
    {
        public override AuthMessageType MessageType { get; set; } = AuthMessageType.CLIENT_VERSION;

        public bool Match;
        public byte Version;
        public short Revision;
        public byte Change;
        public byte[] Build;

        public ClientVersion(ByteReader rd)
        {
            rd.Read(out Match);
            rd.Read(out Version);
            rd.Read(out Revision);
            rd.Read(out Change);
            byte size = rd.ReadByte();
            Build = rd.Read(size);
            if (!Match)
                UpdateClientVersion();
        }

        private void UpdateClientVersion()
        {
            Settings.Default.Version = Version;
            Settings.Default.Revision = Revision;
            Settings.Default.Change = Change;
            Settings.Default.Build = new ByteReader(Build).ReadShort();
            Settings.Default.Save();
            DialogResult result = MessageBox.Show("Error version restart the bot", "Error", MessageBoxButtons.OK);
            Application.Restart();
        }
    }
}
