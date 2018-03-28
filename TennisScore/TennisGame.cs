using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private const string Deuce = "Deuce";
        private const string AdvanceScoreResult = "Adv";
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
                if (game.IsReadyForWin())
                {
                    if (game.IsAdvance())
                    {
                        return game.AdvPlayer() + " " + AdvanceScoreResult;
                    }

                    return game.AdvPlayer() + " " + "Win";
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