using System;

namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

        public bool IsDifferentScore()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        public bool IsDeuce()
        {
            var isSameScore = !IsDifferentScore();
            return FirstPlayerScore >= 3 && isSameScore;
        }

        public string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
        }

        public bool IsAdvance()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        public bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }
    }
}