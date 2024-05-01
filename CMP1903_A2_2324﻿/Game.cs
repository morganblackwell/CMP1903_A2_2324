using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    abstract class Game // Abstract, cannot be used to create objects
    {
        protected string GameName { get; set; } = null;
        static void Main() // Entry point
        {
            Game[] games = { new SevensOut(), new ThreeOrMore() };

            while (true)
            {
                // Output all available games along with the number for the user to select it
                for (int i = 0; i < games.Length; i++)
                {
                    Console.WriteLine($"{games[i].GameName} ({i + 1})");
                }
                Console.WriteLine($"Statistics ({games.Length + 1})\nTesting ({games.Length + 2})");
                try
                {
                    int menuChoice = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");

                    if (menuChoice == 1)
                    {
                        SevensOut sevensOut = new SevensOut();
                        sevensOut.Main();
                    }
                    else if (menuChoice == 2)
                    {
                        ThreeOrMore threeOrMore = new ThreeOrMore();
                        threeOrMore.Main();
                    }
                    else if (menuChoice == games.Length + 1)
                    {
                        
                        Statistics statistics = new Statistics();
                        statistics.GetStatisticChoice();

                    }
                    else if (menuChoice == games.Length + 2)
                    {
                        Testing testing = new Testing();

                        testing.IsTest = true; // Start testing
                        testing.TestAll();
                        testing.IsTest = false; // End testing

                        // Output all tested features
                        Console.WriteLine("\nTested features:");
                        foreach (string test in testing.tested)
                        {
                            Console.WriteLine(test);
                        }
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine($"Input must be an integer between 1 and {games.Length + 2}");
                        Main();
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must be an integer");
                    Main();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input too big or small");
                    Main();
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Exception {exception}");
                    Main();
                }
            }
        }
    }
}