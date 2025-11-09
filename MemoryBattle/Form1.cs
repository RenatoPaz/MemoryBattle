using System;
using MemoryBattle.Details;
using System.Windows.Forms;
using System.Drawing;

namespace MemoryBattle
{
    public partial class Form1 : Form
    {
        private CheckBox chkColorBlindMode;

        public Form1()
        {
            InitializeComponent();
            InitializeColorBlindToggle();
            ApplyColorScheme();
            ColorSchemeManager.ColorSchemeChanged += OnColorSchemeChanged;
        }

        private void OnColorSchemeChanged(object sender, EventArgs e)
        {
            ApplyColorScheme();
        }

        private void InitializeColorBlindToggle()
        {
            chkColorBlindMode = new CheckBox
            {
                Text = "Color-Blind Friendly Mode",
                Font = new Font("Cascadia Code", 9F, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(20, 340),
                UseVisualStyleBackColor = true
            };
            chkColorBlindMode.CheckedChanged += ChkColorBlindMode_CheckedChanged;
            this.Controls.Add(chkColorBlindMode);
            chkColorBlindMode.BringToFront();
        }

        private void ChkColorBlindMode_CheckedChanged(object sender, EventArgs e)
        {
            ColorSchemeManager.SetColorBlindMode(chkColorBlindMode.Checked);
        }

        private void ApplyColorScheme()
        {
            // Update main form elements
            label1.ForeColor = ColorSchemeManager.LabelForeground;
            btnSinglePlayer.BackColor = ColorSchemeManager.ButtonBackground;
            btnSinglePlayer.ForeColor = ColorSchemeManager.ButtonForeground;
            btnBattleMode.BackColor = ColorSchemeManager.ButtonBackground;
            btnBattleMode.ForeColor = ColorSchemeManager.ButtonForeground;
            btnScoreInfo.BackColor = ColorSchemeManager.ButtonBackground;
            btnScoreInfo.ForeColor = ColorSchemeManager.ButtonForeground;
            btnHowToPlay.BackColor = ColorSchemeManager.ButtonBackground;
            btnHowToPlay.ForeColor = ColorSchemeManager.ButtonForeground;

            // Update checkbox colors
            chkColorBlindMode.ForeColor = ColorSchemeManager.LabelForeground;

            // Handle background image for color-blind mode
            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                this.BackgroundImage = null;
                this.BackColor = ColorSchemeManager.FormBackground;
                pictureBox1.Visible = false; // Hide decorative image
            }
            else
            {
                this.BackgroundImage = global::MemoryBattle.Properties.Resources.SummerSeasonImage;

                pictureBox1.Visible = true;
            }

            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ColorSchemeManager.ColorSchemeChanged -= OnColorSchemeChanged;
            base.OnFormClosed(e);
        }

        private void btnSinglePlayer_Click(object sender, EventArgs e)
        {
            using (var menu = new FormSinglePlayerMenu())
            {
                if (menu.ShowDialog(this) != DialogResult.OK) return;

                var settings = DifficultySlides.For(menu.SelectedDifficulty);

                using (var game = new FormGame(settings))
                {
                    Hide();
                    game.ShowDialog(this);
                    Show();
                }
            }
        }

        private void btnScoreInfo_Click(object sender, EventArgs e)
        {
            using (var leaderboard = new FormLeaderboard())
            {
                leaderboard.ShowDialog(this);
            }
        }

        private void btnBattleMode_Click(object sender, EventArgs e)
        {
            //using (var battleMenu = new FormBattleModeMenu())
            //{
            //    Hide();
            //    battleMenu.ShowDialog(this);
            //    Show();
            //}

            //use form gamemode selection for player to choose between PvP or PvC
            using (var modeSelection = new FormGameModeSelection())
            {
                if (modeSelection.ShowDialog(this) != DialogResult.OK) return;
            }
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