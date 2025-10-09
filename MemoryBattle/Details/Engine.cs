using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryBattle.Details
{
    public class GameEngine
    {
        private readonly GameSettings _settings;
        private readonly Difficulty _difficulty;

        public GameEngine(GameSettings settings, Difficulty difficulty)
        {
            _settings = settings;
            _difficulty = difficulty;
        }

        //public int GetTotalPairs()
        //{
        //    return (_settings.Rows * _settings.Columns) / 2;
        //}
        public int GetTotalPairs()
        {
            int totalCells = _settings.Rows * _settings.Columns;
            return totalCells / 2;
        }

        private readonly Random _rng = new Random();
        public string[] GetSymbolsForDifficulty()
        {
            switch (_difficulty)
            {
                case Difficulty.Easy:
                    // Simple geometric shapes - easy to distinguish
                    return new string[] { "●", "■", "▲", "♦", "★", "♥", "◆", "▼" };

                case Difficulty.Medium:
                    // Unicode symbols - moderate difficulty
                    return new string[] { "♠", "♣", "♥", "♦", "★", "☀", "♪", "⚡", "☂", "✈", "⚽", "♨" };

                case Difficulty.Hard:
                    // Similar looking symbols - harder to distinguish
                    return new string[] { "◐", "◑", "◒", "◓", "◔", "◕", "◖", "◗", "◘", "◙", "◚", "◛", "⚡", "☂", "✈", "⚽", "♨" };

                case Difficulty.Hardest:
                    // Mathematical and special symbols - very similar
                    return new string[] { "∆", "∇", "∈", "∉", "∋", "∌", "∝", "∞", "∟", "∠", "∡", "∢", "∧", "∨", "∩", "∪" };

                case Difficulty.Pro:
                    // Complex Unicode characters - extremely challenging
                    return new string[] { "ᄀ", "ᄁ", "ᄂ", "ᄃ", "ᄄ", "ᄅ", "ᄆ", "ᄇ", "ᄈ", "ᄉ", "ᄊ", "ᄋ", "ᄌ", "ᄍ", "ᄎ", "ᄏ", "ᄐ", "ᄑ", "ᄒ", "ᄓ" };

                case Difficulty.Progressive:
                    // Use existing settings but with simple symbols for now
                    return new string[] { "●", "■", "▲", "♦", "★", "♥", "◆", "▼", "○", "□", "△", "◇", "☆", "♡", "◈", "▽", "●", "■", "▲", "♦", "★", "♥", "◆", "▼", "○", "□", "△", "◇", "☆", "♡", "◈", "▽", "◐", "◑", "◒", "◓", "◔", "◕", "◖", "◗", "◘", "◙", "◚", "◛", "◝", "◞", "◟", "◠", "◡", "◢", "◣", "◤" };

                default:
                    return new string[] { "●", "■", "▲", "♦", "★", "♥", "◆", "▼" };
            }
        }

        public List<string> GenerateShuffledCards()
        {
            var symbols = GetSymbolsForDifficulty();
            var cardValues = new List<string>();

            int totalCells = _settings.Rows * _settings.Columns;
            int totalPairs = GetTotalPairs();

            //Implementing error handlign to catch if the symbols are not enough for the pairs
            if (totalPairs > symbols.Length)
                throw new InvalidOperationException(
                    $"Not enough symbols for difficulty {_difficulty}. Need {totalPairs}, have {symbols.Length}.");

            //Add normal pairs
            for (int i = 0; i < totalPairs; i++)
            {
                cardValues.Add(symbols[i]);
                cardValues.Add(symbols[i]);
            }

            //If the board has an odd number of cells, add one extra card
            //(duplicates one of the existing symbols so you'll have a triple)
            if (totalCells % 2 != 0)
            {
                string duplicate = symbols[_rng.Next(totalPairs)];
                cardValues.Add(duplicate);
            }

            return ShuffleCards(cardValues);
        }

        private List<string> ShuffleCards(List<string> cards)
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = _rng.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
            return cards;
        }

        public int GetFontSizeForDifficulty()
        {
            switch (_difficulty)
            {
                case Difficulty.Easy:
                    return 16; // Larger font for simple shapes
                case Difficulty.Medium:
                    return 14; // Medium font for symbols
                case Difficulty.Hard:
                    return 14;
                case Difficulty.Hardest:
                    return 14;
                case Difficulty.Pro:
                    return 24;
                case Difficulty.Progressive:
                    return 14;
                default:
                    return 12;
            }
        }

        public bool CheckForMatch(string firstCardValue, string secondCardValue)
        {
            return firstCardValue == secondCardValue;
        }

        public DialogResult ShowGameCompleteDialog()
        {
            return MessageBox.Show(
                "Congratulations! You won!\n\nWould you like to play again?",
                "Game Complete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
        }
    }
}