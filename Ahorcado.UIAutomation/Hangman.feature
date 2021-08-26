Feature: Hangman
	In order to play the game
	As a player
	I want to guess a word and know if I won or not

@loose
Scenario: Loose the game
	Given I have generated the wordToGuess
	When I enter X as the typedLetter five times
	Then I should be told that I lost

@win
Scenario: Win the game without errors
	Given I have generated the wordToGuess gato
	When I enter letters g, a, t and o as the typedLetter
	Then I Should be told that I Won