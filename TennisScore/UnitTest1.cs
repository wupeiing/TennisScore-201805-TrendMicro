using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private TennisGame _tennisGame;
        private IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private const int AnyGameId = 91;

        [TestInitializeAttribute]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }

        [TestMethod]
        public void Love_All()
        {
            GivenGame(0, 0);
            ScoreShouldBe("Love All");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGame(0, 1);
            ScoreShouldBe("Love Fifteen");
        }

        private void ScoreShouldBe(string expected)
        {
            Assert.AreEqual(expected, _tennisGame.ScoreResult(AnyGameId));
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            _repository.GetGame(AnyGameId).Returns(new Game
            {
                Id = AnyGameId,
                FirstPlayerScore = firstPlayerScore,
                SecondPlayerScore = secondPlayerScore
            });
        }
    }
}