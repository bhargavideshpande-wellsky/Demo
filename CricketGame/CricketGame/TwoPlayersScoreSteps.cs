using FluentAssertions;
using System;
using TechTalk.SpecFlow;


namespace CricketGame
{
    [Binding]
    public class TwoPlayersScoreSteps
    {
        private Cricket _game2;
        [Given(@"PlayerOne has started a game of cricket")]
        [Given(@"PlayerTwo has started a game of cricket")]
        [Given(@"PlayerOne and PlayerTwo  has started running")]
        [When(@"PlayerOne starts a game of cricket and PlayerTwo starts a game of cricket")]
        public void WhenPlayerOneStartsAGameOfCricketAndPlayerTwoStartsAGameOfCricket()
        {
            _game2 = new Cricket();
        }
        [Given(@"PlayerOne scores (.*) runs and PlayerTwo scores (.*) runs")]
        public void GivenPlayerOneScoresRunsAndPlayerTwoScoresRuns(int run1, int run2)
        {
            //_game2 = new Cricket();
            _game2.Score2(run1, run2);
        }
        [Given(@"PlayerOne gets out")]
        public void GivenPlayerOneGetsOut()
        {
            //_game2 = new Cricket();
            _game2.Player1Status = false;
        }
        [Given(@"PlayerTwo gets out")]
        public void GivenPlayerTwoGetsOut()
        {
            //ScenarioContext.Current.Pending();
            _game2.Player2Status = false;
        }




        [Then(@"the PlayerOne score and PlayerTwo score is (.*)")]
        public void ThenThePlayerOneScoreAndPlayerTwoScoreIs(int Score)
        {
            _game2.PlayerScore1.Should().Be(Score);
            _game2.PlayerScore2.Should().Be(Score);
        }


        
        [When(@"PlayerOne Score (.*) and PlayerTwo Score (.*)")]
        public void WhenPlayerOneScoreAndPlayerTwoScore(int run1, int run2)
        {
           // _game2 = new Cricket();
            //ScenarioContext.Current.Pending();
            _game2.Score2(run1, run2);
        }



        
        [Then(@"the PlayerOne wins by (.*) runs")]
        public void ThenThePlayerOneWinsByRuns(int Score)
        {
            _game2.Winner.Should().Be(Score);
        }
        
        
        [When(@"PlayerTwo Score (.*) and PlayerOne Score (.*)")]
        public void WhenPlayerTwoScoreAndPlayerOneScore(int run1, int run2)
        {
            //_game2 = new Cricket();
            _game2.Score2(run1, run2);
            //ScenarioContext.Current.Pending();
        }
        [Then(@"the PlayerTwo wins by (.*) runs")]
        public void ThenThePlayerTwoWinsByRuns(int Score)
        {
            _game2.Winner.Should().Be(Score);
        }

        [Then(@"the Score is Equal")]
        public void ThenTheScoreIsEqual()
        {
           // ScenarioContext.Current.Pending();
        }






    }
}
