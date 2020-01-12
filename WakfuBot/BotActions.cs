using PacketEditor.WakfuBot.Bot;
using System;
using System.Windows.Forms;

namespace WakfuBot
{
    public partial class BotActionsForm : Form
    {
        public string BotActionsName;
        public int SelectedStasisLevel;

        public BotActionsForm()
        {
            InitializeComponent();
            BotActionsNamesComboBox.Items.AddRange(BotActions.GetConfigNameArray());
            BotActionsNamesComboBox.SelectedIndex = 0;
            StasisLevelDropDown.Maximum = 20;
            StasisLevelDropDown.Minimum = 1;
        }

        private void ValidateBotActionsConfig(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ActionsNameDropDown_SelectedItemChanged(object sender, EventArgs e)
        {
            BotActionsName = (string)BotActionsNamesComboBox.SelectedItem;
        }

        private void StasisLevelDropDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedStasisLevel = (int)StasisLevelDropDown.Value;
        }
    }
}
