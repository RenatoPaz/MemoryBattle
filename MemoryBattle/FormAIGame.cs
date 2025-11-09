using MemoryBattle.Details;
using MemoryBattle.Details.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MemoryBattle
{
    public partial class FormAIGame : FormGame
    {
        private readonly List<CardMemory> _aiMemory = new List<CardMemory>();
        private readonly Random _random = new Random();
        private readonly string _playerName;

        public FormAIGame() : base(new GameSettings())
        {
            InitializeComponent();
            _playerName = "Player";
            InitializeAIGameUI();
        }

        public FormAIGame(GameSettings settings) : base(settings)
        {
            InitializeComponent();
            _playerName = "Player";
            InitializeAIGameUI();
        }

        public FormAIGame(GameSettings settings, string playerName) : base(settings)
        {
            InitializeComponent();
            _playerName = string.IsNullOrWhiteSpace(playerName) ? "Player" : playerName;
            InitializeAIGameUI();
        }

        private void InitializeAIGameUI()
        {
            this.Text = $"Memory Battle - {_playerName} vs AI";
            if (lblMode != null) lblMode.Text = "Mode: Player vs AI";
            SetTurnLabel(true);

            if (cmbAIDifficulty != null && cmbAIDifficulty.Items.Count > 0)
                cmbAIDifficulty.SelectedIndex = 0;
        }

        private void SetTurnLabel(bool isPlayer)
        {
            if (lblTurn == null) return;
            lblTurn.Text = $"Turn: {(isPlayer ? "Player" : "AI")}";
            lblTurn.ForeColor = isPlayer ? Color.Blue : Color.Red;
        }

        protected override void OnCardClick(MemoryCard clickedCard)
        {
            base.OnCardClick(clickedCard);
            foreach (var card in RevealedCards) UpdateAIMemory(card);
        }

        protected override async void StartAITurn()
        {
            SetTurnLabel(false);
            if (!GameOver) await RunAIMoveAsync();
        }

        protected override void OnMatchFound()
        {
            base.OnMatchFound();
            foreach (var card in RevealedCards) UpdateAIMemory(card);
        }

        protected override void OnNoMatch()
        {
            base.OnNoMatch();
            SetTurnLabel(true);
        }

        private async Task RunAIMoveAsync()
        {
            var unmatched = GetUnmatchedCards();
            if (unmatched.Count < 2) return;

            var firstPick = ChooseFirstPick(unmatched);
            await Task.Delay(350);
            ClickAsAI(firstPick);

            await Task.Delay(450);
            foreach (var card in RevealedCards) UpdateAIMemory(card);

            var secondPick = ChooseSecondPick(unmatched, firstPick);
            if (secondPick == null) return;

            await Task.Delay(350);
            ClickAsAI(secondPick);
        }

        private MemoryCard ChooseFirstPick(List<MemoryCard> unmatched)
        {
            bool preferKnown = (cmbAIDifficulty != null && cmbAIDifficulty.SelectedIndex > 0);
            if (preferKnown)
            {
                var known = FindKnownPairCard(unmatched);
                if (known != null) return known;
            }
            return unmatched[_random.Next(unmatched.Count)];
        }

        private MemoryCard ChooseSecondPick(List<MemoryCard> unmatched, MemoryCard firstPick)
        {
            var memMatch = _aiMemory.FirstOrDefault(m => m.Value == firstPick.Value && m.Index != firstPick.Index);
            if (memMatch != null)
                return unmatched.FirstOrDefault(c => c.Index == memMatch.Index);

            var otherKnown = FindKnownPairCard(unmatched.Where(c => c.Index != firstPick.Index).ToList());
            if (otherKnown != null) return otherKnown;

            var candidates = unmatched.Where(c => c.Index != firstPick.Index).ToList();
            if (candidates.Count == 0) return null;

            return candidates[_random.Next(candidates.Count)];
        }

        private MemoryCard FindKnownPairCard(List<MemoryCard> unmatched)
        {
            var pairs = _aiMemory
                .GroupBy(m => m.Value)
                .Where(g => g.Count() > 1)
                .SelectMany(g => g)
                .OrderBy(_ => _random.Next())
                .ToList();

            foreach (var mem in pairs)
            {
                var card = unmatched.FirstOrDefault(c => c.Index == mem.Index);
                if (card != null) return card;
            }
            return null;
        }

        private void ClickAsAI(MemoryCard card)
        {
            if (card == null) return;
            OnCardClick(card);
        }

        private void UpdateAIMemory(MemoryCard card)
        {
            if (card == null) return;
            if (_aiMemory.Any(m => m.Index == card.Index)) return;
            _aiMemory.Add(new CardMemory(card.Index, card.Value));
        }

        private class CardMemory
        {
            public int Index { get; }
            public string Value { get; }
            public DateTime SeenAt { get; }
            public CardMemory(int index, string value)
            {
                Index = index;
                Value = value;
                SeenAt = DateTime.Now;
            }
        }
    }
}
