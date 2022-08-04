namespace Tennis.TennisGame1Folder
{
    public class Player
    {
        public int Score { get; set; }
        public string Name { get; set; }

        internal string GetScoreAsTerm()
        {
            switch (Score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
            }
            return "";
        }
    }
}
