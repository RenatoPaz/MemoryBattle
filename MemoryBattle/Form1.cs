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
            //using (var menu = new FormSinglePlayerMenu())
            //{
            //    if (menu.ShowDialog(this) != DialogResult.OK) return;

            //    var settings = DifficultySlides.For(menu.SelectedDifficulty); //Difficulty will be coming from GameSettings

            //    using (var game = new FormGame(settings))  //pass GameSettings
            //    {
            //        Hide(); 
            //        game.ShowDialog(this); 
            //        Show();                 
            //    }
            //}

            //using (var menu = new FormSinglePlayerMenu())
            //{
            //    if (menu.ShowDialog(this) != DialogResult.OK) return;

            //    var settings = DifficultySlides.For(menu.SelectedDifficulty); // Difficulty will be coming from GameSettings

            //    FormGame game;

            //    // ✅ If player selected Progressive mode, mark it explicitly
            //    if (menu.SelectedDifficulty == Difficulty.Progressive)
            //    {
            //        game = new FormGame(settings)
            //        {
            //            Tag = "Progressive"
            //        };
            //    }
            //    else
            //    {
            //        game = new FormGame(settings);
            //    }

            //    Hide();
            //    game.ShowDialog(this);
            //    Show();
            //}


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
            using (var howToPlay = new FormHowToPlay())
            {
                howToPlay.ShowDialog(this);
            }
        }
    }
}