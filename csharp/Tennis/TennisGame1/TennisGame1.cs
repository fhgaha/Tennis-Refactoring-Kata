using Tennis.TennisGame1Folder;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private Player player1 = new();
        private Player player2 = new();

        public TennisGame1(string player1Name, string player2Name)
        {
            player1.Name = player1Name;
            player2.Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1.Score++;
            else
                player2.Score++;
        }

        public string GetScore()
        {
            string output = "";

            if (player1.Score == player2.Score)
            {
                //draw game
                return player1.Score < 3
                    ? player1.GetScoreAsTerm() + "-All"
                    : "Deuce";
            }
            else if (player1.Score < 4 && player2.Score < 4)
            {
                //ongoing
                output = player1.GetScoreAsTerm() + '-' + player2.GetScoreAsTerm();
            }
            else
            {
                //advantage or win
                switch (player1.Score - player2.Score)
                {
                    case 1:
                        return "Advantage player1";
                    case -1:
                        return "Advantage player2";
                    case >= 2:
                        return "Win for player1";
                    default:
                        return "Win for player2";
                }
            }

            return output;
        }
    }
}

