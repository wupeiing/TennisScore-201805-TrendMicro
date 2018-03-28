using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        private const string AdvanceScoreResult = "Adv";
        private const string Deuce = "Deuce";

        private static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public string FirstPlayerName { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string SecondPlayerName { get; set; }
        public int SecondPlayerScore { get; set; }

        public string ScoreResult()
        {
            return IsDifferentScore()
                ? (IsReadyForWin() ? AdvState() : ScoreLookup())
                : (IsDeuce() ? Game.Deuce : SameScore());
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
        }

        private string AdvScore()
        {
            return AdvPlayer() + " " + Game.AdvanceScoreResult;
        }

        private string AdvState()
        {
            return IsAdvance() ? AdvScore() : WinScore();
        }

        private bool IsAdvance()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsDeuce()
        {
            var isSameScore = !IsDifferentScore();
            return FirstPlayerScore >= 3 && isSameScore;
        }

        private bool IsDifferentScore()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private string SameScore()
        {
            return Game._scoreLookup[this.FirstPlayerScore] + " All";
        }

        private string ScoreLookup()
        {
            return Game._scoreLookup[this.FirstPlayerScore] + " " + Game._scoreLookup[this.SecondPlayerScore];
        }

        private string WinScore()
        {
            return AdvPlayer() + " " + "Win";
        }
    }
}