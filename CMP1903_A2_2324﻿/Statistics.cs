using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace CMP1903_A2_2324
{
    // Store game statistics for each game type (number of plays, high-scores, etc)

    internal class Statistics
    {
        // Number of plays
        private static int _sevensOutPlays = 0;
        public int SevensOutPlays
        {
            get { return _sevensOutPlays; }
            set { _sevensOutPlays = value; }
        }

        private static int _threeOrMorePlays = 0;
        public int ThreeOrMorePlays
        {
            get { return _threeOrMorePlays; }
            set { _threeOrMorePlays = value; }
        }


        // High Scores
        private static int _sevensOutHighScore = 0;
        public int SevensOutHighScore
        {
            get { return _sevensOutHighScore; }
            set { _sevensOutHighScore = value; }
        }

        private static int _threeOrMoreHighScore = 0;
        public int ThreeOrMoreHighScore
        {
            get { return _threeOrMoreHighScore; }
            set { _threeOrMoreHighScore = value; }
        }


        // Wins
        private static int _playerOneWins = 0;
        public int PlayerOneWins
        {
            get { return _playerOneWins; }
            set { _playerOneWins = value; }
        }

        private static int _playerTwoWins = 0;
        public int PlayerTwoWins
        {
            get { return _playerTwoWins; }
            set { _playerTwoWins = value; }
        }

        private static int _computerWins = 0;
        public int ComputerWins
        {
            get { return _computerWins; }
            set { _computerWins = value; }
        }


        private void OutputStatistics(string statisticChoice) // Static Polymorphism
        {
            if (statisticChoice == "p") // Plays
            {
                Console.WriteLine($"Number of plays\nSevens Out: {SevensOutPlays}\nThree Or More: {ThreeOrMorePlays}\n");
            }
            else if (statisticChoice == "s") // Scores
            {
                Console.WriteLine($"High Scores\nSevens Out: {SevensOutHighScore}\nThree Or More: {ThreeOrMoreHighScore}\n");
            }
            else if (statisticChoice == "w") // Wins
            {
                Console.WriteLine($"Wins\nPlayer One: {PlayerOneWins}\nPlayer Two: {PlayerTwoWins}\nComputer: {ComputerWins}\n");
            }
            else if (statisticChoice == "a") // All
            {
                Console.WriteLine($"Number of plays\nSevens Out: {SevensOutPlays}\nThree Or More: {ThreeOrMorePlays}\n");
                Console.WriteLine($"High Scores\nSevens Out: {SevensOutHighScore}\nThree Or More: {ThreeOrMoreHighScore}\n");
                Console.WriteLine($"Wins\nPlayer One: {PlayerOneWins}\nPlayer Two: {PlayerTwoWins}\nComputer: {ComputerWins}\n");
            }
            else if (statisticChoice == "r") ResetStatistics(); // Reset
            else if (statisticChoice == "b") return; // Back

            GetStatisticChoice(); // Return to statistic menu
        }

        // Uses LINQ to find output all statistics with user chosen value
        private void OutputStatistics(int value) // Static Polymorphism
        {
            Dictionary<string, int> statisticsDict = new Dictionary<string, int>()
            {
                {"Sevens Out Plays", SevensOutPlays },
                {"Three Or More Plays", ThreeOrMorePlays },
                {"Sevens Out High Score", SevensOutHighScore },
                {"Three Or More High Score", ThreeOrMoreHighScore },
                {"Player One Wins", PlayerOneWins },
                {"Player Two Wins", PlayerTwoWins },
                {"Computer Wins", ComputerWins }
            };

            var output = from val in statisticsDict
                         where val.Value == value
                         select val;

            foreach ( var val in output)
            {
                Console.WriteLine($"{val.Key}: {val.Value}");
            }

            Console.WriteLine();
        }

        public void GetStatisticChoice() // Gets a statistic option from user using a menu
        {
            Console.WriteLine("\nOutput number of plays(p), high scores(s), number of wins(w), all (a)\n");
            Console.WriteLine("Search for a statistic from value (value to search for)\n");
            Console.WriteLine("Reset Statistics (r)");
            Console.WriteLine("Go back to menu (b)");

            string statisticChoice = Console.ReadLine().ToLower();
            try
            {
                int value = int.Parse(statisticChoice);
                OutputStatistics(value);
            }
            catch (FormatException)
            {
                OutputStatistics(statisticChoice);
            }
        }
        
        private void ResetStatistics() // Sets all statistics to 0
        {
            SevensOutPlays = 0;
            ThreeOrMorePlays = 0;
            SevensOutHighScore = 0;
            ThreeOrMoreHighScore = 0;
            PlayerOneWins = 0;
            PlayerTwoWins = 0;
            ComputerWins = 0;
        }
    }
}
