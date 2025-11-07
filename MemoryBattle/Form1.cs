using System;
using MemoryBattle.Details;
using System.Windows.Forms;

namespace MemoryBattle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            using (var menu = new FormSinglePlayerMenu())
            {
                if (menu.ShowDialog(this) != DialogResult.OK) return;

                var settings = DifficultySlides.For(menu.SelectedDifficulty);

                using (var game = new FormGame(settings))
                {
                    Hide();
                    game.ShowDialog(this);
                    Show();
                }
            }
        }

        private void btnScoreInfo_Click(object sender, EventArgs e)
        {
            using (var leaderboard = new FormLeaderboard())
            {
                leaderboard.ShowDialog(this);
            }
        }

        private void btnBattleMode_Click(object sender, EventArgs e)
        {
            //using (var battleMenu = new FormBattleModeMenu())
            //{
            //    Hide();
            //    battleMenu.ShowDialog(this);
            //    Show();
            //}

            //use form gamemode selection for player to choose between PvP or PvC
            using (var modeSelection = new FormGameModeSelection())
            {
                if (modeSelection.ShowDialog(this) != DialogResult.OK) return;
            }
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            using (var howToPlay = new FormHowToPlay())
            {
                howToPlay.ShowDialog(this);
            }
        }
    }
}