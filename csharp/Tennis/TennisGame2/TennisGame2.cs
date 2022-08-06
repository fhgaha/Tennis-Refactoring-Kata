using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private TennisGame2Folder.Player player1;
        private TennisGame2Folder.Player player2;

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
            if (player1.IsTiedWith(player2))
            {
                return GetTiedScore();
            }

            if (player1.Wins(player2))
            {
                return "Win for player1";
            }

            if (player2.Wins(player1))
            {
                return "Win for player2";
            }

            if (player1.HasAdvantageOver(player2))
            {
                return "Advantage player1";
            }

            if (player2.HasAdvantageOver(player1))
            {
                return "Advantage player2";
            }

            return Other();
        }

        private string Other()
        {
            var score = "";

            if (player1.HasZeroAndOpponentAhead(player2))
            {
                score = "Love-" + scoreTerms[player2.Points];
            }

            if (player2.HasZeroAndOpponentAhead(player1))
            {
                score = scoreTerms[player1.Points] + "-Love";
            }

            if (player1.AheadOfOpponentAndBelowFour(player2)
                || player2.AheadOfOpponentAndBelowFour(player1))
            {
                score = scoreTerms[player1.Points] + "-" + scoreTerms[player2.Points];
            }

            return score;
        }

        private string GetTiedScore()
        {
            return player1.Points > 2
                ? "Deuce"
                : scoreTerms[player1.Points] + "-All";
        }
    }
}

