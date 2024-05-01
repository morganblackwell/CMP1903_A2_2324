using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Die
    {
        /// <summary>
        /// Sets currentValue to a randomly assigned 6 sided die.
        /// Utilises the Built-in 'Random' class to get a value between 1 and 6
        /// </summary>

        private int _currentValue; // Holds the value that is currently assigned to the die

        // Usage of a get and set method to reduce accessibility from outside of this class
        public int CurrentValue
        {
            get { return _currentValue; }
            set { _currentValue = value; }
        }

        private static Random _random = new Random(); // Using static stops duplicate values

        // Method
        public int Roll()
        {
            /// <returns> A random integer between 1 and 6

            CurrentValue = _random.Next(1, 7); // 1 to 7 where 7 is not included
            return CurrentValue;
        }
    }
}