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
        private int timesPlayed = 0;
        int threeHighScore = 0;
        private int sevensHighScore = 0;

        public void SetTimesPlayed()
        {
            timesPlayed++;
        }
        public int GetTimesPlayed()
        {
            return timesPlayed;
        }

        public void SetThreeHighScore(int score) // Updates ThreeOrMore high score
        {
            threeHighScore = score;
        }
        public int GetThreeHighScore()
        {
            return threeHighScore;
        }

        public void SetSevensHighScore(int score) // Updates SevensHighScore high score
        {
            sevensHighScore = score;
        }
        public int GetSevensHighScore()
        {
            return sevensHighScore;
        }

        public void OutputStatistics()
        {
            Console.WriteLine($"{GetTimesPlayed()},{GetThreeHighScore()},{GetSevensHighScore()}");
        }

    }
}
