using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private TennisGame2Folder.Player player1;
        private TennisGame2Folder.Player player2;

        private string p1res = "";
        private string p2res = "";

        Dictionary<int, string> scoreTerms;

        public TennisGame2(string player1Name, string player2Name)
        {
            player1 = new TennisGame2Folder.Player { Name = player1Name };
            player2 = new TennisGame2Folder.Player { Name = player2Name };

            scoreTerms = new Dictionary<int, string>
            {
                [0] = "Love",
                [1] = "Fifteen",
                [2] = "Thirty",
                [3] = "Forty"
            };
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                player1.Points++;
            else
                player2.Points++;
        }

        public string GetScore()
        {
            var score = "";

            if (player1.Points == player2.Points && player1.Points < 3)
            {
                score = scoreTerms[player1.Points] + "-All";
            }

            if (player1.Points == player2.Points && player1.Points > 2)
            {
                return "Deuce";
            }

            if (player1.Points > 0 && player2.Points == 0)
            {
                if (player1.Points == 1)
                    p1res = "Fifteen";
                if (player1.Points == 2)
                    p1res = "Thirty";
                if (player1.Points == 3)
                    p1res = "Forty";

                score = p1res + "-Love";
                p2res = "Love";
            }
            if (player2.Points > 0 && player1.Points == 0)
            {
                if (player2.Points == 1)
                    p2res = "Fifteen";
                if (player2.Points == 2)
                    p2res = "Thirty";
                if (player2.Points == 3)
                    p2res = "Forty";

                p1res = "Love";
                score = "Love-" + p2res;
            }

            if (player1.Points > player2.Points && player1.Points < 4)
            {
                if (player1.Points == 2)
                    p1res = "Thirty";
                if (player1.Points == 3)
                    p1res = "Forty";
                if (player2.Points == 1)
                    p2res = "Fifteen";
                if (player2.Points == 2)
                    p2res = "Thirty";
                score = p1res + "-" + p2res;
            }
            if (player2.Points > player1.Points && player2.Points < 4)
            {
                if (player2.Points == 2)
                    p2res = "Thirty";
                if (player2.Points == 3)
                    p2res = "Forty";
                if (player1.Points == 1)
                    p1res = "Fifteen";
                if (player1.Points == 2)
                    p1res = "Thirty";
                score = p1res + "-" + p2res;
            }

            if (player1.Points > player2.Points && player2.Points >= 3)
            {
                score = "Advantage player1";
            }

            if (player2.Points > player1.Points && player1.Points >= 3)
            {
                score = "Advantage player2";
            }

            if (player1.Points >= 4 && player2.Points >= 0 && (player1.Points - player2.Points) >= 2)
            {
                score = "Win for player1";
            }
            if (player2.Points >= 4 && player1.Points >= 0 && (player2.Points - player1.Points) >= 2)
            {
                score = "Win for player2";
            }

            return score;
        }


    }
}

