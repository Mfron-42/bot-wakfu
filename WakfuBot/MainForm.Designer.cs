using System;

namespace WakfuBot
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeInfos = new System.Windows.Forms.TreeView();
            this.WinCountLabel = new System.Windows.Forms.Label();
            this.MobCount = new System.Windows.Forms.Label();
            this.TurnCount = new System.Windows.Forms.Label();
            this.FightInfos = new System.Windows.Forms.GroupBox();
            this.StopAtTime = new System.Windows.Forms.Label();
            this.StopAtPicker = new System.Windows.Forms.DateTimePicker();
            this.Map = new System.Windows.Forms.GroupBox();
            this.PosLabel = new System.Windows.Forms.Label();
            this.SelectedPlayers = new System.Windows.Forms.ListBox();
            this.PlayerList = new System.Windows.Forms.ListBox();
            this.LostFight = new System.Windows.Forms.Label();
            this.FightRateTime = new System.Windows.Forms.Label();
            this.FightTimer = new System.Windows.Forms.Label();
            this.authenticationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deconnexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.begginFightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupInvitationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.botActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FightInfos.SuspendLayout();
            this.Map.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeInfos
            // 
            this.TreeInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeInfos.Location = new System.Drawing.Point(9, 25);
            this.TreeInfos.Margin = new System.Windows.Forms.Padding(2);
            this.TreeInfos.Name = "TreeInfos";
            this.TreeInfos.Size = new System.Drawing.Size(421, 326);
            this.TreeInfos.TabIndex = 2;
            // 
            // WinCountLabel
            // 
            this.WinCountLabel.AutoSize = true;
            this.WinCountLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.WinCountLabel.Location = new System.Drawing.Point(2, 99);
            this.WinCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.WinCountLabel.Name = "WinCountLabel";
            this.WinCountLabel.Padding = new System.Windows.Forms.Padding(4);
            this.WinCountLabel.Size = new System.Drawing.Size(49, 21);
            this.WinCountLabel.TabIndex = 1;
            this.WinCountLabel.Text = "Win : 0";
            // 
            // MobCount
            // 
            this.MobCount.AutoSize = true;
            this.MobCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.MobCount.Location = new System.Drawing.Point(2, 57);
            this.MobCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MobCount.Name = "MobCount";
            this.MobCount.Padding = new System.Windows.Forms.Padding(4);
            this.MobCount.Size = new System.Drawing.Size(56, 21);
            this.MobCount.TabIndex = 2;
            this.MobCount.Text = "Mobs : 0";
            // 
            // TurnCount
            // 
            this.TurnCount.AutoSize = true;
            this.TurnCount.Dock = System.Windows.Forms.DockStyle.Top;
            this.TurnCount.Location = new System.Drawing.Point(2, 15);
            this.TurnCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TurnCount.Name = "TurnCount";
            this.TurnCount.Padding = new System.Windows.Forms.Padding(4);
            this.TurnCount.Size = new System.Drawing.Size(52, 21);
            this.TurnCount.TabIndex = 0;
            this.TurnCount.Text = "Turn : 0";
            // 
            // FightInfos
            // 
            this.FightInfos.Controls.Add(this.StopAtTime);
            this.FightInfos.Controls.Add(this.StopAtPicker);
            this.FightInfos.Controls.Add(this.Map);
            this.FightInfos.Controls.Add(this.SelectedPlayers);
            this.FightInfos.Controls.Add(this.PlayerList);
            this.FightInfos.Controls.Add(this.LostFight);
            this.FightInfos.Controls.Add(this.WinCountLabel);
            this.FightInfos.Controls.Add(this.FightRateTime);
            this.FightInfos.Controls.Add(this.MobCount);
            this.FightInfos.Controls.Add(this.FightTimer);
            this.FightInfos.Controls.Add(this.TurnCount);
            this.FightInfos.Dock = System.Windows.Forms.DockStyle.Right;
            this.FightInfos.Location = new System.Drawing.Point(431, 24);
            this.FightInfos.Margin = new System.Windows.Forms.Padding(2);
            this.FightInfos.Name = "FightInfos";
            this.FightInfos.Padding = new System.Windows.Forms.Padding(2);
            this.FightInfos.Size = new System.Drawing.Size(335, 329);
            this.FightInfos.TabIndex = 7;
            this.FightInfos.TabStop = false;
            this.FightInfos.Text = "Fight";
            // 
            // StopAtTime
            // 
            this.StopAtTime.AutoSize = true;
            this.StopAtTime.Location = new System.Drawing.Point(3, 193);
            this.StopAtTime.Name = "StopAtTime";
            this.StopAtTime.Size = new System.Drawing.Size(47, 13);
            this.StopAtTime.TabIndex = 13;
            this.StopAtTime.Text = "Stop at :";
            // 
            // StopAtPicker
            // 
            this.StopAtPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.StopAtPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StopAtPicker.Location = new System.Drawing.Point(3, 212);
            this.StopAtPicker.Name = "StopAtPicker";
            this.StopAtPicker.Size = new System.Drawing.Size(154, 20);
            this.StopAtPicker.TabIndex = 12;
            this.StopAtPicker.Value = DateTime.Now.AddHours(5);
            this.StopAtPicker.Leave += new System.EventHandler(this.StopAtPicker_ValueChanged);
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Map.Controls.Add(this.PosLabel);
            this.Map.Location = new System.Drawing.Point(176, 15);
            this.Map.Margin = new System.Windows.Forms.Padding(2);
            this.Map.Name = "Map";
            this.Map.Padding = new System.Windows.Forms.Padding(2);
            this.Map.Size = new System.Drawing.Size(150, 237);
            this.Map.TabIndex = 11;
            this.Map.TabStop = false;
            this.Map.Text = "Map";
            // 
            // PosLabel
            // 
            this.PosLabel.AutoSize = true;
            this.PosLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.PosLabel.Location = new System.Drawing.Point(2, 15);
            this.PosLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PosLabel.Name = "PosLabel";
            this.PosLabel.Padding = new System.Windows.Forms.Padding(4);
            this.PosLabel.Size = new System.Drawing.Size(42, 21);
            this.PosLabel.TabIndex = 12;
            this.PosLabel.Text = "Pos : ";
            // 
            // SelectedPlayers
            // 
            this.SelectedPlayers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedPlayers.Enabled = false;
            this.SelectedPlayers.FormattingEnabled = true;
            this.SelectedPlayers.Location = new System.Drawing.Point(161, 256);
            this.SelectedPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.SelectedPlayers.Name = "SelectedPlayers";
            this.SelectedPlayers.Size = new System.Drawing.Size(170, 69);
            this.SelectedPlayers.TabIndex = 10;
            // 
            // PlayerList
            // 
            this.PlayerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerList.FormattingEnabled = true;
            this.PlayerList.Location = new System.Drawing.Point(3, 256);
            this.PlayerList.Margin = new System.Windows.Forms.Padding(2);
            this.PlayerList.Name = "PlayerList";
            this.PlayerList.Size = new System.Drawing.Size(154, 69);
            this.PlayerList.TabIndex = 9;
            this.PlayerList.SelectedIndexChanged += new System.EventHandler(this.PlayerList_SelectedIndexChanged);
            // 
            // LostFight
            // 
            this.LostFight.AutoSize = true;
            this.LostFight.Dock = System.Windows.Forms.DockStyle.Left;
            this.LostFight.Location = new System.Drawing.Point(2, 120);
            this.LostFight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LostFight.Name = "LostFight";
            this.LostFight.Padding = new System.Windows.Forms.Padding(4);
            this.LostFight.Size = new System.Drawing.Size(50, 21);
            this.LostFight.TabIndex = 5;
            this.LostFight.Text = "Lost : 0";
            // 
            // FightRateTime
            // 
            this.FightRateTime.AutoSize = true;
            this.FightRateTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.FightRateTime.Location = new System.Drawing.Point(2, 78);
            this.FightRateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FightRateTime.Name = "FightRateTime";
            this.FightRateTime.Padding = new System.Windows.Forms.Padding(4);
            this.FightRateTime.Size = new System.Drawing.Size(85, 21);
            this.FightRateTime.TabIndex = 5;
            this.FightRateTime.Text = "Fight rate : 0/h";
            // 
            // FightTimer
            // 
            this.FightTimer.AutoSize = true;
            this.FightTimer.Dock = System.Windows.Forms.DockStyle.Top;
            this.FightTimer.Location = new System.Drawing.Point(2, 36);
            this.FightTimer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FightTimer.Name = "FightTimer";
            this.FightTimer.Padding = new System.Windows.Forms.Padding(4);
            this.FightTimer.Size = new System.Drawing.Size(70, 21);
            this.FightTimer.TabIndex = 3;
            this.FightTimer.Text = "Duration : 0";
            // 
            // authenticationToolStripMenuItem
            // 
            this.authenticationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connexionToolStripMenuItem,
            this.deconnexionToolStripMenuItem});
            this.authenticationToolStripMenuItem.Name = "authenticationToolStripMenuItem";
            this.authenticationToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.authenticationToolStripMenuItem.Text = "Authentication";
            // 
            // connexionToolStripMenuItem
            // 
            this.connexionToolStripMenuItem.Name = "connexionToolStripMenuItem";
            this.connexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.connexionToolStripMenuItem.Text = "Connexion";
            this.connexionToolStripMenuItem.Click += new System.EventHandler(this.ConnexionToolStripMenuItem_Click);
            // 
            // deconnexionToolStripMenuItem
            // 
            this.deconnexionToolStripMenuItem.Name = "deconnexionToolStripMenuItem";
            this.deconnexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deconnexionToolStripMenuItem.Text = "Deconnexion";
            // 
            // fightToolStripMenuItem
            // 
            this.fightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.begginFightToolStripMenuItem});
            this.fightToolStripMenuItem.Name = "fightToolStripMenuItem";
            this.fightToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.fightToolStripMenuItem.Text = "Fight";
            // 
            // begginFightToolStripMenuItem
            // 
            this.begginFightToolStripMenuItem.Name = "begginFightToolStripMenuItem";
            this.begginFightToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.begginFightToolStripMenuItem.Text = "Beggin fight";
            this.begginFightToolStripMenuItem.Click += new System.EventHandler(this.BegginFightToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupInvitationToolStripMenuItem,
            this.freezeToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // groupInvitationToolStripMenuItem
            // 
            this.groupInvitationToolStripMenuItem.Name = "groupInvitationToolStripMenuItem";
            this.groupInvitationToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.groupInvitationToolStripMenuItem.Text = "Group invitation";
            this.groupInvitationToolStripMenuItem.Click += new System.EventHandler(this.GroupInvitationToolStripMenuItem_Click);
            // 
            // freezeToolStripMenuItem
            // 
            this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
            this.freezeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.freezeToolStripMenuItem.Text = "Freeze";
            this.freezeToolStripMenuItem.Click += new System.EventHandler(this.FreezeToolStripMenuItem_Click);
            // 
            // botActionsToolStripMenuItem
            // 
            this.botActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.loadConfigToolStripMenuItem});
            this.botActionsToolStripMenuItem.Name = "botActionsToolStripMenuItem";
            this.botActionsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.botActionsToolStripMenuItem.Text = "Bot Actions";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click_1);
            // 
            // loadConfigToolStripMenuItem
            // 
            this.loadConfigToolStripMenuItem.Name = "loadConfigToolStripMenuItem";
            this.loadConfigToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.loadConfigToolStripMenuItem.Text = "Load config";
            this.loadConfigToolStripMenuItem.Click += new System.EventHandler(this.LoadConfigToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.authenticationToolStripMenuItem,
            this.fightToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.botActionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(766, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 353);
            this.Controls.Add(this.FightInfos);
            this.Controls.Add(this.TreeInfos);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Wakfu Bot";
            this.FightInfos.ResumeLayout(false);
            this.FightInfos.PerformLayout();
            this.Map.ResumeLayout(false);
            this.Map.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView TreeInfos;
        public System.Windows.Forms.Label WinCountLabel;
        public System.Windows.Forms.Label MobCount;
        public System.Windows.Forms.Label TurnCount;
        private System.Windows.Forms.GroupBox FightInfos;
        public System.Windows.Forms.Label FightRateTime;
        public System.Windows.Forms.Label FightTimer;
        private System.Windows.Forms.ListBox PlayerList;
        public System.Windows.Forms.Label LostFight;
        private System.Windows.Forms.ListBox SelectedPlayers;
        private System.Windows.Forms.GroupBox Map;
        public System.Windows.Forms.Label PosLabel;
        private System.Windows.Forms.ToolStripMenuItem authenticationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deconnexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem begginFightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupInvitationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem botActionsToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadConfigToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label StopAtTime;
        private System.Windows.Forms.DateTimePicker StopAtPicker;
    }
}

