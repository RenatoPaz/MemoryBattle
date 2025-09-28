using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryBattle
{
    public partial class FormGame : Form
    {
        private FormSinglePlayerMenu.Difficulty difficulty;

        public FormGame(FormSinglePlayerMenu.Difficulty selectedDifficulty)
        {
            InitializeComponent(); // <-- defined in the Designer partial
            difficulty = selectedDifficulty;

            // For now, just show which mode was selected
            this.Text = "Memory Battle - " + difficulty.ToString();
            MessageBox.Show("Starting game in " + difficulty.ToString() + " mode!");
        }
    }
}
