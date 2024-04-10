    Brief

For the second online interview for the coding job, you have been asked to prepare a solution
application with **up-to six** classes:
  A Die class.
  A Game class.
  SevensOut class
  ThreeOrMore class
  A Statistics class
  A Testing class.

The rules for the two games are contained in the additional file (gameRules.txt)

The Die class should contain one property to hold the die current value, and one method that
returns an integer and takes no parameters:
  int Roll()

The Game class should have a menu which allows players to:
  Instantiate the Sevens Out game
  Instantiate the Three Or More game
  View statistics data
  Perform tests in Testing class.

The Statistics class should:
  Store game statistics for each game type (number of plays, high-scores, etc)

The Testing class should:
  Create a Game object.
  Use debug.assert() to verify:
    Sevens Out: Total of sum, stop if total = 7
    Three Or More: Scores set and added correctly, recognise when total >= 20.


    Dice Games

**Sevens Out**
2 x dice
Rules:
	Roll the two dice, noting the total rolled each time.
	If it is a 7 - stop.
	If it is any other number - add it to your total.
		If it is a double - add double the total to your score (3,3 would add 12 to your total)

**Three or More**
5 x dice
Rules:
	Roll all 5 dice hoping for a 3-of-a-kind or better.
	If 2-of-a-kind is rolled, player may choose to rethrow all, or the remaining dice.
	3-of-a-kind: 3 points
	4-of-a-kind: 6 points
	5-of-a-kind: 12 points
	First to a total of 20.


Player can choose either game to play through a menu.
Play with partner (on the same computer), or against the computer.
Should be a console implementation - but scope for extending it to a GUI application should be possible.
