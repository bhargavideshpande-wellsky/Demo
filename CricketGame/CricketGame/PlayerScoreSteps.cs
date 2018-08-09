using FluentAssertions;
using System;
using TechTalk.SpecFlow;


namespace CricketGame.Specs
{
    [Binding]
    public class PlayerScoreSteps
    {
        private Cricket _game;
        [Given(@"Player has started a game of cricket")]
        [When(@"Player starts a game of cricket")]
        public void WhenPlayerHasStartedAGameOfCricket()
        {
            
            _game = new Cricket();
        }
        
        [Given(@"Player scores (.*) runs")]
        public void GivenPlayerScoresRuns(int run)
        {
            _game.Score(run);
        }
        [Given(@"Player gets out")]
        public void GivenPlayerGetsOut()
        {
            _game.PlayerStatus = false;
        }


        [When(@"Player score (.*) runs")]
        public void WhenPlayerScoreRuns(int run)
        {
            
            _game.Score(run);
        }
        

        [Then(@"the player score should be (.*)")]
        public void ThenThePlayerScoreShould(int score)
        {
           
            _game.PlayerScore.Should().Be(score);
        }

    }
}
