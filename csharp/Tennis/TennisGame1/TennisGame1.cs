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
            if (PlayersAreTied())
            {
                return GetDrawResult();
            }
            else if (PlayersScoreBelowFour())
            {
                return GetOngoingResult();
            }
            else
            {
                return GetAdvantageOrWinResult();
            }
        }

        private bool PlayersAreTied() => player1.Score == player2.Score;

        private bool PlayersScoreBelowFour() => player1.Score < 4 && player2.Score < 4;

        private string GetOngoingResult() => $"{player1.GetScoreAsTerm()}-{player2.GetScoreAsTerm()}";

        private string GetDrawResult() 
            => player1.Score < 3
                ? player1.GetScoreAsTerm() + "-All"
                : "Deuce";

        private string GetAdvantageOrWinResult() 
            => ScoreDifferenceIsOne()
                ? GetMessage("Advantage ")
                : GetMessage("Win for ");

        private string GetMessage(string messagePattern) 
            => player1.Score > player2.Score
                ? messagePattern + "player1"
                : messagePattern + "player2";

        private bool ScoreDifferenceIsOne() 
            => player1.Score - player2.Score == 1 || player2.Score - player1.Score == 1;
    }
}

