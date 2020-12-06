using System;
using System.Collections.Generic;

namespace AOC3
{
    public class AOC : IDisposable
    {

        public int CountTrees(List<List<char>> input, int xSteps, int ySteps)
        {
            int[] coords = { 0, 0 };
            int treeCount = 0;
            int lineCount = input[0].Count;
            int rowCount = input.Count;
            while (coords[1] != rowCount-1)
            {
                try
                {
                    //Console.WriteLine($"{coords[0]},{coords[1]}");
                    coords[0] += ySteps;
                    coords[1] += xSteps;
                    if (coords[0]>=lineCount){
                        coords[0] = coords[0]-lineCount;
                    }
                    if (input[coords[1]][coords[0]] == '#')
                        treeCount++;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.ToString());
                    return treeCount;
                }
                
            }
            return treeCount;
            
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }
}
