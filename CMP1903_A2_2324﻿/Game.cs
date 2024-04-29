using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Game
    {
        static void Main() // Entry point
        {
            while (true)
            {
                Console.WriteLine("\nSevens Out (1)\nThree Or More (2)\nStatistics (3)\nTesting (4)");
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
                    else if (menuChoice == 3)
                    {
                        Statistics statistics = new Statistics();
                    }
                    else if (menuChoice == 4)
                    {
                        Testing testing = new Testing();

                        testing.IsTest = true; // Start testing
                        testing.TestAll();
                        testing.IsTest = false; // End testing
                    }
                    else
                    {
                        Console.WriteLine("Input must be an integer between 1 and 4");
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