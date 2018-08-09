using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CricketGame.test
{
    [TestClass]
    public class CricketGamesTests
    {
        [TestMethod]
        public void PlayerScore_NewGame_ShouldBeZero()
        {
            Cricket game = new Cricket();
            Assert.IsTrue(game.PlayerScore == 0);
        }
        [TestMethod]
        public void Score_ValidRuns_ShouldUpdatePlayerScore()
        {
            Cricket game = new Cricket();
            game.Score(3);
            Assert.IsTrue(game.PlayerScore == 3);
        }
       [TestMethod]
        public void Score_InvalidRuns_ShouldUpdatePlayerScore()
        {
            Cricket game = new Cricket();
             game.Score(7);
            Assert.IsTrue(game.PlayerScore == 0);
        }
        [TestMethod]
        public void BothPlayersScore_NewGame_ShouldBeZero()
        {
            Cricket game2 = new Cricket();
            Assert.IsTrue(game2.PlayerScore1 == 0);
            Assert.IsTrue(game2.PlayerScore2 == 0);
        }
        [TestMethod]
        public void PlayerOne_StartsGame_ShouldWin()
        {
            Cricket game2 = new Cricket();
            game2.Score2(3, 0);
            Assert.IsTrue(game2.Winner == 3);
            
        }
    }
}

