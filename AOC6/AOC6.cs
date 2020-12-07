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
                var subanswer = answer.Substring(1);
                ret.Add(subanswer.Distinct().Count());
            }
            return ret;

        }

        public List<int> CountDuplicateAnswers(List<string> answers)
        {
            List<int> ret = new List<int>();
            foreach (var answer in answers)
            {
                var subanswer = answer.Substring(1);
                int groupcount = int.Parse(answer[0].ToString());

                var duplicateCount = subanswer.GroupBy(c => c).Select(c => new { Char = c.Key, Count = c.Count()});
                if (duplicateCount.Count()!=0 && duplicateCount != null)
                    {
                        int groupAnswers = 0;
                        foreach(var count in duplicateCount)
                        {
                            if(count.Count == groupcount)
                                groupAnswers++;
                        }
                        ret.Add(groupAnswers);
                    }
                ret.Add(subanswer.Distinct().Count());
            }


            return ret;

        }
    }
}
