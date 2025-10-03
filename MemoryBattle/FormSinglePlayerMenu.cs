using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Added the logic code from Difficulty
using MemoryBattle.Details;

namespace MemoryBattle
{
    public partial class FormSinglePlayerMenu : Form
    {

        //public enum Difficulty { Easy, Medium, Hard, Hardest, Pro, Progressive }

        //Default mode
        public Difficulty SelectedDifficulty { get; private set; } = Difficulty.Easy; 

        public FormSinglePlayerMenu()
        {
            InitializeComponent();
        }
        private void Choose (Difficulty d)
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
        private void btnProgressive_Click(object s, EventArgs e) => Choose(Difficulty.Progressive);

        private void btnExit_Click(object s, EventArgs e) => Application.Exit();

        //private void btnEasy_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.Easy;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnMedium_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.Medium;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnHard_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.Hard;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnHardest_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.Hardest;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnPro_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.Pro;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnProgressive_Click(object sender, EventArgs e)
        //{
        //    SelectedDifficulty = Difficulty.Progressive;
        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}

        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}
    }
}
