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
    public partial class FormSinglePlayerMenu : Form
    {
        //Default mode
        public Difficulty SelectedDifficulty { get; private set; } = Difficulty.Easy;

        public FormSinglePlayerMenu()
        {
            InitializeComponent();
        }

        private void Choose(Difficulty d)
        {
            SelectedDifficulty = d;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnEasy_Click(object s, EventArgs e) => Choose(Difficulty.Easy);
        private void btnMedium_Click(object s, EventArgs e) => Choose(Difficulty.Medium);
        private void btnHard_Click(object s, EventArgs e) => Choose(Difficulty.Hard);
        private void btnHardest_Click(object s, EventArgs e) => Choose(Difficulty.Hardest);
        private void btnPro_Click(object s, EventArgs e) => Choose(Difficulty.Pro);

        private void btnProgressive_Click(object s, EventArgs e)
        {
            MessageBox.Show("Progressive Mode - Coming Soon!\n\nThis exciting feature is currently under development.\nStay tuned for future updates!",
                "Progressive Mode",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnExit_Click(object s, EventArgs e) => Application.Exit();
    }
}