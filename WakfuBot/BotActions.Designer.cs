namespace WakfuBot
{
    partial class BotActionsForm
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
            this.LoadConfigButton = new System.Windows.Forms.Button();
            this.StasisLevelDropDown = new System.Windows.Forms.NumericUpDown();
            this.BotActionsNamesComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.StasisLevelDropDown)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadConfigButton
            // 
            this.LoadConfigButton.Location = new System.Drawing.Point(47, 94);
            this.LoadConfigButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadConfigButton.Name = "LoadConfigButton";
            this.LoadConfigButton.Size = new System.Drawing.Size(89, 19);
            this.LoadConfigButton.TabIndex = 4;
            this.LoadConfigButton.Text = "Load";
            this.LoadConfigButton.UseVisualStyleBackColor = true;
            this.LoadConfigButton.Click += new System.EventHandler(this.ValidateBotActionsConfig);
            // 
            // StasisLevelDropDown
            // 
            this.StasisLevelDropDown.Location = new System.Drawing.Point(32, 50);
            this.StasisLevelDropDown.Name = "StasisLevelDropDown";
            this.StasisLevelDropDown.Size = new System.Drawing.Size(120, 20);
            this.StasisLevelDropDown.TabIndex = 6;
            this.StasisLevelDropDown.ValueChanged += new System.EventHandler(this.StasisLevelDropDown_ValueChanged);
            // 
            // BotActionsNamesComboBox
            // 
            this.BotActionsNamesComboBox.FormattingEnabled = true;
            this.BotActionsNamesComboBox.Location = new System.Drawing.Point(31, 23);
            this.BotActionsNamesComboBox.Name = "BotActionsNamesComboBox";
            this.BotActionsNamesComboBox.Size = new System.Drawing.Size(121, 21);
            this.BotActionsNamesComboBox.TabIndex = 7;
            this.BotActionsNamesComboBox.SelectedIndexChanged += new System.EventHandler(this.ActionsNameDropDown_SelectedItemChanged);
            // 
            // BotActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 124);
            this.Controls.Add(this.BotActionsNamesComboBox);
            this.Controls.Add(this.StasisLevelDropDown);
            this.Controls.Add(this.LoadConfigButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BotActionsForm";
            this.Text = "Account";
            ((System.ComponentModel.ISupportInitialize)(this.StasisLevelDropDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button LoadConfigButton;
        protected System.Windows.Forms.NumericUpDown StasisLevelDropDown;
        protected System.Windows.Forms.ComboBox BotActionsNamesComboBox;
    }
}