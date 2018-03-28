using System;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (game.FirstPlayerScore == 0 && game.SecondPlayerScore == 2)
            {
                return "Love" + " " + "Thirty";
            }
            if (game.FirstPlayerScore == 0 && game.SecondPlayerScore == 1)
            {
                return "Love" + " " + "Fifteen";
            }
            return "Love All";
        }
    }
}