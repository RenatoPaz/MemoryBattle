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
using MemoryBattle.Details.Cards;

namespace MemoryBattle
{
    public partial class FormGame : Form
    {
        private readonly GameEngine _engine;
        private readonly CardManager _cardManager;
        private List<MemoryCard> _memoryCards;
        private MemoryCard _firstCard, _secondCard;
        private bool _isChecking = false;
        private int _matchedPairs = 0;
        private int _totalPairs;

        // added to track whose turn it is
        private enum Turn { Player, AI }
        private Turn _turn = Turn.Player;

        // NEW: flag to indicate if this is pure single-player mode (no AI)
        protected bool IsSinglePlayerMode = true;

        public FormGame(GameSettings settings)
        {
            InitializeComponent();

            Difficulty difficulty = GetDifficultyFromSettings(settings);
            _engine = new GameEngine(settings, difficulty);
            _cardManager = new CardManager(settings);

            InitializeGame();
            ApplyColorScheme();
            ColorSchemeManager.ColorSchemeChanged += OnColorSchemeChanged;
        }

        private void OnColorSchemeChanged(object sender, EventArgs e)
        {
            ApplyColorScheme();
        }

        private void ApplyColorScheme()
        {
            // Handle background - only remove background image for color-blind mode
            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                this.BackgroundImage = null;
                this.BackColor = ColorSchemeManager.FormBackground;
                // Hide decorative picture boxes
                if (pictureBox1 != null) pictureBox1.Visible = false;
                if (pictureBox2 != null) pictureBox2.Visible = false;
            }
            else
            {
                // Show decorative picture boxes
                if (pictureBox1 != null) pictureBox1.Visible = true;
                if (pictureBox2 != null) pictureBox2.Visible = true;
            }

            // Refresh all card colors
            if (_memoryCards != null)
            {
                foreach (var card in _memoryCards)
                {
                    card.RefreshColors();
                }
            }

            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            ColorSchemeManager.ColorSchemeChanged -= OnColorSchemeChanged;
            base.OnFormClosed(e);
        }

        private Difficulty GetDifficultyFromSettings(GameSettings settings)
        {
            if (settings.Rows == 2 && settings.Columns == 3) return Difficulty.Easy;
            if (settings.Rows == 2 && settings.Columns == 4) return Difficulty.Medium;
            if (settings.Rows == 3 && settings.Columns == 4) return Difficulty.Hard;
            if (settings.Rows == 3 && settings.Columns == 6) return Difficulty.Hardest;
            if (settings.Rows == 4 && settings.Columns == 7) return Difficulty.Pro;
            return Difficulty.Easy;
        }

        private void InitializeGame()
        {
            _totalPairs = _engine.GetTotalPairs();
            CreateCards();

            // --- NEW: start with the player by default ---
            BeginPlayerTurn();
        }

        private void CreateCards()
        {
            List<string> cardValues = _engine.GenerateShuffledCards();
            int fontSize = _engine.GetFontSizeForDifficulty();

            _memoryCards = _cardManager.CreateCards(cardValues, this.ClientSize, fontSize);

            foreach (var card in _memoryCards)
            {
                // Ensure Tag is set to the card's index (CardManager should do this; if not, do it here)
                // card.CardButton.Tag = /* index of card in _memoryCards */;
                card.CardButton.Click += CardButton_Click;
                this.Controls.Add(card.CardButton);
                card.CardButton.BringToFront();
            }

            if (pictureBox1 != null) pictureBox1.SendToBack();
            if (pictureBox2 != null) pictureBox2.SendToBack();
        }

        // --- NEW: helper to enable/disable human input ---
        private void SetBoardEnabled(bool enabled)
        {
            if (_memoryCards == null) return;
            foreach (var c in _memoryCards)
            {
                c.CardButton.Enabled = enabled && !c.IsMatched;
            }
        }

        // --- NEW: turn transitions ---
        protected void BeginPlayerTurn()
        {
            _turn = Turn.Player;
            SetBoardEnabled(true);
        }

        protected void BeginAITurn()
        {
            _turn = Turn.AI;
            SetBoardEnabled(false);
            StartAITurn(); // virtual hook for AI forms
        }

        // derived AI form should override this to click two cards ---
        protected virtual void StartAITurn()
        {
            // Base game: no AI, do nothing.
            // In single-player mode, immediately return to player turn
            if (IsSinglePlayerMode)
            {
                BeginPlayerTurn();
            }
        }

        // routing Button.Click into a virtual, testable handler that receives the MemoryCard.
        private void CardButton_Click(object sender, EventArgs e)
        {
            // --- NEW: block human clicks when not player's turn ---
            if (_turn != Turn.Player) return;

            if (!(sender is Button clickedButton)) return;
            if (_isChecking) return;

            int cardIndex = (int)clickedButton.Tag;
            MemoryCard clickedCard = _memoryCards[cardIndex];

            OnCardClick(clickedCard);
        }

        protected virtual void OnCardClick(MemoryCard clickedCard)
        {
            if (_isChecking) return;

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

                Timer timer = new Timer();
                timer.Interval = 1000;
                timer.Tick += CheckForMatch;
                timer.Start();
            }
        }
        protected virtual void CheckForMatch(object sender, EventArgs e)
        {
            Timer timer = sender as Timer;
            timer?.Stop();
            timer?.Dispose();

            // --- NEW: snapshot who played this pair ---
            bool wasAITurn = (_turn == Turn.AI);

            bool isMatch = _engine.CheckForMatch(_firstCard.Value, _secondCard.Value);
            if (isMatch)
            {
                _firstCard.SetMatched();
                _secondCard.SetMatched();
                _matchedPairs++;

                // notify derived classes
                OnMatchFound();

                if (_matchedPairs == _totalPairs)
                {
                    // Ensure no more input
                    SetBoardEnabled(false);
                    ShowGameCompleteDialog();
                    return;
                }
            }
            else
            {
                _firstCard.Hide();
                _secondCard.Hide();

                // notify derived classes
                OnNoMatch();
            }

            // reset selection/checking state
            _firstCard = null;
            _secondCard = null;
            _isChecking = false;

            // FIXED: Handle turn transitions properly for single-player vs AI modes
            if (!GameOver)
            {
                if (IsSinglePlayerMode)
                {
                    // In single-player mode, always stay on player turn
                    BeginPlayerTurn();
                }
                else
                {
                    // In AI mode, switch between player and AI turns
                    if (wasAITurn)
                        BeginPlayerTurn();
                    else
                        BeginAITurn();
                }
            }
        }

        private void ShowGameCompleteDialog()
        {
            DialogResult result = _engine.ShowGameCompleteDialog();

            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected virtual void OnMatchFound()
        {
            // derived classes may override
        }

        protected virtual void OnNoMatch()
        {
            // derived classes may override
        }

        protected bool IsProcessing => _isChecking;
        protected bool SecondCardSelected => _secondCard != null;
        protected bool GameOver => _matchedPairs == _totalPairs;
        protected IEnumerable<MemoryCard> RevealedCards => _memoryCards.Where(c => c.IsRevealed && !c.IsMatched);
        protected List<MemoryCard> GetUnmatchedCards() => _memoryCards.Where(c => !c.IsMatched).ToList();
    }
}