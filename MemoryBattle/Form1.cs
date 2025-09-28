using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//TestpushGitHub
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
            FormSinglePlayerMenu menu = new FormSinglePlayerMenu();

            if (menu.ShowDialog() == DialogResult.OK)
            {
                // Start the game with chosen difficulty
                FormGame game = new FormGame(menu.SelectedDifficulty);
                game.Show();
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