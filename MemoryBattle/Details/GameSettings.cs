using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace MemoryBattle.Details
{
    //Class is public sealed for easier use when calling it to different sections of the project
    //Using private to keep things controled and sealed

    //Holds the variables to build the necessary Difficulty engine for the game 
    public sealed class GameSettings
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public int Timer { get; private set; }
        public int MatchReward { get; private set; }
        public string Logo { get; private set; }
        //public string ExtraKnowledge { get; private set; }
        public GameSettings() 
            : this(rows: 3, columns: 3, timer: 60, matchReward: 1, logo: "icons")
            { }
        public GameSettings(int rows, int columns, int timer, int matchReward, string logo)
        {
            if (timer <= 0) {
                throw new ArgumentOutOfRangeException("Timer must be set to more than 1 second.");
        }
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException("Rows/Columns must be more than 0.");
            }
            //You can throw more exceptions here to avoid unecessary overlaps
            Rows = rows; Columns = columns; Timer = timer; MatchReward = matchReward; Logo = string.IsNullOrWhiteSpace(logo) ? "icons" : logo;
        }
    }
}
