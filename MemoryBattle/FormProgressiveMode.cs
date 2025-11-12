using System;
using System.Drawing;
using System.Media;
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

        // UI Controls (hidden by default; shown only on finish)
        private Label _lblTitle;
        private Label _lblStatus;
        private ProgressBar _progress;
        private Button _btnRestart;
        private Button _btnExit;

        public FormProgressiveMode(int startingLives = 3)
        {
            InitializeComponent();

            _lives = Math.Max(1, startingLives);

            // Form setup (minimal, like FormGame)
            Text = "Memory Battle - Progressive Mode";
            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.LightBlue;  // Match FormGame theme

            // UI Controls (initially hidden)
            _lblTitle = new Label
            {
                Text = "🧠 Progressive Mode",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.Transparent,
                Visible = false
            };

            _lblStatus = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.Black,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.Transparent,
                Visible = false
            };

            _progress = new ProgressBar
            {
                Dock = DockStyle.Top,
                Height = 30,
                Minimum = 0,
                Maximum = _totalLevels,
                Value = 0,
                Style = ProgressBarStyle.Continuous,
                ForeColor = Color.Green,
                Visible = false
            };

            var panelButtons = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 100,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(20),
                BackColor = Color.Transparent,
                Visible = false
            };

            _btnRestart = new Button
            {
                Text = "Restart",
                Font = new Font("Segoe UI", 12),
                Size = new Size(120, 40),
                BackColor = Color.Orange,
                FlatStyle = FlatStyle.Flat
            };
            _btnRestart.Click += (s, e) => { ResetGame(); StartProgressivePlay(); };

            _btnExit = new Button
            {
                Text = "Exit",
                Font = new Font("Segoe UI", 12),
                Size = new Size(120, 40),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat
            };
            _btnExit.Click += (s, e) => Close();

            panelButtons.Controls.Add(_btnRestart);
            panelButtons.Controls.Add(_btnExit);

            Controls.Add(panelButtons);
            Controls.Add(_progress);
            Controls.Add(_lblStatus);
            Controls.Add(_lblTitle);

            // Auto-start the progressive play (like FormGame opens directly)
            StartProgressivePlay();
        }

        private void StartProgressivePlay()
        {
            while (!IsFinished())
            {
                var outcome = PlayCurrentLevel();
                if (outcome == LevelOutcome.Completed)
                {
                    _currentIndex++;
                    _progress.Value = Math.Min(_currentIndex, _totalLevels);
                    SystemSounds.Beep.Play();  // Optional feedback
                }
                else if (outcome == LevelOutcome.Aborted)
                {
                    _lives = Math.Max(0, _lives - 1);
                }
                // No retry loop here; assume FormGame handles retries internally
            }

            // Game finished: Show end screen
            ShowEndScreen();
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
                    // Retry the same level (loop back)
                    return PlayCurrentLevel();
                }
                if (dr == DialogResult.OK)
                {
                    return LevelOutcome.Completed;
                }
                return LevelOutcome.Aborted;
            }
        }

        private void ShowEndScreen()
        {
            // Reveal UI for end screen
            _lblTitle.Visible = true;
            _lblStatus.Visible = true;
            _progress.Visible = true;


            if (_lives > 0 && _currentIndex >= _totalLevels)
            {
                _lblStatus.Text = "Congratulations! All levels completed!";
            }
            else
            {
                _lblStatus.Text = "Game Over! No lives left.";
            }
        }

        private void ResetGame()
        {
            _currentIndex = 0;
            _lives = 3;  // Or pass as param
            _progress.Value = 0;
            // Hide UI again
            _lblTitle.Visible = false;
            _lblStatus.Visible = false;
            _progress.Visible = false;
            Controls.Find("panelButtons", true)[0].Visible = false;
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
    }
}
