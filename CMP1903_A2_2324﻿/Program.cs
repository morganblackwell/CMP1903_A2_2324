using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Program
    {
        static void Main()
        {
            /*
             * Create a Game object and call its methods.
             * Create a Testing object to verify the output and operation of the other classes.
             */

            /// <summary>
            /// Infinitely creates game objects through the Testing class
            /// Allows the user to choose how many times the dice are rolled.
            /// </summary>

            while (true) // Runs continuously 
            {
                Console.WriteLine("How many times should three dice be rolled?");

                try
                {
                    int rollAmount = Int32.Parse(Console.ReadLine());

                    for (int rollCount = 1; rollCount <= rollAmount; rollCount++)
                    {
                        Testing testOutputs = new Testing();
                        testOutputs.Main();
                        Console.WriteLine(); // Seperate different sets of rolls
                    }
                }

                catch (FormatException) // Stops non integer values being accepted
                {
                    Console.WriteLine("Input must be an integer");
                    Main(); // Resets Program to allow the user to enter a valid input
                }

                catch (OverflowException) // Stops values too big or small being accepted
                {
                    Console.WriteLine("Input value too large/small");
                    Main();
                }

                catch (Exception exception) // Stop any other input errors
                {
                    Console.WriteLine($"Input error: {exception}");
                    Main();
                }
            }
        }
    }
}