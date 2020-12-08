using System.Runtime.InteropServices;
using System;

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC7
{
    public class AOC : IDisposable
    {
        Dictionary<string,List<Bag>> bagMap = new Dictionary<string, List<Bag>>();
        int recursion_depth=10;
 
        public AOC(List<string> input)
        {
            bagMap = ParseBags(input);
        }

        public void Dispose()
        {
            
        }

        public int LetsTryThis()
        {
           return bagMap.Count;
        }

        public Dictionary<string,List<Bag>> ParseBags(List<string> input)
        {
            Dictionary<string,List<Bag>> bags = new Dictionary<string, List<Bag>>();
            foreach (var rule in input)
            {
                var split = rule.Split(" ");

                var pattern = @"([0-9]) ([\w\s]+ )";
                var matches = Regex.Matches(rule, pattern);
                List<Bag> bagrules= new List<Bag>();
                foreach (Match m in matches)
                {
                    Bag br = new Bag();
                    br.BagType = m.Groups[2].Value.TrimEnd();
                    br.BagCount = int.Parse(m.Groups[1].Value.TrimEnd());
                    bagrules.Add(br);
                }
                bags.Add($"{split[0]} {split[1]}",bagrules);
            }
            return bags;
        }
    }
    public class Bag
    {
        public string BagType {get; set;}
        public int BagCount{get; set;}
    }
}