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
        private static readonly int[] diceRollsWithTripleAndSingleScore = new int[] { 1, 5 };
        private static readonly int[] diceRollWithTripleScoresOnly = new int[] { 2, 3, 6 };

        internal static int GetScore(int[] dices)
        {
            int score = 0;

            foreach (var diceRollWithTripleAndSingleScores in diceRollsWithTripleAndSingleScore)
            {
                score = ScoreOnesOrFives(dices, score, diceRollWithTripleAndSingleScores);
            }


            foreach (var diceRollWithTripleScoresOnly in diceRollWithTripleScoresOnly)
            {
                score = ScoreTripleDiceRolls(dices, score, diceRollWithTripleScoresOnly);
            }


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
