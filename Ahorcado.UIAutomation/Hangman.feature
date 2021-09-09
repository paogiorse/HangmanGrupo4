Feature: Hangman
	In order to play the game
	As a player
	I want to guess a word and know if I won or not

@loose
Scenario: Loose the game
	Given I have generated the wordToGuess
	When I enter X as the typedLetter seven times
	Then I should be told that I lost

@winWithoutErrors
Scenario: Win the game without errors
	Given I have generated the wordToGuess
	When I enter only letters of the wordToGuess as the typedLetter
	Then I Should be told that I Won and without errors

@winWithErrors
Scenario: Win the game with errors
	Given I have generated the wordToGuess
	When I enter letters x, x and letters of the wordToGuess as the typedLetter
	Then I Should be told that I Won and with errors

@reset
Scenario: Reset the game
	Given I have generated the wordToGuess
	When I enter letters of the wordToGuess as the typedLetter and click on Resetear button
	Then I Should see Empezar Juego button enabled and Resetear button disabled