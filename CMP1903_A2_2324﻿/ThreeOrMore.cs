using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore : Game
    {
        public ThreeOrMore()
        {
            GameName = "Three Or More";
        }
        private Die[] CreateDice()
        {
            // Create five dice
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            Die die4 = new Die();
            Die die5 = new Die();

            Die[] dice = { die1, die2, die3, die4, die5 };
            return dice;
        }

        private int[] RollDice(Die[] dice, int[] rolls, int startingRoll)
        {
            // Roll the five dice starting from startingRoll parameter
            for (int i = startingRoll; i < 5; i++) 
            {
                rolls[i] = dice[i].Roll();
            }

            // Output rolls
            Console.WriteLine($"\nRoll 1 {rolls[0]}\nRoll 2 {rolls[1]}\nRoll 3 {rolls[2]}\nRoll 4 {rolls[3]}\nRoll 5 {rolls[4]}\n");

            return rolls;
        }

        private (int, int) GetBestRoll(int[] rolls)
        {
            int bestCount = -1;
            int bestIndex = -1;

            // Finds the best roll amount and its value. e.g rolling 11234 gives: two of a kind, last index = 1
            // Allows cutoff at last index when choosing to reroll values after
            for (int i = 0; i < rolls.Length; i++)
            {
                int count = 1; // Counts starts at 1 (itself)
                for (int j = i + 1; j < rolls.Length; j++) // Start at value after searched for value
                {
                    if (rolls[i] == rolls[j]) // If element = searched for value
                    {
                        count += 1; // increment count

                        if (count > bestCount)
                        {
                            bestCount = count; // Gets the best roll amount
                            bestIndex = j; // Gets the last index of the best roll amount
                        }
                    }
                }
            }

            return (bestIndex, bestCount);
        }

        private int GetTotal(int bestCount, int total, int bestIndex, Die[] dice, int[] rolls)
        {
            if (bestCount == 2)
            {
                Console.WriteLine("2-of-a-kind");
                int rethrowChoice;
                if (bestIndex != 4) // If last roll of scored dice is not the last index
                {
                    Console.WriteLine($"Rethrow all (1)\nRethrow from dice {bestIndex + 2} (2)");
                    rethrowChoice = int.Parse(Console.ReadLine());
                }
                else // Can only reroll all
                {
                    Console.WriteLine("Rethrow all (1)");
                    rethrowChoice = int.Parse(Console.ReadLine());
                }

                if (rethrowChoice == 1) // Rethrow all
                {
                    rolls = RollDice(dice, new int[5], 0); // Start rolls from start using an empty list
                    (bestIndex, bestCount) = GetBestRoll(rolls);
                    total = GetTotal(bestCount, total, bestIndex, dice, rolls);
                }
                else if (rethrowChoice == 2) // Rethrow from last scored dice
                {
                    rolls = RollDice(dice, rolls, bestIndex + 1); // Start rolls from index after last scored
                    (bestIndex, bestCount) = GetBestRoll(rolls);
                    total = GetTotal(bestCount, total, bestIndex, dice, rolls);
                }
            }
            else // Not 2-of-a-kind
            {
                int score;
                if (bestCount == 3)
                {
                    Console.WriteLine("3-of-a-kind");
                    score = 3;
                    total += score;
                }
                else if (bestCount == 4)
                {
                    Console.WriteLine("4-of-a-kind");
                    score = 6;
                    total += score;
                }
                else if (bestCount == 5)
                {
                    Console.WriteLine("5-of-a-kind");
                    score = 12;
                    total += score;
                }

                Console.WriteLine($"Total: {total}");
            }

            return total;
        }
    
        public void Main()
        {
            Testing testing = new Testing();
            if (testing.IsTest) Console.WriteLine("Testing Three Or More\n");

            Statistics statistics = new Statistics();
            statistics.ThreeOrMorePlays += 1;

            Console.WriteLine("Multiplayer (1) or Computer (2)");
            int opponentOption = int.Parse(Console.ReadLine());
            Console.WriteLine();

            bool twoPlayer;
            if (opponentOption == 1) twoPlayer = true; else twoPlayer = false;

            bool activePlayer = true; // false = player 1, true = player 2

            int playerOneScore = 0;
            int playerTwoScore = 0;
             
            Die[] dice = CreateDice();

            while (playerOneScore < 20 && playerTwoScore < 20) // loop until score > 19
            {
                Console.WriteLine();
                if (twoPlayer == false) // Singleplayer, against a computer
                {
                    Console.WriteLine($"{(activePlayer ? "Player 1" : "Computer")}");
                }
                else
                {
                    Console.WriteLine($"Player {(activePlayer ? 1 : 2)}");
                }

                if (activePlayer == false || twoPlayer == true) // Don't ask for input if computers turn
                {
                    Console.WriteLine("\nPress Enter to Roll: ");
                    Console.ReadLine();
                }

                int[] rolls = RollDice(dice, new int[5], 0);

                (int bestIndex, int bestCount) = GetBestRoll(rolls);

                if (activePlayer == true) // If player one, edit player ones score
                {
                    playerOneScore = GetTotal(bestCount, playerOneScore, bestIndex, dice, rolls);
                }
                else // Edit player twos score
                {
                    playerTwoScore = GetTotal(bestCount, playerTwoScore, bestIndex, dice, rolls);
                }

                activePlayer = !activePlayer; // Swap players
            }

            // Output winner
            if (playerOneScore > playerTwoScore)
            {
                Console.WriteLine($"Player 1 Wins, Score: {playerOneScore}:{playerTwoScore}");
                statistics.PlayerOneWins += 1;

                if (playerOneScore > statistics.ThreeOrMoreHighScore)
                {
                    statistics.ThreeOrMoreHighScore = playerOneScore;
                }
            }
            else if (playerTwoScore > playerOneScore)
            {
                if (twoPlayer == true)
                {
                    Console.WriteLine($"Player 2 Wins, Score: {playerTwoScore}:{playerOneScore}");
                    statistics.PlayerTwoWins += 1;

                    if (playerTwoScore > statistics.ThreeOrMoreHighScore)
                    {
                        statistics.ThreeOrMoreHighScore = playerTwoScore;
                    }
                }
                else
                {
                    Console.WriteLine($"Computer Wins, Score: {playerTwoScore}:{playerOneScore}");
                    statistics.ComputerWins += 1;

                    // Don't change highscore if belongs to computer
                }
            }

            // Check if game has ended on a score of score > 20
            if (testing.IsTest == true)
            {
                Debug.Assert(playerOneScore >= 20 || playerTwoScore >= 20, $"Game ended below 20");
            }
        }
    }
}
