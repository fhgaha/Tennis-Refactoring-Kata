using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis.TennisGame2Folder
{
    class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

        public bool HasAdvantageOver(Player player2)
        {
            return Points > player2.Points && player2.Points >= 3;
        }
    }
}
