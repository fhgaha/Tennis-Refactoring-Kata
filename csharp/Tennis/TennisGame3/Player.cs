using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.TennisGame3Folder
{
    class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public bool IsAheadByOnePointOf(Player opponent)
        {
            return (Points - opponent.Points) * (Points - opponent.Points) == 1;
        }

        public bool ScoredFourPoints()
        {
            return Points >= 4;
        }
    }
}
