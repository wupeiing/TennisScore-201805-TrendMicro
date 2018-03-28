﻿namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }

        public bool IsDifferentScore()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }
    }
}