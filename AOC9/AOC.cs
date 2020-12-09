using System.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC9
{
    public class AOC : IDisposable
    {
        public void Dispose()
        { }

        public List<double> ProcessData(List<string> data)
        {
            return data.Select(double.Parse).ToList();
        }

        /// <summary>
        /// Get the first number that is not the sum of the two numbers before it
        /// </summary>
        /// <param name="data">List if ints to be proccessed</param>
        /// <param name="preamble">how many values previously to check</param>
        /// <returns></returns>
        public double GetNotSummableValue(List<double> data, int preamble, bool contigious = false)
        {
            double num = 0;
            for (int i = preamble; i < data.Count; i++)
            {
                num = data[i];
                List<double> preamblelist = data.Skip(i - preamble).Take(preamble).ToList();
                bool containsSummable = false;
                foreach (var val in preamblelist)
                {
                    double targetValue = num - val;
                    if (targetValue != num&&preamblelist.Contains(targetValue))
                    {
                        containsSummable = true;
                        break;
                    }
                }
                if (!containsSummable && !contigious)
                    return num;
                else if (!containsSummable && contigious)
                {
                    data.Remove(num);
                    var range = arraySum(data.ToArray(),data.Count,num);
                    if (range!=null)
                    {
                        List<double> sumrange = data.Skip(range.Item1+1).Take((range.Item2-range.Item1)).ToList();
                        double sum = sumrange.Sum();
                        var ret = sumrange.Max() + sumrange.Min();
                        return ret;
                    }
                }
            }
            return num;

        }


        Tuple<int,int> arraySum(double[] arr, double n, double sum)
        {
            double curr_sum=0;
            int i,j;
            for (i = 0; i < n; i++)
            {
                curr_sum = 0;
                for (j = i + 1; j <= n; j++)
                {
                    if (curr_sum == sum)
                    {
                        int p = j - 1;
                        return new Tuple<int, int>(i,p);
                    }
                    if (curr_sum > sum || j == n)
                        break;
                    curr_sum = curr_sum + arr[j];
                }
            }
            return null;
        }
    }
}
