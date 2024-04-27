using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class SevensOut
    {
        public void Main()
        {
            Console.WriteLine("Multiplayer (1) or Computer (2)");
            int opponentOption = int.Parse(Console.ReadLine());
            Console.WriteLine();

            bool twoPlayer;
            if (opponentOption == 1) twoPlayer = true; else twoPlayer = false; 

            bool activePlayer = false; // false = player 1, true = player 2
            Statistics statistics = new Statistics();
            statistics.SetTimesPlayed();

            int playerOneScore = 0;
            int playerTwoScore = 0; // Start score at 0

            // Create two dice
            Die die1 = new Die();
            Die die2 = new Die();

            while (true)
            {
                activePlayer = !activePlayer; // Swap player

                // Roll both dice
                int roll1 = die1.Roll();
                int roll2 = die2.Roll();

                int total = roll1 + roll2; // total = the sum of both dice

                if (roll1 == roll2) // If both values are the same
                {
                    if (activePlayer == true) playerOneScore += total * 2; else playerTwoScore += total * 2; // Add double the total of rolls to score
                }
                else
                {
                    if (activePlayer == true) playerOneScore += total; else playerTwoScore += total; // Add rolls to score
                }

                if (twoPlayer == false)
                {
                    Console.WriteLine($"{(activePlayer ? "Player 1" : "Computer")}");
                }
                else
                {
                    Console.WriteLine($"Player {(activePlayer ? 1 : 2)}");
                }

                Console.WriteLine($"Roll 1: {roll1}\nRoll 2: {roll2}");
                Console.Write("Score: ");
                if (activePlayer == true) Console.WriteLine(playerOneScore); else Console.WriteLine(playerTwoScore);  // Output rolls and score
                Console.WriteLine();

                if (total == 7) // End game
                {
                    if (playerOneScore > playerTwoScore)
                    {
                        Console.WriteLine($"Player 1 Wins, Score: {playerOneScore}:{playerTwoScore}");
                    }
                    else if (playerTwoScore > playerOneScore)
                    {
                        if (twoPlayer == true)
                        {
                            Console.WriteLine($"Player 2 Wins, Score: {playerTwoScore}:{playerOneScore}");
                        }
                        else
                        {
                            Console.WriteLine($"Computer Wins, Score: {playerTwoScore}:{playerOneScore}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Draw, Score: {playerOneScore}:{playerTwoScore}");
                    }

                    break;
                }

                if (activePlayer == false || twoPlayer == true)
                {
                    Console.WriteLine($"Player {(activePlayer ? 2 : 1)} Press enter to roll");
                    Console.ReadLine(); // Waits for user to continue
                }
                
            }

        }
    }
}
