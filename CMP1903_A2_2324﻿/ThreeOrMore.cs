using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore
    {
        public void Main()
        {
            int total = 0; // Start score at 0

            // Create five dice
            Die die1 = new Die();
            Die die2 = new Die();
            Die die3 = new Die();
            Die die4 = new Die();
            Die die5 = new Die();

            while (total < 20)
            {
                // Roll dice
                int roll1 = die1.Roll();
                int roll2 = die2.Roll();
                int roll3 = die3.Roll();
                int roll4 = die4.Roll();
                int roll5 = die5.Roll();

                int[] rolls = { roll1, roll2, roll3, roll4, roll5 };

                int bestCount = -1;
                int bestIndex = -1;

                // Finds the best roll amount and its value. e.g rolling 11234 gives: two of a kind, last index = 1
                // Allows cutoff at last index when choosing to reroll values after
                for (int i = 0;  i < rolls.Length; i++)
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
                Console.WriteLine($"Roll 1 {roll1}\nRoll 2 {roll2}\nRoll 3 {roll3}\nRoll 4 {roll4}\nRoll 5 {roll5}\n");

                if (bestCount == 2)
                {
                    Console.WriteLine("2-of-a-kind");
                    Console.WriteLine($"Total: {total}");
                    Console.WriteLine($"Rethrow all (1)\nRethrow from dice {bestIndex +  1} (2)");
                    int rethrowChoice = int.Parse(Console.ReadLine());
                }
                else if (bestCount == 3)
                {
                    Console.WriteLine("3-of-a-kind");
                    total += 3;
                    Console.WriteLine($"Total: {total}");
                }
                else if (bestCount == 4)
                {
                    Console.WriteLine("4-of-a-kind");
                    total += 6;
                    Console.WriteLine($"Total: {total}");
                }
                else if (bestCount == 5)
                {
                    Console.WriteLine("5-of-a-kind");
                    total += 12;
                    Console.WriteLine($"Total: {total}");
                }
                else
                {
                    Console.WriteLine($"Total: {total}");
                }

                Console.ReadLine();
            }
        }
    }
}
