using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;
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

        //1024 possiblities
        [Fact]
        public void ShouldCalculateHighestSeatID()
        {
            AOC aoc = new AOC();
            
            foreach(string s in input)
            {
                seatids.Add(aoc.Decode(s)[2]);
            }
            Assert.Equal(926, seatids.Max());

            //used this txtfile to sort the missing value.
            // using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./WriteLines2.txt"))
            // {
            //     foreach (int line in seatids)
            //     {
            //             file.WriteLine(""+line);
                
            //     }
            // }
            
        }

        //657
        [Fact]
        public void ShouldFindMissingSeatNumber()
        {
            using(AOC aoc = new AOC())
            {
                foreach(string s in input)
                {
                    seatids.Add(aoc.Decode(s)[2]);
                }
                var ascendingOrder = seatids.OrderBy(i => i);
                int count = 80; // 80 being the lowest id possible
                foreach(var value in ascendingOrder)
                {
                    if(count!=value)
                    {
                        //Console.WriteLine($"Found missing {count}");
                        break;
                    }
                    count++;
                }
                Assert.Equal(657,count);
            }
        }
    }
}
