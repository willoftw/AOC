using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AOC9.Tests
{
    public class UnitTest1
    {
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
        [InlineData("data.txt", 20)]
        //[InlineData("data_2.txt",660)]
        public void ShouldParseDataCorrectly(string datafile, int result)
        {
            List<string> input = ParseInput(datafile);
            Assert.Equal(result,input.Count);
        }

        [Theory]
        [InlineData("data.txt", 20)]
        //[InlineData("data_2.txt",660)]
        public void ShouldProcessDataCorrectly(string datafile, int result)
        {
            using (AOC aoc = new AOC())
            {
                List<string> input = ParseInput(datafile);
                List<double> data = aoc.ProcessData(input);
                Assert.Equal(result,data.Count);
            }
        }

        [Theory]
        [InlineData("data.txt", 5,127)]
        [InlineData("data_2.txt", 25,556543474)]
        //[InlineData("data_2.txt",660)]
        public void ShouldGetNotSummableValueCorrectly(string datafile, int preamble, int result)
        {
            using (AOC aoc = new AOC())
            {
                List<string> input = ParseInput(datafile);
                List<double> data = aoc.ProcessData(input);
                Assert.Equal(result,aoc.GetNotSummableValue(data,preamble));
            }
        }

        [Theory]
        [InlineData("data.txt", 5,62)]
        [InlineData("data_2.txt", 25,76096372)]
        //its not 135541730127163
        //its not 135541730225161 either;
        //its not 180648334137911 all too high
        //its not 125113350
        public void ShoulCalculateContigiousCorrectly(string datafile, int preamble, int result)
        {
            using (AOC aoc = new AOC())
            {
                List<string> input = ParseInput(datafile);
                List<double> data = aoc.ProcessData(input);
                Assert.Equal(result,aoc.GetNotSummableValue(data,preamble,true));
            }
        }
    }
}