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
        private readonly GameSettings _settings;
        private readonly Difficulty _difficulty;
        private readonly GameEngine _engine;
        private readonly CardManager _cardManager;
        private List<MemoryCard> _memoryCards;
        private MemoryCard _firstCard, _secondCard;
        private bool _isChecking = false;
        private int _matchedPairs = 0;
        private int _totalPairs;

        public FormGame(GameSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            // Determine difficulty from GameSettings.cs
            _difficulty = GetDifficultyFromSettings(settings);
            _engine = new GameEngine(settings, _difficulty);
            _cardManager = new CardManager(settings);

            this.Text = $"Memory Battle - {_settings.Rows}x{_settings.Columns}";

            // Set fixed window size
            this.Size = new Size(800, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Normal;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            InitializeGame();
        }

        private Difficulty GetDifficultyFromSettings(GameSettings settings)
        {
            if (settings.Rows == 2 && settings.Columns == 3) return Difficulty.Easy;
            if (settings.Rows == 2 && settings.Columns == 4) return Difficulty.Medium;
            if (settings.Rows == 3 && settings.Columns == 5) return Difficulty.Hard;
            if (settings.Rows == 3 && settings.Columns == 6) return Difficulty.Hardest;
            if (settings.Rows == 4 && settings.Columns == 7) return Difficulty.Pro;
            if (settings.Rows == 5 && settings.Columns == 10) return Difficulty.Progressive;
            return Difficulty.Easy;
        }

        private void InitializeGame()
        {
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

            pictureBox1.SendToBack();
            pictureBox2.SendToBack();
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

                Timer timer = new Timer();
                timer.Interval = 1000;
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

                if (_matchedPairs == _totalPairs)
                {
                    ShowGameCompleteDialog();
                }
            }
            else
            {
                _firstCard.Hide();
                _secondCard.Hide();
            }

            _firstCard = null;
            _secondCard = null;
            _isChecking = false;
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
    }
}