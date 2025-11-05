using System;
using System.Drawing;
using System.Windows.Forms;
using MemoryBattle.Details; 

namespace MemoryBattle
{
    public partial class FormProgressiveMode : Form
    {
        private static readonly Difficulty[] _order =
        {
            Difficulty.Easy,
            Difficulty.Medium,
            Difficulty.Hard,
            Difficulty.Hardest,
            Difficulty.Pro
        };

        private int _currentIndex = 0;
        private int _lives;
        private readonly int _totalLevels = _order.Length;

        private Label _lblTitle;
        private Label _lblStatus;
        private ProgressBar _progress;
        private Button _btnPlay;
        private Button _btnExit;

        public FormProgressiveMode(int startingLives = 3)
        {
            InitializeComponent(); 

            _lives = Math.Max(1, startingLives);

            Text = "Memory Battle - Progressive Mode";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            _lblTitle = new Label
            {
                Text = "🧠 Progressive Mode",
                Font = new Font("Segoe UI", 22, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };

            _lblStatus = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 12),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            _progress = new ProgressBar
            {
                Dock = DockStyle.Top,
                Height = 24,
                Minimum = 0,
                Maximum = _totalLevels,
                Value = 0
            };

            var panelButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 80,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(16)
            };

            _btnPlay = new Button { Text = "Play", AutoSize = true };
            _btnPlay.Click += BtnPlay_Click;

            _btnExit = new Button { Text = "Exit", AutoSize = true };
            _btnExit.Click += (s, e) => Close();

            panelButtons.Controls.Add(_btnPlay);
            panelButtons.Controls.Add(_btnExit);

            Controls.Add(panelButtons);
            Controls.Add(_progress);
            Controls.Add(_lblStatus);
            Controls.Add(_lblTitle);

            UpdateStatus();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (IsFinished())
            {
                Close();
                return;
            }

            _btnPlay.Enabled = false;

            var outcome = PlayCurrentLevel();

            if (outcome == LevelOutcome.Completed)
                _progress.Value = Math.Min(_currentIndex, _totalLevels);

            UpdateStatus();

            if (IsFinished())
            {
                if (_lives > 0 && _currentIndex >= _totalLevels)
                {
                    MessageBox.Show("Congratulations! You have completed all stages!", "Progressive Mode",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }

                _btnPlay.Text = "Close";
            }

            _btnPlay.Enabled = true;
        }

        private enum LevelOutcome { Completed, RetryRequested, Aborted }

        private LevelOutcome PlayCurrentLevel()
        {
            var level = CurrentLevel();

            var settings = DifficultySlides.For(level);
            using (var game = new FormGame(settings))
            {
                var dr = game.ShowDialog(this);

                if (dr == DialogResult.Retry)
                {
                    return LevelOutcome.RetryRequested;
                }

                if (dr == DialogResult.OK)
                {
                    _currentIndex++;
                    return LevelOutcome.Completed;
                }

                _lives = Math.Max(0, _lives - 1);
                return LevelOutcome.Aborted;
            }
        }

        private Difficulty CurrentLevel()
        {
            int idx = Math.Min(_currentIndex, _totalLevels - 1);
            return _order[idx];
        }

        private bool IsFinished()
        {
            return _currentIndex >= _totalLevels || _lives <= 0;
        }

        private void UpdateStatus()
        {
            if (IsFinished())
            {
                _lblStatus.Text = "Concluído!";
                return;
            }

            var level = CurrentLevel();
            _lblStatus.Text =
                $"Level: {level}  •  Progresso: {_currentIndex}/{_totalLevels}  •  Vidas: {_lives}";
            _btnPlay.Text = $"Play {level}";
        }
    }
}
