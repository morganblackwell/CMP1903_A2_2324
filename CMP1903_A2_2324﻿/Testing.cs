using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    /* Use debug.assert() to verify:
        Sevens Out: Total of sum, stop if total = 7
        Three Or More: Scores set and added correctly, recognise when total >= 20.
    */

    internal class Testing
    {
        private static bool _isTest = false; // Static stops isTest from returning to false on instantiation
        public bool isTest // Boolean to decide if game is in testing mode
        {
            get { return _isTest; }
            set { _isTest = value; }
        }
        public void TestDice()
        {
            Die testDie = new Die();

            Console.WriteLine("Testing Dice\n");
            Console.WriteLine("Number of rolls to test");
            int numberOfDice = int.Parse(Console.ReadLine());

            for (int die = 0; die < numberOfDice; die++)
            {
                int roll = testDie.Roll();
                
                Debug.Assert(roll >= 1, "Roll is less than 1");
                Debug.Assert(roll <= 6, "Roll is greater than 6");
            }
        }

        public void TestSevensOut()
        {
            SevensOut testSevensOut = new SevensOut();
            testSevensOut.Main();
        }

        public void TestThreeOrMore()
        {
            ThreeOrMore testThreeOrMore = new ThreeOrMore();
        }

        public void TestAll()
        {
            TestDice();
            TestSevensOut();
            TestThreeOrMore();
        }

    }
}