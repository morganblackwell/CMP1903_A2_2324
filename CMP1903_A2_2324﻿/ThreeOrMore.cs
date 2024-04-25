using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class ThreeOrMore
    {
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
            for (int i = startingRoll; i < 5; i++)
            {
                rolls[i] = dice[i].Roll();
            }

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
                Console.WriteLine($"Total: {total}");
                int rethrowChoice;
                if (bestIndex != 4)
                {
                    Console.WriteLine($"Rethrow all (1)\nRethrow from dice {bestIndex + 2} (2)");
                    rethrowChoice = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Rethrow all (1)");
                    rethrowChoice = int.Parse(Console.ReadLine());
                }

                if (rethrowChoice == 1)
                {
                    rolls = RollDice(dice, new int[5], 0);
                    (bestIndex, bestCount) = GetBestRoll(rolls);
                    total = GetTotal(bestCount, total, bestIndex, dice, rolls);
                }
                else if (rethrowChoice == 2)
                {
                    rolls = RollDice(dice, rolls, bestIndex + 1);
                    (bestIndex, bestCount) = GetBestRoll(rolls);
                    total = GetTotal(bestCount, total, bestIndex, dice, rolls);
                }

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

            return total;
        }
    

        public void Main()
        {
            int total = 0; // Start score at 0

            Die[] dice = CreateDice();

            while (total < 20)
            {
                Console.WriteLine("\nPress Enter to Roll: ");
                Console.ReadLine();

                int[] rolls = RollDice(dice, new int[5], 0);

                (int bestIndex, int bestCount) = GetBestRoll(rolls);

                total = GetTotal(bestCount, total, bestIndex, dice, rolls);
            }
        }
    }
}
