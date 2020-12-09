using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC9
{
    public class AOC : IDisposable
    {
        public void Dispose()
        {}

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
        public double GetNotSummableValue(List<double> data,int preamble)
        {
            double num =0;
            for(int i = preamble; i<data.Count ; i++)
            {
                num = data[i];
                List<double> preamblelist = data.Skip(i-preamble).Take(preamble).ToList();
                bool containsSummable = false;
                foreach(var val in preamblelist)
                {
                    double targetValue = num - val;
                    if(preamblelist.Contains(targetValue)){
                        containsSummable=true;
                        break;
                    }
                }
                if (!containsSummable)
                    return num;
            }
            return num;
        }
        
    }
}
