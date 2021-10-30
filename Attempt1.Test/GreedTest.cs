using System;
using Xunit;

namespace Attempt1.Test
{
    public class GreedTest
    {
        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1 }, 1200)]
        [InlineData(new[] { 1, 1, 0, 3, 1 }, 1000)]
        [InlineData(new[] { 0, 1, 0, 3, 9 }, 100)]

        [InlineData(new[] { 0, 2, 0, 2, 2}, 200)]

        [InlineData(new[] { 0, 3, 0, 3, 3}, 300)]

        [InlineData(new[] { 0, 0, 5, 3, 9}, 50)]
        [InlineData(new[] { 0, 0, 5, 5, 5}, 500)]

        [InlineData(new[] { 6, 6, 6, 2, 2 }, 600)]
        public void ShouldReturnSingleOrTripleScore(
            int[] dices, int expectedScore)
        {
            var result = Greed.GetScore(dices);

            Assert.Equal(expectedScore, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 5, 1 }, 1150)]
        [InlineData(new int[] { 2, 3, 4, 6, 2 }, 0)]
        [InlineData(new int[] { 3, 4, 5, 3, 3 }, 350)]
        [InlineData(new int[] { 5, 5, 5, 5, 3 }, 550)]
        public void ShouldReturnSumOfCombi(
            int[] dices, int expectedScore)
        {
            var result = Greed.GetScore(dices);

            Assert.Equal(expectedScore, result);

        }

        [Theory]
        [InlineData(new int[] {1}, 100)]
        [InlineData(new int[] {1,2,3,4,5,2}, 150)]
        public void ShouldReturnScoreFor1to6DiceThrown(
            int[] dices, int expectedScore)
        {
            var result = Greed.GetScore(dices);

            Assert.Equal(expectedScore, result);

        }

        [Theory]
        [InlineData(new int[] { 2, 2, 2, 2 }, 400)]
        [InlineData(new int[] { 2, 2, 2, 2, 2 }, 800)]
        [InlineData(new int[] { 2, 2, 2, 2, 2, 2 }, 1600)]
        public void ShouldReturnScoredByMultiplierForKind(
                        int[] dices, int expectedScore)
        {
            var result = Greed.GetScore(dices);

            Assert.Equal(expectedScore, result);
        }

        [Fact]
        public void ShouldReturnScoreThreePairs()
        {
            var dices = new int[] { 2, 2, 3, 3, 4, 4 };

            var result = Greed.GetScore(dices);

            Assert.Equal(800, result);
        }


        [Fact]
        public void ShouldReturnScoreForStraight()
        {
            var dices = new int[] { 1, 2, 3, 4, 5, 6 };

            var result = Greed.GetScore(dices);

            Assert.Equal(1200, result);
        }



    }
}
