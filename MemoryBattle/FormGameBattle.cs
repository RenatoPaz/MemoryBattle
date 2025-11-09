using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MemoryBattle.Details;
using MemoryBattle.Details.Cards;

namespace MemoryBattle
{
    public partial class FormGameBattle : Form
    {
        // Player information
        private string player1Name, player2Name;
        private int currentPlayer, player1Score, player2Score;

        // UI labels
        private Label lblCurrentPlayer, lblPlayer1, lblPlayer2, lblTimer;

        // Game components
        private GameEngine _engine;
        private CardManager _cardManager;
        private GameSettings _settings;
        private Difficulty _difficulty;

        // Card tracking
        private List<MemoryCard> _memoryCards;
        private MemoryCard _firstCard, _secondCard;
        private bool _isChecking = false;
        private int _matchedPairs = 0, _totalPairs;

        // Super Battle features
        private bool _isSuperBattle;
        private List<SecretQuestion> _questions;
        private int _currentQuestionIndex = 0;
        private Timer _gameTimer;
        private int _timeRemaining, _initialTime;

        public FormGameBattle(string player1, string player2, Difficulty difficulty)
        {
            InitializeComponent();
            player1Name = string.IsNullOrWhiteSpace(player1) ? "Player 1" : player1;
            player2Name = string.IsNullOrWhiteSpace(player2) ? "Player 2" : player2;
            currentPlayer = 1;
            player1Score = 0;
            player2Score = 0;
            _difficulty = difficulty;
            _isSuperBattle = (difficulty == Difficulty.SuperBattle);

            if (_isSuperBattle)
            {
                _questions = QuestionBank.GetRandomQuestions(10);
                ShowTimerSelection();
            }

            InitializePlayerLabels();
            UpdateCurrentPlayerDisplay();
            InitializeGame();
            ApplyColorScheme();
            ColorSchemeManager.ColorSchemeChanged += OnColorSchemeChanged;

            if (_isSuperBattle && _initialTime > 0)
            {
                StartGameTimer();
            }
        }

        private void OnColorSchemeChanged(object sender, EventArgs e)
        {
            ApplyColorScheme();
            UpdateCurrentPlayerDisplay(); // Refresh player labels
        }

        private void ApplyColorScheme()
        {
            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                this.BackgroundImage = null;
                this.BackColor = ColorSchemeManager.FormBackground;
            }
            else
            {

            }

            // Refresh all card colors
            if (_memoryCards != null)
            {
                foreach (var card in _memoryCards)
                {
                    card.RefreshColors();
                }
            }

            // Update label colors
            if (lblTimer != null)
            {
                lblTimer.BackColor = ColorSchemeManager.TimerBackground;
                lblTimer.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
            }

            if (lblCurrentPlayer != null)
            {
                lblCurrentPlayer.BackColor = ColorSchemeManager.CurrentPlayerBackground;
                lblCurrentPlayer.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
            }

            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ColorSchemeManager.ColorSchemeChanged -= OnColorSchemeChanged;
            base.OnFormClosed(e);
        }

        private void ShowTimerSelection()
        {
            Form timerForm = new Form
            {
                Text = "Select Super Battle Timer",
                Size = new Size(400, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblTitle = new Label
            {
                Text = "Choose Timer Duration:",
                Font = new Font("Cascadia Code", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(80, 30)
            };
            timerForm.Controls.Add(lblTitle);

            Button btnEasy = CreateTimerButton("Easy (1:00)", 100, 70, 60, timerForm);
            Button btnMedium = CreateTimerButton("Medium (0:45)", 100, 115, 45, timerForm);
            Button btnHard = CreateTimerButton("Hard (0:30)", 100, 160, 30, timerForm);

            if (timerForm.ShowDialog(this) == DialogResult.OK)
            {
                _timeRemaining = _initialTime;
            }
            else
            {
                _initialTime = 60;
                _timeRemaining = 60;
            }
        }

        private Button CreateTimerButton(string text, int x, int y, int time, Form parent)
        {
            Button btn = new Button
            {
                Text = text,
                Font = new Font("Cascadia Code", 10F),
                Location = new Point(x, y),
                Size = new Size(200, 35)
            };
            btn.Click += (s, e) => { _initialTime = time; parent.DialogResult = DialogResult.OK; parent.Close(); };
            parent.Controls.Add(btn);
            return btn;
        }

        private void StartGameTimer()
        {
            _gameTimer = new Timer { Interval = 1000 };
            _gameTimer.Tick += GameTimer_Tick;
            _gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            _timeRemaining--;
            UpdateTimerDisplay();

            if (_timeRemaining <= 0)
            {
                _gameTimer.Stop();
                HandleTimeout();
            }
        }

        private void UpdateTimerDisplay()
        {
            if (lblTimer != null)
            {
                int minutes = _timeRemaining / 60;
                int seconds = _timeRemaining % 60;
                lblTimer.Text = $"Time: {minutes:D2}:{seconds:D2}";
                lblTimer.ForeColor = _timeRemaining <= 10 ? Color.Red :
                    (ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black);
            }
        }

        private void HandleTimeout()
        {
            DialogResult result = MessageBox.Show(
                "Time's up! The round will restart.\n\nReady to try again?",
                "Timeout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
                RestartGame();
            else
                this.Close();
        }

        private void InitializeGame()
        {
            _settings = DifficultySlides.For(_difficulty);
            _engine = new GameEngine(_settings, _difficulty);
            _cardManager = new CardManager(_settings);
            _totalPairs = _engine.GetTotalPairs();
            CreateCards();
        }

        private void CreateCards()
        {
            List<string> cardValues = _engine.GenerateShuffledCards();
            int fontSize = _engine.GetFontSizeForDifficulty();
            _memoryCards = _cardManager.CreateCards(cardValues, this.ClientSize, fontSize);

            foreach (var card in _memoryCards)
            {
                card.CardButton.Click += CardButton_Click;
                this.Controls.Add(card.CardButton);
                card.CardButton.BringToFront();
            }

            lblCurrentPlayer.BringToFront();
            lblPlayer1.BringToFront();
            lblPlayer2.BringToFront();

            if (_isSuperBattle && lblTimer != null)
                lblTimer.BringToFront();
        }

        private void CardButton_Click(object sender, EventArgs e)
        {
            if (_isChecking) return;

            Button clickedButton = sender as Button;
            int cardIndex = (int)clickedButton.Tag;
            MemoryCard clickedCard = _memoryCards[cardIndex];

            if (clickedCard == _firstCard || clickedCard.IsMatched) return;

            clickedCard.Reveal();

            if (_firstCard == null)
            {
                _firstCard = clickedCard;
            }
            else if (_secondCard == null)
            {
                _secondCard = clickedCard;
                _isChecking = true;

                Timer timer = new Timer { Interval = 1000 };
                timer.Tick += CheckForMatch;
                timer.Start();
            }
        }

        private void CheckForMatch(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer.Stop();
            timer.Dispose();

            if (_engine.CheckForMatch(_firstCard.Value, _secondCard.Value))
            {
                _firstCard.SetMatched();
                _secondCard.SetMatched();
                _matchedPairs++;

                if (_isSuperBattle)
                {
                    _gameTimer?.Stop();
                    ShowQuestion();
                }
                else
                {
                    if (currentPlayer == 1)
                        player1Score++;
                    else
                        player2Score++;

                    UpdateCurrentPlayerDisplay();

                    if (_matchedPairs == _totalPairs)
                        ShowGameCompleteDialog();

                    _firstCard = null;
                    _secondCard = null;
                    _isChecking = false;
                }
            }
            else
            {
                _firstCard.Hide();
                _secondCard.Hide();
                SwitchPlayer();

                _firstCard = null;
                _secondCard = null;
                _isChecking = false;
            }
        }

        private void ShowQuestion()
        {
            if (_currentQuestionIndex >= _questions.Count)
                _currentQuestionIndex = 0;

            SecretQuestion question = _questions[_currentQuestionIndex];
            _currentQuestionIndex++;

            Form questionForm = new Form
            {
                Text = "Secret Question",
                Size = new Size(500, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblPlayerName = new Label
            {
                Text = $"{GetCurrentPlayerName()}'s Turn - Answer the Question!",
                Font = new Font("Cascadia Code", 12F, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };
            questionForm.Controls.Add(lblPlayerName);

            Label lblQuestion = new Label
            {
                Text = question.Question,
                Font = new Font("Cascadia Code", 10F),
                AutoSize = false,
                Size = new Size(440, 60),
                Location = new Point(20, 60)
            };
            questionForm.Controls.Add(lblQuestion);

            TextBox txtAnswer = new TextBox
            {
                Font = new Font("Cascadia Code", 10F),
                Location = new Point(20, 140),
                Size = new Size(440, 30)
            };
            questionForm.Controls.Add(txtAnswer);

            Button btnSubmit = new Button
            {
                Text = "Submit Answer",
                Font = new Font("Cascadia Code", 10F),
                Location = new Point(170, 200),
                Size = new Size(150, 40)
            };
            questionForm.Controls.Add(btnSubmit);

            btnSubmit.Click += (s, ev) =>
            {
                string answer = txtAnswer.Text.Trim();

                if (string.IsNullOrWhiteSpace(answer))
                {
                    MessageBox.Show("Please enter an answer!", "Empty Answer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (question.IsCorrect(answer))
                {
                    MessageBox.Show("Correct! You keep your turn!", "Correct Answer", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (currentPlayer == 1)
                        player1Score++;
                    else
                        player2Score++;

                    questionForm.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show($"Wrong! The correct answer was: {question.CorrectAnswer}\n\nTurn passes to your opponent.", "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SwitchPlayer();
                    questionForm.DialogResult = DialogResult.Cancel;
                }

                questionForm.Close();
            };

            questionForm.AcceptButton = btnSubmit;
            questionForm.ShowDialog(this);

            UpdateCurrentPlayerDisplay();

            _firstCard = null;
            _secondCard = null;
            _isChecking = false;

            if (_matchedPairs == _totalPairs)
            {
                _gameTimer?.Stop();
                ShowGameCompleteDialog();
            }
            else if (_isSuperBattle)
            {
                _gameTimer?.Start();
            }
        }

        private void ShowGameCompleteDialog()
        {
            string winner;
            if (player1Score > player2Score)
                winner = $"{player1Name} wins!";
            else if (player2Score > player1Score)
                winner = $"{player2Name} wins!";
            else
                winner = "It's a tie!";

            string modeText = _isSuperBattle ? "Super Battle Complete!" : "Battle Mode Complete!";

            DialogResult result = MessageBox.Show(
                $"{modeText}\n\n{winner}\n\n{player1Name}: {player1Score} pairs\n{player2Name}: {player2Score} pairs\n\nWould you like to play again?",
                modeText,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
                RestartGame();
            else
                this.Close();
        }

        private void RestartGame()
        {
            player1Score = 0;
            player2Score = 0;
            currentPlayer = 1;
            _matchedPairs = 0;
            _currentQuestionIndex = 0;

            if (_isSuperBattle)
            {
                _timeRemaining = _initialTime;
                _gameTimer?.Stop();
            }

            foreach (var card in _memoryCards)
            {
                this.Controls.Remove(card.CardButton);
                card.CardButton.Dispose();
            }
            _memoryCards.Clear();

            if (_isSuperBattle)
                _questions = QuestionBank.GetRandomQuestions(10);

            _engine = new GameEngine(_settings, _difficulty);
            _cardManager = new CardManager(_settings);

            UpdateCurrentPlayerDisplay();

            if (_isSuperBattle)
                UpdateTimerDisplay();

            CreateCards();
            ApplyColorScheme();

            if (_isSuperBattle)
                StartGameTimer();
        }

        private void InitializePlayerLabels()
        {
            if (_isSuperBattle)
            {
                lblTimer = new Label
                {
                    Font = new Font("Cascadia Code", 14F, FontStyle.Bold),
                    BackColor = ColorSchemeManager.TimerBackground,
                    ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black,
                    AutoSize = true,
                    Location = new Point(this.ClientSize.Width - 150, 20)
                };
                this.Controls.Add(lblTimer);
                UpdateTimerDisplay();
            }

            lblCurrentPlayer = new Label
            {
                Font = new Font("Cascadia Code", 12F, FontStyle.Bold),
                BackColor = ColorSchemeManager.CurrentPlayerBackground,
                ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black,
                AutoSize = true,
                Location = new Point(20, 20)
            };
            this.Controls.Add(lblCurrentPlayer);

            lblPlayer1 = new Label
            {
                Font = new Font("Cascadia Code", 10F),
                BackColor = ColorSchemeManager.Player1Inactive,
                ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black,
                AutoSize = true,
                Location = new Point(20, 60)
            };
            this.Controls.Add(lblPlayer1);

            lblPlayer2 = new Label
            {
                Font = new Font("Cascadia Code", 10F),
                BackColor = ColorSchemeManager.Player2Inactive,
                ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black,
                AutoSize = true,
                Location = new Point(20, 90)
            };
            this.Controls.Add(lblPlayer2);
        }

        private void UpdateCurrentPlayerDisplay()
        {
            string currentPlayerName = currentPlayer == 1 ? player1Name : player2Name;
            lblCurrentPlayer.Text = $"Current Turn: {currentPlayerName}";

            lblPlayer1.Text = $"{player1Name}: {player1Score} pairs";
            lblPlayer2.Text = $"{player2Name}: {player2Score} pairs";

            lblPlayer1.BackColor = currentPlayer == 1 ? ColorSchemeManager.Player1Active : ColorSchemeManager.Player1Inactive;
            lblPlayer2.BackColor = currentPlayer == 2 ? ColorSchemeManager.Player2Active : ColorSchemeManager.Player2Inactive;

            // Update text colors for color-blind mode
            lblPlayer1.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
            lblPlayer2.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
        }

        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            UpdateCurrentPlayerDisplay();
        }

        public string GetCurrentPlayerName()
        {
            return currentPlayer == 1 ? player1Name : player2Name;
        }

        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _gameTimer?.Stop();
            _gameTimer?.Dispose();
            base.OnFormClosing(e);
        }
    }
}