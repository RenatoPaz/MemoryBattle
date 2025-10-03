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

                var settings = DifficultySlides.For(menu.SelectedDifficulty); //Difficulty will be coming from GameSettings

                using (var game = new FormGame(settings))  //pass GameSettings
                {
                    Hide(); 
                    game.ShowDialog(this); 
                    Show();                 
                }
            }
        }

        private void btnScoreInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scores will be displayed here.");
        }

        private void btnBattleMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Battle mode will be displayed here.");
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Match pairs of cards before the timer runs out!");
            string instructions = "Match pairs of cards.\n\n" +
                      "Players take turns; a correct match earns another try.\n\n" +
                      "Each new level adds more pairs and harder symbols.\n\n" +
                      "The player with the most pairs wins.";

            MessageBox.Show(instructions, "How to Play", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}