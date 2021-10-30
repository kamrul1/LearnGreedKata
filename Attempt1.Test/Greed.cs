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

            score = ScoreDices1s(dices, score);
            score = ScoreDices5s(dices, score);

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

        private static int ScoreDices1s(int[] dices, int score)
        {
            int no1s = CountNoTime(dices, 1);
            if (no1s == ONE_APPEARANCE)
            {
                score += 100;
            }
            if (no1s >= TRIPLE_APPEARANCE)
            {
                score = 1000;
                score += (no1s - 3) * 100;

            }

            return score;
        }




        private static int ScoreDices5s(int[] dices, int score)
        {
            var no5s = CountNoTime(dices, 5);
            if (no5s == ONE_APPEARANCE)
            {
                score += 50;

            }
            if (no5s >= TRIPLE_APPEARANCE)
            {
                score += 5 * 100;
                score += (no5s - 3) * 50;
            }

            return score;
        }



        private static int CountNoTime(int[] dices, int findNo)
        {
            return dices.Count(x => x == findNo);
        }
    }
}
