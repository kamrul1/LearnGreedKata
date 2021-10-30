using System;
using Xunit;

namespace Attempt1.Test
{
    public class GreedTest
    {
        [Fact]
        public void ShouldReturn100MultipleForEachOne()
        {
            var expected =2000;
            var result = Greed.GetScore(new[] { 1, 1, 1, 1, 1, 1 });

            Assert.Equal(expected, result);
        }
    }
}
