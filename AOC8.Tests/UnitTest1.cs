using System.Reflection;
using System;
using Xunit;
using AOC8;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace AOC8.Tests
{
    public class UnitTest1
    {
        List<string> input = new List<string>();
        List<string> input_2 = new List<string>();
        public UnitTest1()
        {
            input = ParseInput("data.txt");
            input_2 = ParseInput("data_2.txt");
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

        [Fact]
        public void ShouldParseDataCorrectly()
        {
            Assert.Equal(9,input.Count());
        }

        [Fact]
        public void ShouldProcessDataCorrectly()
        {
            using (AOC aoc = new AOC())
            {
                var output = aoc.ProcessData(input);
                Assert.Equal(9,output.Count());

                Assert.Equal(output[3],new Tuple<int,string, int>(0,"acc",3));
            }
        }

        [Fact]
        public void ShouldReturnCorrectAccumulator()
        {
            using (AOC aoc = new AOC())
            {
                var data = aoc.ProcessData(input);
                int accumulator = aoc.ExecuteInstructions(data);
                Assert.Equal(5,accumulator);
            }
        }

        [Fact]
        public void ShouldReturnCorrectAccumulatorForSecondDataSet()
        {
            using (AOC aoc = new AOC())
            {
                var data = aoc.ProcessData(input_2);
                int accumulator = aoc.ExecuteInstructions(data);
                Assert.Equal(5,accumulator);
                //its not 98
            }
        }
    }
}
