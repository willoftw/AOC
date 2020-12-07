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
        List<string> ignorableBagTypes = new List<string>();
        List<string> baseBagBearers = new List<string>(); // bags that can directly hold shiny gold

        int recursion_depth=10;
 
        public void Dispose()
        {
            
        }
        //   0    1   2     3     4    5    6     7   8   9     10    11
        // light red bags contain 1 bright white bag, 2 muted yellow bags.
        // dark orange bags contain 3 bright white bags, 4 muted yellow bags.  
        // faded blue bags contain no other bags.
        public int CountBagColorsThatContainShiny(List<string> input)
        {
            List<Bag> bags = ParseBags(input);
            return bags.Count;
        }

        public List<Bag> GetValidBagRules(List<string> input)
        {
            List<Bag> bags = ParseBags(input);
            var validRules = bags.Where(s => !ignorableBagTypes.Contains(s.BagType)).ToList();
            return validRules;
        }

        public int LetsTryThis(List<string> input)
        {
            List<Bag> bags = GetValidBagRules(input);
            ParseBagsAgain(input,baseBagBearers);

            // foreach(var bag in bags)
            // {
            //     if (bag.CanContainBag("shiny gold",baseBagBearers))
            //         baseBagBearers.Add(bag.BagType);
            // }
            
            return baseBagBearers.Distinct().Count();
        }


        public int GetBagsThatCanContainBag(string bagName, List<string> input)
        {
            List<Bag> bags = GetValidBagRules(input);
            int validbagcount = 0;
            
            foreach(var bag in bags)
            {   
                validbagcount += bag.CanContainBag(bagName,baseBagBearers)? 1 : 0;
                //need to check for bags that contain base types
            }

            return validbagcount;
        }

        public List<Bag> ParseBags(List<string> input)
        {
            
            List<Bag> bags = new List<Bag>();
            foreach (var rule in input)
            {
                var split = rule.Split(" ");

                Bag b = new Bag();
                b.BagType = $"{split[0]} {split[1]}";

                var pattern = @"([0-9]) ([\w\s]+ )";
                var matches = Regex.Matches(rule, pattern);
                List<Bag> bagrules= new List<Bag>();
                foreach (Match m in matches)
                {
                    Bag br = new Bag();
                    br.BagType = m.Groups[2].Value.TrimEnd();
                    br.BagCount = int.Parse(m.Groups[1].Value.TrimEnd());

                    if (b.BagType == "shiny gold"){
                        ignorableBagTypes.Add(br.BagType); // add any bag types a shiny gold can contain to the ignore list.
                    }

                    if (br.BagType == "shiny gold")
                        baseBagBearers.Add(b.BagType); // add this bag type as a base holder of shiny gold.

                    bagrules.Add(br);
                }
                b.Rules = bagrules;

                bags.Add(b);
            }
            return bags;
        }
        int recursion_count=0;
        public void ParseBagsAgain(List<string> input, List<string> bagBearers)
        {
            foreach (var rule in input)
            {
                var split = rule.Split(" ");

                Bag b = new Bag();
                b.BagType = $"{split[0]} {split[1]}";
                if(bagBearers.Contains(b.BagType))
                {
                    continue;
                }

                var pattern = @"([0-9]) ([\w\s]+ )";
                var matches = Regex.Matches(rule, pattern);
                foreach (Match m in matches)
                {
                    string bagType = m.Groups[2].Value.TrimEnd();
                    if (bagBearers.Contains(bagType)){
                        bagBearers.Add(b.BagType); // add this bag type as a base holder of shiny gold.
                        baseBagBearers.Add(b.BagType); // add this bag type as a base holder of shiny gold.
                        //input.Remove(rule);
                    }

                }
            }
            recursion_count++;
            //Console.WriteLine($"{recursion_count} - {baseBagBearers.Distinct().Count()}");
            if (recursion_count < recursion_depth)
                ParseBagsAgain(input,bagBearers);
        }

    }
    public class Bag
    {
        public string BagType {get; set;}
        public List<Bag> Rules {get; set;}
        bool canHold {get; set;}
        public int BagCount{get; set;}

        public bool CanContainBag(string bag,List<string> baseBagTypes)
        {
            if (Rules==null)
                return false;
            //check if this bag is an allowed base type
            if (baseBagTypes.Contains(BagType))
                return true;
            foreach (Bag b in Rules)
            {
                if (baseBagTypes.Contains(BagType))
                    return true;
                else 
                    return b.CanContainBag(bag,baseBagTypes);
                    
            }
            return false;
        }
    }
}