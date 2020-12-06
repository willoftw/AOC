using System;
using Xunit;
using AOC5;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AOC5.Tests
{
    public class UnitTest1
    {
        List<string> input = new List<string>();
        List<int> seatids = new List<int>();
        public UnitTest1()
        {
              StreamReader reader = File.OpenText("data.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input.Add(line);
            }
            reader.Close();
        }
        //dotnet test --filter "AOC5.Tests.UnitTest1"
        [Fact]
        public void ShouldReturnCorrectSeatFBFBBFFRLR()
        {
            using(AOC aoc = new AOC())
            {
                //[44,5] == row 44 column 5
                int[] seat = new int[] {44,5,357};
                Assert.Equal(seat, aoc.Decode("FBFBBFFRLR"));
            }
        }

        [Fact]
        public void ShouldReturnCorrectSeatBFFFBBFRRR()
        {
            using(AOC aoc = new AOC())
            {
                //[44,5] == row 44 column 5
                int[] seat = new int[] {70,7,567};
                Assert.Equal(seat, aoc.Decode("BFFFBBFRRR"));
            }
        }

        [Fact]
        public void ShouldReturnCorrectSeatFFFBBBFRRR()
        {
            using(AOC aoc = new AOC())
            {
                //[44,5] == row 44 column 5
                int[] seat = new int[] {14,7,119};
                Assert.Equal(seat, aoc.Decode("FFFBBBFRRR"));
            }
        }

        [Fact]
        public void ShouldReturnCorrectSeatBBFFBBFRLL()
        {
            using(AOC aoc = new AOC())
            {
                //[44,5] == row 44 column 5
                int[] seat = new int[] {102,4,820};
                Assert.Equal(seat, aoc.Decode("BBFFBBFRLL"));
            }
        }

        [Fact]
        public void ShouldCalculateHighestSeatID()
        {
            AOC aoc = new AOC();
            
            foreach(string s in input)
            {
                seatids.Add(aoc.Decode(s)[2]);
            }
            Assert.Equal(926, seatids.Max());
            
        }
    }
}
