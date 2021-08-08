Feature: Hangman
	In order to play the game
	As a player
	I want to guess a word and know if I won or not

@mytag
Scenario: Loose the game
	Given I have entered Ahorcado as the wordToGuess
	When I enter X as the typedLetter five times
	Then I should be told that I lost
