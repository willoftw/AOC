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

        public int MultiplySummableValues(List<int> values, int targetSum)
        {
            int[] summableValues = GetSummableValues(values, targetSum);
            return summableValues[0] * summableValues[1];
        }
    }
}
