using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC6
{
    public class AOC : IDisposable
    {
        public void Dispose()
        {
            
        }


        public List<int> CountDistinctAnswers(List<string> answers)
        {
            List<int> ret = new List<int>();
            foreach (var answer in answers)
            {
                ret.Add(answer.Distinct().Count());
            }
            return ret;

        }
    }
}
