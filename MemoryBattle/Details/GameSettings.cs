using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace MemoryBattle.Details
{
    public sealed class GameSettings
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Timer { get; private set; }
        public int MatchReward { get; private set; }
        public string Logo { get; private set; }

        // Added card properties
        public int CardWidth { get; private set; }
        public int CardHeight { get; private set; }
        public int Spacing { get; private set; }

        public GameSettings()
            : this(rows: 3, columns: 3, timer: 60, matchReward: 1, logo: "icons", cardWidth: 80, cardHeight: 80, spacing: 10)
        { }

        public GameSettings(int rows, int columns, int timer, int matchReward, string logo, int cardWidth = 80, int cardHeight = 80, int spacing = 10)
        {
            if (timer <= 0)
            {
                throw new ArgumentOutOfRangeException("Timer must be set to more than 1 second.");
            }
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException("Rows/Columns must be more than 0.");
            }

            Rows = rows;
            Columns = columns;
            Timer = timer;
            MatchReward = matchReward;
            Logo = string.IsNullOrWhiteSpace(logo) ? "icons" : logo;
            CardWidth = cardWidth;
            CardHeight = cardHeight;
            Spacing = spacing;
        }
    }
}