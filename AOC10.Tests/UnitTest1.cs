using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AOC10.Tests
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            AOC aoc = new AOC();
        }

        [Fact]
        public void ShouldProcessData()
        {
            List<string> input = ParseInput("data.txt");
            List<int> check = new List<int>(){16,10,15,5,1,11,7,19,6,12,4};
            using(AOC aoc = new AOC())
            {
                Assert.Equal(check,aoc.ProcessData(input));
            }
            
        }


        public List<string> ParseInput(string filename)
        {
            List<string> ret = new List<string>();
            StreamReader reader = File.OpenText(filename);
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
                ret.Add(line);
            }
            reader.Close();

            return ret;
        }

        [Theory]
        [InlineData("data.txt",22)]
        [InlineData("data_2.txt",52)]
        public void ShouldCalculateVoltage(string filename, int expect)
        {
            List<string> input = ParseInput(filename);
            using(AOC aoc = new AOC())
            {
                Assert.Equal(expect,aoc.CalculateBuiltInVoltage(input));
            }
            
        }

        [Theory]
        [InlineData("data.txt",35)]
        [InlineData("data_3.txt",2176)]
        public void ShouldCalculateCorrectDiffs(string filename, int expect)
        {
            List<string> input = ParseInput(filename);
            
            using(AOC aoc = new AOC())
            {
                Assert.Equal(expect,aoc.CaculateDiffs(input));
            }
            
        }

        [Theory]
        [InlineData("data.txt",8)]
        [InlineData("data_2.txt",19208)]
        [InlineData("data_3.txt",18512297918464)]
        //its not 10578455953408;
        public void ShouldCalculateCorrectConsectutiveDiffs(string filename, int expect)
        {
            List<string> input = ParseInput(filename);
            
            using(AOC aoc = new AOC())
            {
                var ans = aoc.CalculateConsecutiveDiffs(input);
                Assert.Equal(expect,aoc.CalculateConsecutiveDiffs(input));
            }
            
        }


    }
}
