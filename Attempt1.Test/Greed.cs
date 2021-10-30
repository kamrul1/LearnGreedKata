using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1.Test
{
    public class Greed
    {
        private const int TRIPLE_APPEARANCE = 3;
        private const int ONE_APPEARANCE = 1;
        private const int TRIPLE_SCORE_MULTIPLER = 100;


        internal static int GetScore(int[] dices)
        {
            int score = 0;

            score = ScoreOnesOrFives(dices, score,1);
            score = ScoreOnesOrFives(dices, score,5);

            score = ScoreTripleDiceRolls(dices, score, 2);
            score = ScoreTripleDiceRolls(dices, score, 3);
            score = ScoreTripleDiceRolls(dices, score, 6);

            return score;

        }
        private static int ScoreTripleDiceRolls(int[] dices, int score, int diceRoll)
        {
            var noDiceRolls = CountNoTime(dices, diceRoll);
            if (noDiceRolls >= TRIPLE_APPEARANCE)
            {
                score += diceRoll * TRIPLE_SCORE_MULTIPLER;

            }

            return score;
        }


        private static int ScoreOnesOrFives(int[] dices, int score, int diceRoll)
        {
            var noDiceRolls = CountNoTime(dices, diceRoll);

            var diceRollSingleScoreMultiplier = diceRoll == 1 ? 100 : 50;
            var diceRollMultiplier = diceRoll == 1 ? 10 : 5;


            if (noDiceRolls == ONE_APPEARANCE)
            {
                score += diceRollSingleScoreMultiplier;
            }

            if (noDiceRolls >= TRIPLE_APPEARANCE)
            {
                score += diceRollMultiplier* TRIPLE_SCORE_MULTIPLER;
                score += (noDiceRolls - TRIPLE_APPEARANCE) * diceRollSingleScoreMultiplier;
            }

            return score;
        }



        private static int CountNoTime(int[] dices, int findNo)
        {
            return dices.Count(x => x == findNo);
        }
    }
}
