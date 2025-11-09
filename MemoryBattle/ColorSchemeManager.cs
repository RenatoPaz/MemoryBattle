//used copilot to help clean up my comments.

using System;
using System.Drawing;

namespace MemoryBattle.Details
{
    public static class ColorSchemeManager
    {
        public static bool IsColorBlindFriendly { get; private set; } = false;

        // Event to notify forms when color scheme changes
        public static event EventHandler ColorSchemeChanged;

        // Regular color scheme
        public static class Regular
        {
            public static readonly Color ButtonBackground = Color.PowderBlue;
            public static readonly Color ButtonForeground = SystemColors.ControlDarkDark;
            public static readonly Color LabelForeground = Color.DimGray;
            public static readonly Color CardHidden = Color.LightBlue;
            public static readonly Color CardRevealed = Color.White;
            public static readonly Color CardMatched = Color.LightGreen;
            public static readonly Color Player1Active = Color.FromArgb(200, Color.LightGreen);
            public static readonly Color Player1Inactive = Color.FromArgb(200, Color.LightBlue);
            public static readonly Color Player2Active = Color.FromArgb(200, Color.LightGreen);
            public static readonly Color Player2Inactive = Color.FromArgb(200, Color.LightCoral);
            public static readonly Color TimerBackground = Color.FromArgb(200, Color.Yellow);
            public static readonly Color CurrentPlayerBackground = Color.FromArgb(200, Color.White);
            public static readonly Color FormBackground = Color.Transparent;
        }

        // Color-blind friendly scheme - using distinct colors that are visible to most color-blind people
        public static class ColorBlindFriendly
        {
            // Using blue and yellow as these are distinguishable by most color-blind people
            public static readonly Color ButtonBackground = Color.FromArgb(70, 130, 180); // Steel Blue
            public static readonly Color ButtonForeground = Color.White;
            public static readonly Color LabelForeground = Color.Black;
            public static readonly Color CardHidden = Color.FromArgb(105, 105, 105); // Dim Gray
            public static readonly Color CardRevealed = Color.FromArgb(255, 255, 224); // Light Yellow
            public static readonly Color CardMatched = Color.FromArgb(0, 100, 0); // Dark Green (safe for most color-blind)

            // Player colors using patterns safe for color-blind users
            public static readonly Color Player1Active = Color.FromArgb(200, 25, 25, 112); // Midnight Blue
            public static readonly Color Player1Inactive = Color.FromArgb(200, 176, 196, 222); // Light Steel Blue
            public static readonly Color Player2Active = Color.FromArgb(200, 184, 134, 11); // Dark Goldenrod
            public static readonly Color Player2Inactive = Color.FromArgb(200, 255, 228, 181); // Moccasin

            public static readonly Color TimerBackground = Color.FromArgb(200, 139, 0, 0); // Dark Red
            public static readonly Color CurrentPlayerBackground = Color.FromArgb(200, 47, 79, 79); // Dark Slate Gray
            public static readonly Color FormBackground = Color.FromArgb(248, 248, 255); // Ghost White
        }

        // Property accessors for current scheme
        public static Color ButtonBackground => IsColorBlindFriendly ? ColorBlindFriendly.ButtonBackground : Regular.ButtonBackground;
        public static Color ButtonForeground => IsColorBlindFriendly ? ColorBlindFriendly.ButtonForeground : Regular.ButtonForeground;
        public static Color LabelForeground => IsColorBlindFriendly ? ColorBlindFriendly.LabelForeground : Regular.LabelForeground;
        public static Color CardHidden => IsColorBlindFriendly ? ColorBlindFriendly.CardHidden : Regular.CardHidden;
        public static Color CardRevealed => IsColorBlindFriendly ? ColorBlindFriendly.CardRevealed : Regular.CardRevealed;
        public static Color CardMatched => IsColorBlindFriendly ? ColorBlindFriendly.CardMatched : Regular.CardMatched;
        public static Color Player1Active => IsColorBlindFriendly ? ColorBlindFriendly.Player1Active : Regular.Player1Active;
        public static Color Player1Inactive => IsColorBlindFriendly ? ColorBlindFriendly.Player1Inactive : Regular.Player1Inactive;
        public static Color Player2Active => IsColorBlindFriendly ? ColorBlindFriendly.Player2Active : Regular.Player2Active;
        public static Color Player2Inactive => IsColorBlindFriendly ? ColorBlindFriendly.Player2Inactive : Regular.Player2Inactive;
        public static Color TimerBackground => IsColorBlindFriendly ? ColorBlindFriendly.TimerBackground : Regular.TimerBackground;
        public static Color CurrentPlayerBackground => IsColorBlindFriendly ? ColorBlindFriendly.CurrentPlayerBackground : Regular.CurrentPlayerBackground;
        public static Color FormBackground => IsColorBlindFriendly ? ColorBlindFriendly.FormBackground : Regular.FormBackground;

        public static void SetColorBlindMode(bool enabled)
        {
            if (IsColorBlindFriendly != enabled)
            {
                IsColorBlindFriendly = enabled;
                ColorSchemeChanged?.Invoke(null, EventArgs.Empty);
            }
        }

        public static void ToggleColorBlindMode()
        {
            SetColorBlindMode(!IsColorBlindFriendly);
        }
    }
}