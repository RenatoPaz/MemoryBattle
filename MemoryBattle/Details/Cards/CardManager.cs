using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryBattle.Details.Cards
{
    public class CardManager
    {
        private readonly GameSettings _settings;
        private readonly List<MemoryCard> _cards;

        public CardManager(GameSettings settings)
        {
            _settings = settings;
            _cards = new List<MemoryCard>();
        }

        public List<MemoryCard> CreateCards(List<string> cardValues, Size formSize, int fontSize)
        {
            _cards.Clear();
            Size cardSize = CalculateCardSize();

            for (int i = 0; i < cardValues.Count; i++)
            {
                Point position = CalculateCardPosition(i, cardSize, formSize);
                MemoryCard card = new MemoryCard(cardValues[i], i, cardSize, position, fontSize);
                _cards.Add(card);
            }

            return _cards;
        }

        public MemoryCard GetCardByIndex(int index)
        {
            return _cards.FirstOrDefault(c => c.Index == index);
        }

        public void ResetAllCards()
        {
            foreach (var card in _cards)
            {
                card.Reset();
            }
        }

        public int GetMatchedCount()
        {
            return _cards.Count(c => c.IsMatched);
        }

        private Size CalculateCardSize()
        {
            // Always use the fixed card size from GameSettings - no dynamic adjustment
            return new Size(_settings.CardWidth, _settings.CardHeight);
        }

        private Point CalculateCardPosition(int index, Size cardSize, Size formSize)
        {
            int spacing = _settings.Spacing;
            int col = index % _settings.Columns;
            int row = index / _settings.Columns;

            // Calculate starting position to center the grid
            int startX = (formSize.Width - (_settings.Columns * cardSize.Width + (_settings.Columns - 1) * spacing)) / 2;
            int startY = (formSize.Height - (_settings.Rows * cardSize.Height + (_settings.Rows - 1) * spacing)) / 2;

            return new Point(
                startX + col * (cardSize.Width + spacing),
                startY + row * (cardSize.Height + spacing)
            );
        }
    }
}