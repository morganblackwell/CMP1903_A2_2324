using System;
using System.Collections.Generic;
using System.Linq;
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

        public void OutputStatistics() // Outputs all statistics to console 
        {
            Console.WriteLine($"Number of plays\nSevens Out: {SevensOutPlays}\nThree Or More: {ThreeOrMorePlays}\n");
            Console.WriteLine($"High Scores\nSevens Out: {SevensOutHighScore}\nThree Or More: {ThreeOrMoreHighScore}\n");
            Console.WriteLine($"Wins\nPlayer One: {PlayerOneWins}\nPlayer Two: {PlayerTwoWins}\nComputer: {ComputerWins}\n");

            Console.WriteLine("Reset statistics? (y/n)");
            string resetChoice = Console.ReadLine().ToLower();
            if (resetChoice == "y") ResetStatistics();
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
