using System;
using System.Collections.Generic;
using System.Linq;

namespace AOC1
{
    public class AOC
    {
        public int[] GetSummableValues(List<int> values, int targetSum)
        {
            List<int> ret = new List<int>();
            values.ForEach(x => values.Contains(x-2020));
            var t = values.Where(val => values.Contains(targetSum - val)).Select(val => val).ToList();
            return t.ToArray();
        }


        //brute force
        public int[] GetThreeSummableValues(List<int> values, int targetSum)
        {
            foreach (int i in values)
            {
                foreach(int j in values)
                {
                    foreach (int k in values)
                    {
                        if ((i + j + k == targetSum))
                            return new int[] { i, j, k };
                    }
                }
            }
            return new int[] { 0, 0, 0 };
        }

        public int MultiplySummableValues(List<int> values, int targetSum)
        {
            int[] summableValues = GetSummableValues(values, targetSum);
            //int var = 1;
            //foreach (int i in summableValues)
            //    var *= i;

            return summableValues[0] * summableValues[1];
        }

        public int MultiplyThreeSummableValues(List<int> values, int targetSum)
        {
            int[] summableValues = GetThreeSummableValues(values, targetSum);
            //int var = 1;
            //foreach (int i in summableValues)
            //    var *= i;

            return summableValues[0] * summableValues[1] * summableValues[2];
        }
    }
}
