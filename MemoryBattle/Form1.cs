using System;
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

        //test comment

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starting Single Player...");
        }

        private void btnBattleMode_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Starting Battle Mode...");
        }

        private void btnScoreInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Scores will be displayed here.");
        }

        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Match pairs of cards before the timer runs out!");
        }
    }
}