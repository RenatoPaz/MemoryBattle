using System;
using System.Drawing;
using System.Windows.Forms;
using MemoryBattle.Details;

namespace MemoryBattle
{
    public partial class FormProgressiveMode : Form
    {
        private Difficulty _currentLevel;
        private int _levelsCompleted = 0;
        private const int _totalLevels = 5;

        public FormProgressiveMode()
        {
            InitializeComponent();
            _currentLevel = Difficulty.Easy;
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Memory Battle - Progressive Mode";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            var lblTitle = new Label
            {
                Text = "🧠 Progressive Mode",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 70
            };
            Controls.Add(lblTitle);

            var lblInstruction = new Label
            {
                Text = "Play through all levels — Easy → Medium → Hard → Hardest → Pro",
                Dock = DockStyle.Top,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Height = 40
            };
            Controls.Add(lblInstruction);

            var btnStart = new Button
            {
                Text = "▶ Start Progressive Mode",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                BackColor = Color.FromArgb(30, 144, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.Click += (s, e) => StartProgressiveMode();
            Controls.Add(btnStart);
        }

        private void StartProgressiveMode()
        {
            MessageBox.Show("Let's begin! Level 1: Easy 😄", "Progressive Mode",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadNextLevel();
        }

        private void LoadNextLevel()
        {
            // Finished all levels?
            if (_currentLevel > Difficulty.Pro)
            {
                ShowFinalWinMessage();
                return;
            }

            // Build a brand-new settings object for this sublevel (no property sets!)
            GameSettings levelSettings = BuildSettingsForLevel(_currentLevel);

            using (var levelForm = new FormGame(levelSettings))
            {
                levelForm.Text = $"Memory Battle - Progressive ({_currentLevel})";
                DialogResult result = levelForm.ShowDialog();

                if (result == DialogResult.OK || result == DialogResult.Retry)
                {
                    _levelsCompleted++;
                    AdvanceLevel();
                }
                else
                {
                    // Player closed or cancelled
                    MessageBox.Show("Progressive Mode ended.", "Memory Battle",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void AdvanceLevel()
        {
            switch (_currentLevel)
            {
                case Difficulty.Easy:
                    _currentLevel = Difficulty.Medium;
                    MessageBox.Show("✅ Easy completed! Next: Medium 💪");
                    break;

                case Difficulty.Medium:
                    _currentLevel = Difficulty.Hard;
                    MessageBox.Show("✅ Medium completed! Next: Hard ⚔️");
                    break;

                case Difficulty.Hard:
                    _currentLevel = Difficulty.Hardest;
                    MessageBox.Show("✅ Hard completed! Next: Hardest 🧩");
                    break;

                case Difficulty.Hardest:
                    _currentLevel = Difficulty.Pro;
                    MessageBox.Show("✅ Hardest completed! Final Level: Pro 🔥");
                    break;

                case Difficulty.Pro:
                    ShowFinalWinMessage();
                    return;
            }

            LoadNextLevel();
        }

        private void ShowFinalWinMessage()
        {
            MessageBox.Show(
                "🎉 Congratulations! You completed all levels of Progressive Mode!\n\n" +
                "Levels completed: " + _levelsCompleted + "/" + _totalLevels,
                "Champion 🏆",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            this.Close();
        }

        // Creates a fresh GameSettings object based on the desired difficulty.
        // Adjust the constructor if your GameSettings API differs.
        private GameSettings BuildSettingsForLevel(Difficulty level)
        {
            int rows;
            int columns;

            switch (level)
            {
                case Difficulty.Easy:
                    rows = 2; columns = 3;
                    break;
                case Difficulty.Medium:
                    rows = 2; columns = 4;
                    break;
                case Difficulty.Hard:
                    rows = 3; columns = 4;
                    break;
                case Difficulty.Hardest:
                    rows = 3; columns = 6;
                    break;
                case Difficulty.Pro:
                    rows = 4; columns = 7;
                    break;
                default:
                    rows = 2; columns = 3;
                    break;
            }

            // If your GameSettings has a different constructor, tweak here:
            // e.g., return new GameSettings(rows, columns, /*other args if needed*/);
            return new GameSettings(rows, columns);
        }
    }
}
