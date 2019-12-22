using System;
using WakfuBot.Authentication;
using System.Windows.Forms;
using System.Threading;
using PacketEditor.WakfuBot;
using PacketEditor.WakfuBot.Packets.ToReceiv;
using PacketEditor.WakfuBot.Bot;
using WakfuBot.WakfuBot.Packets.ToSend;
using WakfuBot.WakfuBot.Bot.Actions.ActionsConfig;
using System.Threading.Tasks;

namespace WakfuBot
{
    public partial class MainForm : Form
    {
        private AuthenticationAccount account;
        public static TreeView Tree;
        public static MainForm Instance;
        public static WakfuDatas Manager;
        public static string MainHero = null;
        private static ABotActionConfig BotConfig;
        private static DateTime StopAt = DateTime.MaxValue;

        public MainForm()
        {
            Instance = this;
            InitializeComponent();
            Tree = this.TreeInfos;
        }

        public static void Invoke(Action action)
            => Instance.BeginInvoke(action);

        public void UpdateInfos(WakfuDatas manager, Map map, BotActions botActions)
        {
            TimeSpan fightDuration = DateTime.UtcNow - map.StartFightTime;
            MobCount.Text = "Mobs\t:\t" + map.GetMobsAndSumms().Length;
            WinCountLabel.Text = "Win\t:\t" + map.WinCount;
            LostFight.Text = "Lost\t:\t" + map.LostCount;
            TurnCount.Text = "Turn\t:\t" + map.TableTurnCount;
            FightTimer.Text = "Duration\t:\t" + (map.IsFighting() ? (int)fightDuration.TotalMinutes + " : " + (int)fightDuration.Seconds : "- - - - -");
            FightRateTime.Text = "Fight rate\t:\t" + ((int)(map.WinCount / (DateTime.UtcNow - map.InitMapDate).TotalHours)) + "/h";
            if (MainHero != null)
            {
                PosLabel.Text = MainHero + " : " + botActions.MainPlayer().GetPosition()?.ToString();
            }
        }

        public static void LoadBotConfig(ABotActionConfig botConfig)
        {
            if (BotConfig != null)
                UnloadBotConfig();
            BotConfig = botConfig;
            BotConfig.Load();
            Instance.startToolStripMenuItem.Text = "Start";
            Instance.startToolStripMenuItem.Enabled = true;
        }

        private static void UnloadBotConfig()
        {
            BotConfig.Unload();
            Instance.startToolStripMenuItem.Enabled = false;
        }

        public void AddPlayers(string[] names)
        {
            PlayerList.Items.AddRange(names);
        }

        private void ConnexionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var accountForm = new AccountForm();
            accountForm.ShowDialog();
            if (accountForm.DialogResult != DialogResult.OK)
                return;
            string accountName = accountForm.AccountText.Text;
            string password = accountForm.PasswordText.Text;
            accountForm.Dispose();
            new Thread(() => {
                account = new AuthenticationAccount(accountName, password);
                Manager = account.Manager;
            }).Start();
        }

        private void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PlayerList.SelectedItem == null)
                return;
            if (SelectedPlayers.Items.Count > 2)
            {
                MessageBox.Show("Cannot add more than 2 heros");
                return;
            }
            if (MainHero == null) {
                if (!Manager.SelectPlayer((string)PlayerList.SelectedItem))
                    MessageBox.Show("Cannot find this player on configured player list");
                else
                {
                    MainHero = (string)PlayerList.SelectedItem;
                    SelectedPlayers.Items.Add(MainHero);
                    SelectedPlayers.SetSelected(0, true);
                }
                return;
            }
            if (Manager.AddHero((string)PlayerList.SelectedItem))
                SelectedPlayers.Items.Add(PlayerList.SelectedItem);
            else
                MessageBox.Show("Cannot find this player on configured player list");
        }

        private void BegginFightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainHero == null)
                return;
            Manager.BegginNearestFight();
        }

        private void GroupInvitationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var playerName = new PlayerName();
            playerName.ShowDialog();
            var name = playerName.PlayerNameText.Text;
            playerName.Dispose();
            if (MainHero != null){
                Manager.Send(InvitGroup.GetPacket(name));
            }
        }

        private void FreezeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Manager == null)
                return;
            freezeToolStripMenuItem.Checked = !freezeToolStripMenuItem.Checked;
            Manager.SetSleep(freezeToolStripMenuItem.Checked);
        }

        private void StartToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (startToolStripMenuItem.Text == "Start")
            {
                BotConfig.Start();
                startToolStripMenuItem.Text = "Stop";
            }
            else
            {
                BotConfig.Stop();
                startToolStripMenuItem.Text = "Start";
            }
        }

        private void LoadConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var actionsForm = new BotActionsForm();
            actionsForm.ShowDialog();
            if (actionsForm.DialogResult != DialogResult.OK)
                return;
            ABotActionConfig botConfig = Manager?.CreateActionsConfig(actionsForm.BotActionsName, actionsForm.SelectedStasisLevel);
            actionsForm.Dispose();
            if (botConfig == null)
                return;
            LoadBotConfig(botConfig);
            StartToolStripMenuItem_Click_1(null, null);
        }

        private void StopAtPicker_ValueChanged(object sender, EventArgs e)
        {
            StopAt = StopAtPicker.Value;
            if (MessageBox.Show(StopAt.ToString(), "The bot will stop at the selected date", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Task.Delay(StopAt - DateTime.Now).ContinueWith(t =>
                {
                    if ((StopAt - DateTime.Now).TotalSeconds < 1)
                        StartToolStripMenuItem_Click_1(null, null);
                });
            }
            else
                StopAt = DateTime.MaxValue;
        }
    }
}
