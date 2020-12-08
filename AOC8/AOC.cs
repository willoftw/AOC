using System.Threading.Tasks.Sources;
using System;
using System.Collections.Generic;

namespace AOC8
{
    public class AOC : IDisposable
    {
        public void Dispose()
        {
        }
        //nop +0
        public List<Tuple<int,string, int>> ProcessData(List<string> input)
        {
            List<Tuple<int,string, int>> ret = new List<Tuple<int,string, int>>();

            foreach (string line in input)
            {
                var split = line.Split(" ");
                ret.Add(new Tuple<int,string, int>(0,split[0], int.Parse(split[1])));
            }
            return ret;
        }

        public int ExecuteInstructions(List<Tuple<int,string, int>> data)
        {
            int accumulator = 0;
                int i = 0;
                while(true)
                {
                    var kvp = data[i];
                    if (kvp.Item1 > 0)
                        return accumulator;
                    data[i] = new Tuple<int, string, int>(kvp.Item1+1,kvp.Item2,kvp.Item3);
                    switch (kvp.Item2)
                    {
                        case "acc":
                            accumulator += kvp.Item3;
                            break;
                        case "jmp":
                            i += kvp.Item3-1;
                            break;
                        case "nop":
                            break;
                    }
                    i++;
                    
                }
        }
    }
}
