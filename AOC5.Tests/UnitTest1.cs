using System;
using Xunit;
using AOC5;

namespace AOC5.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldReturnCorrectSeat()
        {
            using(AOC aoc = new AOC())
            {
                //[44,5] == row 44 column 5
                int[] seat = new int[] {44,5};
                Assert.Equal(seat, aoc.Decode("FBFBBFFRLR"));
            }
        }
    }
}
