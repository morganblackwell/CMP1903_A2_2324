﻿using System;
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
        public bool IsTest // Boolean to decide if game is in testing mode
        {
            get { return _isTest; }
            set { _isTest = value; }
        }

        public List<string> tested = new List<string>();
        public void TestDice()
        {
            Die testDie = new Die();

            Console.WriteLine("Testing Dice\n");
            Console.WriteLine("Number of rolls to test");
            int numberOfDice = int.Parse(Console.ReadLine());

            for (int die = 0; die < numberOfDice; die++)
            {
                int roll = testDie.Roll();
                
                Debug.Assert(roll >= 1, $"Roll is less than 1 ({roll})");
                Debug.Assert(roll <= 6, $"Roll is greater than 6 ({roll})");
            }

            tested.Add("Dice Rolls");
        }

        public void TestSevensOut()
        {
            SevensOut testSevensOut = new SevensOut();
            testSevensOut.Main();
            tested.Add("Sevens Out");
        }

        public void TestThreeOrMore()
        {
            ThreeOrMore testThreeOrMore = new ThreeOrMore();
            testThreeOrMore.Main();
            tested.Add("Three Or More");
        }

        public void TestAll()
        {
            TestDice();
            TestSevensOut();
            TestThreeOrMore();
        }
    }
}