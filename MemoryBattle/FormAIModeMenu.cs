using System;
using System.Windows.Forms;
using MemoryBattle.Details;

namespace MemoryBattle
{
    public partial class FormAIModeMenu : Form
    {
        public Difficulty SelectedDifficulty { get; private set; } = Difficulty.Easy;

        public string PlayerName =>
            string.IsNullOrWhiteSpace(textBoxName.Text) ? "Player" : textBoxName.Text;

        public GameSettings SelectedSettings =>
            DifficultySlides.For(SelectedDifficulty);

        public FormAIModeMenu()
        {
            InitializeComponent();
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
                textBoxName.Text = "Player";
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Easy;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Medium;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Hard;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHardest_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Hardest;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Pro;
            DialogResult = DialogResult.OK;
            Close();
        }

        // not sure if superbattle will be included

        //private void btnSuperBattle_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.SuperBattle;
        //    DialogResult = DialogResult.OK;
        //    Close();
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
