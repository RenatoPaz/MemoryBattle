using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MemoryBattle.Details;

namespace MemoryBattle
{
    public partial class FormBattleModeMenu : Form
    {
        public FormBattleModeMenu()
        { 
            InitializeComponent();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            // Medium button handler
            StartBattleGame(Difficulty.Medium);
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            // Easy button handler
            StartBattleGame(Difficulty.Easy);
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            // Hard button handler
            StartBattleGame(Difficulty.Hard);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSuperBattle_Click(object sender, EventArgs e)
        {
            // Super Battle button handler
            StartBattleGame(Difficulty.SuperBattle);
        }

        private void StartBattleGame(Difficulty difficulty)
        {
            // Get player names from text boxes, use defaults if empty
            string player1 = string.IsNullOrWhiteSpace(textBox1.Text) ? "Player 1" : textBox1.Text;
            string player2 = string.IsNullOrWhiteSpace(textBox2.Text) ? "Player 2" : textBox2.Text;

            // Create and show the battle game
            using (var battleForm = new FormGameBattle(player1, player2, difficulty))
            {
                battleForm.ShowDialog(this);
            }
        }
    }
}