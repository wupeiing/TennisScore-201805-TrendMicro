using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private const string Deuce = "Deuce";
        private readonly IRepository<Game> _repo;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (game.IsDifferentScore())
            {
                if (game.FirstPlayerScore > 3)
                {
                    if (Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
                    {
                        return game.FirstPlayerName + " Adv";
                    }
                }
                return ScoreLookup(game);
            }
            if (game.IsDeuce())
            {
                return Deuce;
            }
            return SameScore(game);
        }

        private string SameScore(Game game)
        {
            return _scoreLookup[game.FirstPlayerScore] + " All";
        }

        private string ScoreLookup(Game game)
        {
            return _scoreLookup[game.FirstPlayerScore] + " " + _scoreLookup[game.SecondPlayerScore];
        }
    }
}