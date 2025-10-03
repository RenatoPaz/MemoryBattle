using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryBattle.Details
{
    public static class BoardLayout
    {
        public static int GetOptimalColumns(int totalCards)
        {
            switch (totalCards)
            {
                case 6: return 3;   // 3x2 grid
                case 8: return 4;   // 4x2 grid
                case 12: return 4;  // 4x3 grid
                case 16: return 4;  // 4x4 grid
                case 20: return 5;  // 5x4 grid
                default: return 4;  // Default 4 columns
            }
        }
    }
}