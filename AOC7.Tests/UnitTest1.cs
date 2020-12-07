using System;
using Xunit;
using AOC7;
using System.IO;
using System.Collections.Generic;
using System.Linq;


namespace AOC7.Tests
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
        public void ShouldReturnCorrectAmmountOfValidBags()
        {
            using (AOC aoc = new AOC())
            {
                int result = aoc.LetsTryThis(input);
                Assert.Equal(4, result);

            }
        }

        [Fact]
        public void ShouldReturnCorrectAmmountOfValidBagsForFullDataset()
        {
            using (AOC aoc = new AOC())
            {
                int result = aoc.LetsTryThis(input_2);
                //Console.WriteLine(result);
                Assert.Equal(248, result);

            }
        }
    }
}
