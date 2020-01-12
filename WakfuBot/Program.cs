using PacketEditor.WakfuBot.Packets;
using PacketEditor.WakfuBot.Packets.ToReceiv.Fight.RunningEffects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WakfuBot.Utility;

namespace WakfuBot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PowerHelper.ForceSystemAwake();
            Application.Run(new MainForm());
            Application.Exit();
            Process.GetCurrentProcess().Kill();
        }
    }
}
