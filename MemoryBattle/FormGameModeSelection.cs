using MemoryBattle.Details;
using MemoryBattle.Properties;
using System;
using System.Drawing;
using System.Runtime;
using System.Windows.Forms;

namespace MemoryBattle
{
    public partial class FormGameModeSelection : Form
    {
        public FormGameModeSelection()
        {
            InitializeComponent();
            ApplyColorScheme();
            ColorSchemeManager.ColorSchemeChanged += OnColorSchemeChanged;
        }

        private void OnColorSchemeChanged(object sender, EventArgs e)
        {
            ApplyColorScheme();
        }

        private void ApplyColorScheme()
        {
            // Apply color scheme to all buttons and labels
            foreach (Control control in this.Controls)
            {
                if (control is Button button)
                {
                    button.BackColor = ColorSchemeManager.ButtonBackground;
                    button.ForeColor = ColorSchemeManager.ButtonForeground;
                }
                else if (control is Label label)
                {
                    label.ForeColor = ColorSchemeManager.LabelForeground;
                }
            }

            // Handle background
            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                this.BackgroundImage = null;
                this.BackColor = ColorSchemeManager.FormBackground;
            }
            else
            {

            }

            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ColorSchemeManager.ColorSchemeChanged -= OnColorSchemeChanged;
            base.OnFormClosed(e);
        }

        //Added background on the component itself
        //private void SetupForm()
        //{
        //    this.Text = "Memory Battle - Game Mode";
        //    this.Size = new Size(458, 503);
        //    this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    this.MaximizeBox = false;
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.BackgroundImage = Properties.Resources.WinterBattleDaytime;
        //    this.BackgroundImageLayout = ImageLayout.Stretch;
        //}

        private void btnPlayerVsPlayer_Click(object sender, EventArgs e)
        {
            using (var menu = new FormBattleModeMenu())
            {
                if (menu.ShowDialog(this) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void btnPlayerVsAI_Click(object sender, EventArgs e)
        {
            using (var menu = new FormAIModeMenu())
            {
                if (menu.ShowDialog(this) != DialogResult.OK) return;

                var settings = menu.SelectedSettings;
                var playerName = menu.PlayerName;

                using (var game = new FormAIGame(settings, playerName))
                {
                    game.Text = $"Memory Battle - {playerName} vs AI ({menu.SelectedDifficulty})";
                    game.ShowDialog(this);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}