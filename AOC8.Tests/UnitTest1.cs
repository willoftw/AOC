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

        [Theory]
        [InlineData("data.txt", 9)]
        [InlineData("data_2.txt",660)]
        [InlineData("data_3.txt",9)]
        public void ShouldParseDataCorrectly(string datafile, int result)
        {
            List<string> input = ParseInput(datafile);
            Assert.Equal(result,input.Count());
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

        [Theory]
        [InlineData("data.txt", false)]
        [InlineData("data_2.txt",false)]
        [InlineData("data_3.txt",true)]
        public void ShouldValidateDataCorrectly(string datafile, bool result)
        {
            List<string> input = ParseInput(datafile);
            using (AOC aoc = new AOC())
            {
                var data = aoc.ProcessData(input);
                Assert.Equal(result,aoc.ValidateInstructions(data));
            }
        }

        [Fact]
        public void ShouldReturnCorrectAccumulatorForSecondDataSet()
        {
            using (AOC aoc = new AOC())
            {
                var data = aoc.ProcessData(input_2);
                int accumulator = aoc.ExecuteInstructions(data);
                Assert.Equal(1915,accumulator);
                //its not 98
            }
        }

        [Fact]
        public void ShouldFindValidInstructionSet()
        {
            using (AOC aoc = new AOC())
            {
                var data = aoc.ProcessData(input);
                var validInstructions = aoc.FindValidInstructionSet(data);
                Assert.Equal(true,aoc.ValidateInstructions(validInstructions));
                int accumulator = aoc.ExecuteInstructions(validInstructions);
                Assert.Equal(8,accumulator);
            }
        }

        [Fact]
        public void ShouldFindValidInstructionSetForSecondDataSet()
        {
            using (AOC aoc = new AOC())
            {
                var data = aoc.ProcessData(input_2);
                var validInstructions = aoc.FindValidInstructionSet(data);
                Assert.Equal(true,aoc.ValidateInstructions(validInstructions));
                int accumulator = aoc.ExecuteInstructions(validInstructions);
                Assert.Equal(944,accumulator);
            }
        }
    }
}
