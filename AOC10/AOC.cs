using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC10
{
    public class AOC : IDisposable
    {
        public void Dispose()
        { }

        public List<int> ProcessData(List<string> data)
        {
            return data.Select(int.Parse).ToList();
        }

        public int CalculateBuiltInVoltage(List<string> input)
        {
            List<int> data = ProcessData(input);
            return data.Max() + 3;
        }

        public int CaculateDiffs(List<string> input)
        {
            List<int> data = ProcessData(input);
            data.Sort();
            List<int> diffs = new List<int>() { 0, 1, 0, 1, 0, 0, 0 };
            for (int i = 0; i < data.Count; i++)
            {
                try
                {
                    int diff = data[i + 1] - data[i];
                    diffs[diff] += 1;
                }
                catch (Exception e)
                {
                    break;
                }
            }
            return diffs[1] * diffs[3];
        }

        public double CalculateConsecutiveDiffs(List<string> input)
        {
            List<int> data = ProcessData(input);
            data.Sort();
            List<int> diffs = new List<int>(){3,1};
            for (int i = 0; i < data.Count; i++)
            {
                try
                {
                    int diff = data[i + 1] - data[i];
                    diffs.Add(diff);
                }
                catch (Exception e)
                {
                    break;
                }
            }
           string stringdiffs = string.Join("",diffs);
           var four = stringdiffs.Split("1111");
           var three = string.Join("",four).Split("111");
           var two = string.Join("",three).Split("11");
           
           return Math.Pow(2,two.Length-1) * Math.Pow(4,three.Length-1) * Math.Pow(7,four.Length-1);
        }
    }
}