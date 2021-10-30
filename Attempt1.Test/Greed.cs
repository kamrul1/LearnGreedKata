using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attempt1.Test
{
    public class Greed
    {
        private const int TRIPLETIMES = 3;

        internal static int GetScore(int[] dices)
        {
            int no1s = CountNoTime(dices, 1);
            if (no1s >= TRIPLETIMES)
            {
                var score = 1000;
                score += (no1s - 3) * 100;
                return score;

            }
            if (no1s == 1)
            {
                return 100;
            }

            var no2s = CountNoTime(dices, 2);
            if (no2s >= TRIPLETIMES)
            {
                return 200;
            }



            var no3s = CountNoTime(dices, 3);
            if (no3s >= TRIPLETIMES)
            {
                return 300;
            }

            var no5s = CountNoTime(dices, 5);
            if (no5s == 1)
            {
                return 50;
            }
            if (no5s == 3)
            {
                return 500;
            }

            var no6s = CountNoTime(dices, 6);

            if (no6s >= TRIPLETIMES)
            {
                return 600;
            }



            return default;
        }

        private static int CountNoTime(int[] dices, int findNo)
        {
            return dices.Count(x => x == findNo);
        }
    }
}
