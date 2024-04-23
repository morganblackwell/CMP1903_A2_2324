using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class SevensOut
    {
        public void Main()
        {
            Statistics statistics = new Statistics();
            statistics.SetTimesPlayed();

            int score = 0; // Start score at 0

            // Create two dice
            Die die1 = new Die();
            Die die2 = new Die();

            while (true)
            {
                // Roll both dice
                int roll1 = die1.Roll();
                int roll2 = die2.Roll();

                int total = roll1 + roll2; // total = the sum of both dice

                if (total != 7)
                {
                    if (roll1 == roll2) // If both values are the same
                    {
                        score += total * 2; // Add double the total of rolls to score
                    }
                    else
                    {
                        score += total; // Add rolls to score
                    }

                    Console.WriteLine($"Roll 1: {roll1}\nRoll 2: {roll2}\nscore: {score}\n"); // Output rolls and score

                    Console.WriteLine("Press enter to roll");
                    Console.ReadLine(); // Waits for user to continue
                }
                else // Stops when roll total = 7
                {
                    if (score > statistics.GetSevensHighScore()) // Check if score > high score
                    {
                        statistics.SetSevensHighScore(score); // Change high score
                    }

                    Console.WriteLine($"Roll 1: {roll1}\nRoll 2: {roll2}\nFinal Score: {score}\n"); // Output total 7 roll and final score
                    statistics.OutputStatistics(); // Output stats
                    break;
                }
            }

        }
    }
}
