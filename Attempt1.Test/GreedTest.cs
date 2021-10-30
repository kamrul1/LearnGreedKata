using System;
using Xunit;

namespace Attempt1.Test
{
    public class GreedTest
    {
        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1, 1 }, 1300)]
        [InlineData(new[] { 1, 1, 0, 3, 1, 6 }, 1000)]
        [InlineData(new[] { 0, 1, 0, 3, 9, 6 }, 100)]

        [InlineData(new[] { 0, 2, 0, 2, 2, 6 }, 200)]
        [InlineData(new[] { 2, 2, 2, 2, 2, 2 }, 200)]

        [InlineData(new[] { 0, 3, 0, 3, 3, 6 }, 300)]
        [InlineData(new[] { 3, 3, 3, 3, 3, 3 }, 300)]

        [InlineData(new[] { 0, 0, 5, 3, 9, 6 }, 50)]
        [InlineData(new[] { 0, 0, 5, 5, 5, 6 }, 500)]

        [InlineData(new[] { 6, 6, 6, 2, 2, 0 }, 600)]
        [InlineData(new[] { 6, 6, 6, 6, 6, 6 }, 600)]
        public void ShouldReturnSingleOrTripleScore(
            int[] dices, int expectedScore)
        {
            var result = Greed.GetScore(dices);

            Assert.Equal(expectedScore, result);
        }


    }
}
