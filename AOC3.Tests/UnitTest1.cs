using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using AOC3;

namespace AOC3.Tests
{
    public class UnitTest1
    {
        List<List<char>> input_1 = new List<List<char>>();
        List<List<char>> input_2 = new List<List<char>>();
        public UnitTest1()
        {
            StreamReader reader = File.OpenText("input_1.txt");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                input_1.Add(new List<char>(line.ToCharArray()));
            }
            reader.Close();

            reader = File.OpenText("input_2.txt");
            while ((line = reader.ReadLine()) != null)
            {
                input_2.Add(new List<char>(line.ToCharArray()));
            }
            reader.Close();
        }

        [Fact]
        public void ShouldCountTreeCorrectly()
        {
            using (AOC aoc = new AOC())
            {
                Assert.Equal(7, aoc.CountTrees(input_1,1,3));
            }

            using (AOC aoc = new AOC())
            {
                Assert.Equal(270, aoc.CountTrees(input_2,1,3));
            }
        }

        [Fact]
        public void ShouldCountAdditionalSlopesCorrectly()
        {
            using (AOC aoc = new AOC())
            {
                Assert.Equal(2, aoc.CountTrees(input_1,1,1));
            }

            using (AOC aoc = new AOC())
            {
                Assert.Equal(3, aoc.CountTrees(input_1,1,5));
            }

            using (AOC aoc = new AOC())
            {
                Assert.Equal(4, aoc.CountTrees(input_1,1,7));
            }

            using (AOC aoc = new AOC())
            {
                Assert.Equal(2, aoc.CountTrees(input_1,2,1));
            }

            using (AOC aoc = new AOC())
            {
                var answer = aoc.CountTrees(input_1,1,1) *
                             aoc.CountTrees(input_1,1,3) *
                             aoc.CountTrees(input_1,1,5) *
                             aoc.CountTrees(input_1,1,7) *
                             aoc.CountTrees(input_1,2,1);
                Assert.Equal(336, answer);
            }

            using (AOC aoc = new AOC())
            {
                var answer = aoc.CountTrees(input_2,1,1) *
                             aoc.CountTrees(input_2,1,3) *
                             aoc.CountTrees(input_2,1,5) *
                             aoc.CountTrees(input_2,1,7) *
                             aoc.CountTrees(input_2,2,1);
                Assert.Equal(2122848000, answer);
            }
        }
    }
}
