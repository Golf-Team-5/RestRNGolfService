using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestRNGolfService.Model
{
    public static class ScoreCalculator
    {
        /// <summary>
        /// This static property holds the player's score for the current game.
        /// </summary>
        public static int Score { get; set; }

        /// <summary>
        /// This static property holds the number of swings the player has in the current course. 
        /// </summary>
        public static int NoOfSwings { get; set; }


        /// <summary>
        /// This method calculates the score of a course using number of swings and the set par value.
        /// It also prevents subtracting points from the score. 
        /// </summary>
        /// <param name="par"></param>
        /// <returns></returns>
        public static int CalculateScore(int par, int hits)
        {
            if (hits == 1)
            {
                return Score += 2000;
            }
            if (hits <= par)
            {
                return Score += 1000;
            }
            if (hits <= 10 && hits > par)
            {
                return Score += 1000 - (100 * hits);
            }
            return Score += 0;
            
            
        }
    }
}
