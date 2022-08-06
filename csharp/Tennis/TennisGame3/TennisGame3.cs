using Tennis.TennisGame3Folder;

namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private Player player1;
        private Player player2;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1 = new Player { Name = player1Name };
            this.player2 = new Player { Name = player2Name };
        }

        public string GetScore()
        {
            string s;
            if ((player1.Points < 4 && player2.Points < 4) && (player1.Points + player2.Points < 6))
            {
                string[] terms = { "Love", "Fifteen", "Thirty", "Forty" };
                s = terms[player1.Points];
                return (player1.Points == player2.Points) ? s + "-All" : s + "-" + terms[player2.Points];
            }
            else
            {
                if (player1.Points == player2.Points)
                    return "Deuce";
                s = player1.Points > player2.Points ? player1.Name : player2.Name;
                return ((player1.Points - player2.Points) * (player1.Points - player2.Points) == 1) ? "Advantage " + s : "Win for " + s;
            }
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

