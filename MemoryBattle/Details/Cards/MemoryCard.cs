using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryBattle.Details.Cards
{
    public class MemoryCard
    {
        public Button CardButton { get; private set; }
        public string Value { get; private set; }
        public int Index { get; private set; }
        public bool IsMatched { get; set; }
        public bool IsRevealed { get; set; }

        public MemoryCard(string value, int index, Size cardSize, Point position, int fontSize)
        {
            Value = value;
            Index = index;
            IsMatched = false;
            IsRevealed = false;

            CardButton = new Button
            {
                Size = cardSize,
                Location = position,
                Font = new Font("Arial", fontSize, FontStyle.Bold),
                BackColor = ColorSchemeManager.CardHidden,
                ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black,
                Text = ColorSchemeManager.IsColorBlindFriendly ? "■" : "?", // Use solid square for color-blind mode
                Tag = index,
                UseVisualStyleBackColor = false,
                FlatStyle = ColorSchemeManager.IsColorBlindFriendly ? FlatStyle.Flat : FlatStyle.Standard
            };

            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                CardButton.FlatAppearance.BorderSize = 2;
                CardButton.FlatAppearance.BorderColor = Color.Black;
            }
        }

        public void Reveal()
        {
            if (!IsMatched)
            {
                IsRevealed = true;
                CardButton.Text = Value;
                CardButton.BackColor = ColorSchemeManager.CardRevealed;
                CardButton.ForeColor = Color.Black;

                if (ColorSchemeManager.IsColorBlindFriendly)
                {
                    CardButton.FlatAppearance.BorderColor = Color.DarkBlue;
                    CardButton.FlatAppearance.BorderSize = 3;
                }
            }
        }

        public void Hide()
        {
            if (!IsMatched)
            {
                IsRevealed = false;
                CardButton.Text = ColorSchemeManager.IsColorBlindFriendly ? "■" : "?";
                CardButton.BackColor = ColorSchemeManager.CardHidden;
                CardButton.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;

                if (ColorSchemeManager.IsColorBlindFriendly)
                {
                    CardButton.FlatAppearance.BorderColor = Color.Black;
                    CardButton.FlatAppearance.BorderSize = 2;
                }
            }
        }

        public void SetMatched()
        {
            IsMatched = true;
            IsRevealed = true;
            CardButton.Enabled = false;
            CardButton.BackColor = ColorSchemeManager.CardMatched;
            CardButton.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
            CardButton.Text = Value;

            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                CardButton.FlatAppearance.BorderColor = Color.DarkGreen;
                CardButton.FlatAppearance.BorderSize = 4;
                // Add visual indicator for matched cards
                CardButton.Text = "✓ " + Value;
            }
        }

        public void Reset()
        {
            IsMatched = false;
            IsRevealed = false;
            CardButton.Enabled = true;
            CardButton.BackColor = ColorSchemeManager.CardHidden;
            CardButton.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
            CardButton.Text = ColorSchemeManager.IsColorBlindFriendly ? "■" : "?";

            if (ColorSchemeManager.IsColorBlindFriendly)
            {
                CardButton.FlatAppearance.BorderColor = Color.Black;
                CardButton.FlatAppearance.BorderSize = 2;
            }
        }

        public void RefreshColors()
        {
            CardButton.FlatStyle = ColorSchemeManager.IsColorBlindFriendly ? FlatStyle.Flat : FlatStyle.Standard;

            if (IsMatched)
            {
                CardButton.BackColor = ColorSchemeManager.CardMatched;
                CardButton.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
                if (ColorSchemeManager.IsColorBlindFriendly)
                {
                    CardButton.FlatAppearance.BorderColor = Color.DarkGreen;
                    CardButton.FlatAppearance.BorderSize = 4;
                    if (!CardButton.Text.StartsWith("✓"))
                        CardButton.Text = "✓ " + Value;
                }
                else
                {
                    CardButton.Text = Value;
                }
            }
            else if (IsRevealed)
            {
                CardButton.BackColor = ColorSchemeManager.CardRevealed;
                CardButton.ForeColor = Color.Black;
                if (ColorSchemeManager.IsColorBlindFriendly)
                {
                    CardButton.FlatAppearance.BorderColor = Color.DarkBlue;
                    CardButton.FlatAppearance.BorderSize = 3;
                }
            }
            else
            {
                CardButton.BackColor = ColorSchemeManager.CardHidden;
                CardButton.ForeColor = ColorSchemeManager.IsColorBlindFriendly ? Color.White : Color.Black;
                CardButton.Text = ColorSchemeManager.IsColorBlindFriendly ? "■" : "?";
                if (ColorSchemeManager.IsColorBlindFriendly)
                {
                    CardButton.FlatAppearance.BorderColor = Color.Black;
                    CardButton.FlatAppearance.BorderSize = 2;
                }
            }
        }
    }
}