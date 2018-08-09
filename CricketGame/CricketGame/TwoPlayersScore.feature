Feature: TwoPlayersScore
	In order to  enjoy a game of cricket
	As a player
	I want to be told the maximum score

@mytag
Scenario: PlayerOne score is zero when game starts and PlayerTwo score is zero
	When  PlayerOne starts a game of cricket and PlayerTwo starts a game of cricket
	Then the PlayerOne score and PlayerTwo score is 0

Scenario: PlayerOne should be able to score run when he starts the game
	Given PlayerOne has started a game of cricket
	When  PlayerOne Score 4 and PlayerTwo Score 0
	Then  the PlayerOne wins by 4 runs

Scenario: PlayerTwo should be able to score run when he starts the game
	Given PlayerTwo has started a game of cricket
	When  PlayerTwo Score 4 and PlayerOne Score 0
	Then  the PlayerTwo wins by 4 runs

Scenario: PlayerOne and PlayerTwo should be able to score multiple run together  
	Given PlayerOne and PlayerTwo  has started running
	When  PlayerOne Score 4 and PlayerTwo Score 10
	Then  the PlayerOne wins by 10 runs

Scenario: PlayerOne and PlayerTwo should be able to score equal run   
	Given PlayerOne and PlayerTwo  has started running
	When  PlayerOne Score 10 and PlayerTwo Score 10
	Then  the Score is Equal

Scenario: PlayerOne should not be able score runs after getting out
	Given PlayerOne and PlayerTwo  has started running
	And   PlayerOne scores 4 runs and PlayerTwo scores 6 runs
	And   PlayerOne gets out
	When  PlayerOne Score 3 and PlayerTwo Score 2
	Then  the PlayerTwo wins by 8 runs

Scenario: PlayerTwo should not be able score runs after getting out
	Given PlayerOne and PlayerTwo  has started running
	And   PlayerOne scores 4 runs and PlayerTwo scores 6 runs
	And   PlayerTwo gets out
	When  PlayerOne Score 3 and PlayerTwo Score 2
	Then  the PlayerOne wins by 7 runs

