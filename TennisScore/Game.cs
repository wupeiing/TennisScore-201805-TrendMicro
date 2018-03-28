using System;
using System.Collections.Generic;

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

        public const string Deuce = "Deuce";
        public const string AdvanceScoreResult = "Adv";

        public static Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public string AdvScore()
        {
            return AdvPlayer() + " " + Game.AdvanceScoreResult;
        }

        public string WinScore()
        {
            return AdvPlayer() + " " + "Win";
        }

        public string AdvState()
        {
            return IsAdvance() ? AdvScore() : WinScore();
        }

        public string ScoreLookup()
        {
            return Game._scoreLookup[this.FirstPlayerScore] + " " + Game._scoreLookup[this.SecondPlayerScore];
        }

        public string SameScore()
        {
            return Game._scoreLookup[this.FirstPlayerScore] + " All";
        }

        public string ScoreResult()
        {
            return IsDifferentScore()
                ? (IsReadyForWin() ? AdvState() : ScoreLookup())
                : (IsDeuce() ? Game.Deuce : SameScore());
        }
    }
}