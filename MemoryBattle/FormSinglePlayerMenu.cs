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
    public partial class FormSinglePlayerMenu : Form
    {
        public enum Difficulty { Easy, Medium, Hard, Hardest, Pro, Progressive }

        public Difficulty SelectedDifficulty { get; private set; }

        public FormSinglePlayerMenu()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Easy;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Medium;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Hard;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHardest_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Hardest;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPro_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Pro;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnProgressive_Click(object sender, EventArgs e)
        {
            SelectedDifficulty = Difficulty.Progressive;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
