using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Testing
    {
        /*
         * This class should test the Game and the Die class.
         * Create a Game object, call the methods and compare their output to expected output.
         * Create a Die object and call its method.
         * Use debug.assert() to make the comparisons and tests.
         */

        /// <summary>
        ///  The testing class rolls 3 dice through the Game class and checks if the following is true:
        ///  Every roll is between the values 1 and 6
        ///  The sum of rolls is between the values 3 and 18
        /// </summary>

        //Method
        public void Main()
        {
            Game testGame = new Game();
            var testOutputs = testGame.Main();

            int roll1 = testOutputs.Item1;
            int roll2 = testOutputs.Item2;
            int roll3 = testOutputs.Item3;
            int sum = testOutputs.Item4;

            // First dice testing
            Debug.Assert(roll1 <= 6, "First dice roll is greater than 6");
            Debug.Assert(roll1 >= 1, "First dice roll is less than 1");

            // Second dice testing
            Debug.Assert(roll2 <= 6, "Second dice roll is greater than 6");
            Debug.Assert(roll2 >= 1, "Second dice roll is less than 1");

            // Third dice testing
            Debug.Assert(roll3 <= 6, "Third dice roll is greater than 6");
            Debug.Assert(roll3 >= 1, "Third dice roll is less than 1");

            // Sum of dice testing
            Debug.Assert(sum <= 18, "Sum is greater than 18");
            Debug.Assert(sum >= 3, "Sum is less than 3");

        }
    }
}