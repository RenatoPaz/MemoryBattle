using MemoryBattle.Details;
using MemoryBattle.Properties;
using System;
using System.Runtime;
using System.Windows.Forms;

namespace MemoryBattle
{
    public partial class FormGameModeSelection : Form
    {
        public FormGameModeSelection()
        {
            InitializeComponent();
        }

        //Added background on the component itself
        //private void SetupForm()
        //{
        //    this.Text = "Memory Battle - Game Mode";
        //    this.Size = new Size(458, 503);
        //    this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    this.MaximizeBox = false;
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.BackgroundImage = Properties.Resources.WinterBattleDaytime;
        //    this.BackgroundImageLayout = ImageLayout.Stretch;
        //}

        private void btnPlayerVsPlayer_Click(object sender, EventArgs e)
        {
            using (var menu = new FormBattleModeMenu())
            {
                if (menu.ShowDialog(this) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnPlayerVsAI_Click(object sender, EventArgs e)
        {
            using (var menu = new FormAIModeMenu())
            {
                if (menu.ShowDialog(this) != DialogResult.OK) return;

                var settings = menu.SelectedSettings; 
                var playerName = menu.PlayerName;        

                using (var game = new FormAIGame(settings, playerName))
                {
                    game.Text = $"Memory Battle - {playerName} vs AI ({menu.SelectedDifficulty})";
                    game.ShowDialog(this);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}