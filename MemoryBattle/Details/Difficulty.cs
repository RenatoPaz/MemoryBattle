using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryBattle.Details
{
    //Holds the difficulty logic for the game, and will be connected for the difficulty for different game modess
    public enum Difficulty { Easy, Medium, Hard, Hardest, Pro, Progressive}
    public static class DifficultySlides
    {
        public static GameSettings For (Difficulty e)
        {
            switch (e)
            {
                case Difficulty.Easy:
                    return new GameSettings(rows: 2, columns: 3, timer: 60, matchReward: 1, logo: "icons");
                case Difficulty.Medium:
                    return new GameSettings(rows: 2, columns: 4, timer: 60, matchReward: 1, logo: "icons");
                case Difficulty.Hard:
                    return new GameSettings(rows: 3, columns: 5, timer: 60, matchReward: 1, logo: "icons");
                case Difficulty.Hardest:
                    return new GameSettings(rows: 3, columns: 6, timer: 60, matchReward: 1, logo: "icons");
                case Difficulty.Pro:
                    return new GameSettings(rows: 4, columns: 7, timer: 60, matchReward: 1, logo: "icons");
                case Difficulty.Progressive:
                    return new GameSettings(rows: 5, columns: 10, timer: 60, matchReward: 1, logo: "icons");
                default:
                    return new GameSettings();
            }
        }
    }

}
