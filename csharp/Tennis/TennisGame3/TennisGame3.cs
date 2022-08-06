using Tennis.TennisGame3Folder;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private Player player1;
        private Player player2;

        private string[] terms = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            player1 = new Player { Name = player1Name };
            player2 = new Player { Name = player2Name };
        }

        public string GetScore()
        {
            if (!player1.ScoredFourPoints() 
                && !player2.ScoredFourPoints() 
                && !SixRoundsPlayed())
            {
                return PlayersTied()
                    ? terms[player1.Points] + "-All"
                    : terms[player1.Points] + "-" + terms[player2.Points];
            }
            else if (PlayersTied())
            {
                return "Deuce";
            }

            var winningPlayer = player1.Points > player2.Points
                ? player1.Name
                : player2.Name;

            return player1.IsAheadByOnePointOf(player2)
                ? "Advantage " + winningPlayer
                : "Win for " + winningPlayer;
        }

        private bool PlayersTied()
        {
            return player1.Points == player2.Points;
        }

        private bool SixRoundsPlayed()
        {
            return player1.Points + player2.Points >= 6;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1.Points++;
            else
                player2.Points++;
        }

    }
}

