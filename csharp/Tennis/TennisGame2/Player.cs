﻿using System;
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

        public bool IsTiedWith(Player opponent)
        {
            return Points == opponent.Points;
        }

        public bool HasAdvantageOver(Player opponent)
        {
            return Points > opponent.Points && opponent.Points >= 3;
        }
    }
}
