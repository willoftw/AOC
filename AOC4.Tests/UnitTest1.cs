using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using AOC4;
using System.Linq;

namespace AOC4.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void FirstTestPassportShouldBeFilledAndValid()
        {
            using (AOC aoc = new AOC("batchfile_1.txt"))
            {
                Assert.True(aoc.passports[0].isFullyPopulated());

                Assert.False(aoc.passports[5].isFullyPopulated());
            }
        }

        [Fact]
        public void ShouldCountValidPassports()
        {
            using (AOC aoc = new AOC("batchfile_1.txt"))
            {
                Assert.Equal(4, aoc.validPassports);
            }

            using (AOC aoc = new AOC("batchfile_2.txt"))
            {
                Assert.Equal(101, aoc.validPassports);
            }


        }
    }
}
