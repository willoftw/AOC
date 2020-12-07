using System;
using Xunit;
using AOC6;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AOC6.Tests
{
    public class UnitTest1
    {
        public List<string> input = new List<string>();
        public List<string> input_2 = new List<string>();
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
            string group = "";
            int groupCount = 0;
            while ((line = reader.ReadLine()) != null)
            {
                group+=line.TrimEnd( '\r', '\n' );
                if (String.IsNullOrWhiteSpace(line)){
                    ret.Add($"{groupCount}{group}");
                    group = "";
                    groupCount = 0;
                }
                else
                    groupCount++;
                
            }
            ret.Add($"{groupCount}{group}");
            reader.Close();

            return ret;
        }

        [Fact]
        public void ShouldCountDistinctsCorrectlyForData()
        {
            using (AOC aoc = new AOC())
            {
                List<int> expected = new List<int>(){3,3,3,1,1};
                Assert.Equal(expected,aoc.CountDistinctAnswers(input));
            }
        }

        [Fact]
        public void ShouldAddAllDistinctValuesCorrectly()
        {
            using (AOC aoc = new AOC())
            {
                List<int> distinctAnswers = aoc.CountDistinctAnswers(input_2);
                //int ans = distinctAnswers.Aggregate(1, (x,y) => x * y);
                int prod = 0;
                foreach (int value in distinctAnswers)
                {
                    if (value == 0)
                        continue;
                    prod += value;
                }
                Assert.Equal(7128,prod);
            }
        }

        [Fact]
        public void ShouldAddAllDuplicateValuesCorrectly()
        {
            using (AOC aoc = new AOC())
            {
                List<int> distinctAnswers = aoc.CountDuplicateAnswers(input_2);
                //int ans = distinctAnswers.Aggregate(1, (x,y) => x * y);
                int prod = 0;
                foreach (int value in distinctAnswers)
                {
                    if (value == 0)
                        continue;
                    prod += value;
                }
                Assert.Equal(7128,prod);
            }
        }
    }
}
