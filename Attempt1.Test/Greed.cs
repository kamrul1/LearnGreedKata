using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1.Test
{
    public class Greed
    {

        private const int ONE_APPEARANCE = 1;
        private const int TRIPLE_APPEARANCE = 3;
        private const int QUAD_APPERANCE = 4;

        private const int TRIPLE_SCORE_MULTIPLER = 100;
        private const int QUAD_SCORE_MULTPLIER = 200;
        private const int FIFTH_APPEARANCE = 5;
        private const int FIFTH_SCORE_MULTPLIER = 400;
        private const int SIXTH_APPEARANCE = 6;
        private const int SIXTH_SCORE_MULTIPLIER = 800;
        private static readonly int[] diceRollsWithTripleAndSingleScore = new int[] { 1, 5 };
        private static readonly int[] diceRollWithTripleScoresOnly = new int[] { 2, 3, 6 };

        internal static int GetScore(int[] dices)
        {
            int score = 0;

            var is3Pairs = dices.GroupBy(x => x)
                                .Count(g => g.Count() == 2) == 3;
            if (is3Pairs)
            {
                return 800;
            }

            var numbers1To10 = Enumerable.Range(1, 6);

            if (dices.SequenceEqual(numbers1To10))
            {
                return 1200;
            }


            foreach (var diceRollWithTripleAndSingleScores in diceRollsWithTripleAndSingleScore)
            {
                score = ScoreOnesOrFives(dices, score, diceRollWithTripleAndSingleScores);
            }


            foreach (var diceRollWithTripleScoresOnly in diceRollWithTripleScoresOnly)
            {
                score = ScoreMuliplierByNoAppearances(dices, score, diceRollWithTripleScoresOnly);
            }

                   



            return score;

        }
        private static int ScoreMuliplierByNoAppearances(int[] dices, int score, int diceRoll)
        {
            var countSameNoAppearance = CountNoTime(dices, diceRoll);
            if (countSameNoAppearance == TRIPLE_APPEARANCE)
            {
                score += diceRoll * TRIPLE_SCORE_MULTIPLER;

            }
            if (countSameNoAppearance == QUAD_APPERANCE)
            {
                score += diceRoll * QUAD_SCORE_MULTPLIER;
            }
            if (countSameNoAppearance == FIFTH_APPEARANCE)
            {
                score += diceRoll * FIFTH_SCORE_MULTPLIER;
            }
            if (countSameNoAppearance == SIXTH_APPEARANCE)
            {
                score += diceRoll * SIXTH_SCORE_MULTIPLIER;
            }

            return score;
        }


        private static int ScoreOnesOrFives(int[] dices, int score, int diceRoll)
        {
            var noDiceRolls = CountNoTime(dices, diceRoll);

            var diceRollSingleScoreMultiplier = GetDiceRollSingleScoreMultiplierFor1or5(diceRoll);
            int diceRollMultiplier = GetDiceRollMultiplerFor1or5(diceRoll);

            if (noDiceRolls == ONE_APPEARANCE)
            {
                score += diceRollSingleScoreMultiplier;
            }

            if (noDiceRolls >= TRIPLE_APPEARANCE)
            {
                score += diceRollMultiplier * TRIPLE_SCORE_MULTIPLER;
                score += (noDiceRolls - TRIPLE_APPEARANCE) * diceRollSingleScoreMultiplier;
            }



            return score;
        }

        private static int GetDiceRollMultiplerFor1or5(int diceRoll)
        {
            return (diceRoll == 1 ? 10 : 5);
        }

        private static int GetDiceRollSingleScoreMultiplierFor1or5(int diceRoll)
        {
            return diceRoll == 1 ? 100 : 50;
        }

        private static int CountNoTime(int[] dices, int findNo)
        {
            return dices.Count(x => x == findNo);
        }
    }
}
