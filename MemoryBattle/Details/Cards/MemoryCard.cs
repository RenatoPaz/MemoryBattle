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
                BackColor = Color.LightBlue,
                Text = "?",
                Tag = index,
                UseVisualStyleBackColor = false
            };
        }

        public void Reveal()
        {
            if (!IsMatched)
            {
                IsRevealed = true;
                CardButton.Text = Value;
                CardButton.BackColor = Color.White;
            }
        }

        public void Hide()
        {
            if (!IsMatched)
            {
                IsRevealed = false;
                CardButton.Text = "?";
                CardButton.BackColor = Color.LightBlue;
            }
        }

        public void SetMatched()
        {
            IsMatched = true;
            IsRevealed = true;
            CardButton.Enabled = false;
            CardButton.BackColor = Color.LightGreen;
            CardButton.Text = Value;
        }

        public void Reset()
        {
            IsMatched = false;
            IsRevealed = false;
            CardButton.Enabled = true;
            CardButton.BackColor = Color.LightBlue;
            CardButton.Text = "?";
        }
    }
}