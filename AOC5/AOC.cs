using System;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC5
{
    public class AOC : IDisposable
    {
        public void Dispose()
        {
            
        }
        //F means "front", B means "back", L means "left", and R means "right".
        //Seats are 0-127
        //first 7 characters
        public int[] Decode(string v)
        {
            int[] seat = new int[] {0,0,0};
            char[] chars = v.ToCharArray();
            int[] rowrange = new int[] {0,128} ;
            //32,64

            //front = min = rowrange[0]+(Range(rowrage)/2); max = rowrage[1]
            for(int i = 0; i<7 ; i++)
            {
                int r = Range(rowrange);
                Console.WriteLine(chars[i]);
                switch(chars[i])
                {
                    case 'F':
                        rowrange[0] = rowrange[0];
                        rowrange[1] = rowrange[0]+(r/2);
                        break;
                    case 'B':
                        rowrange[0] = rowrange[0]+r/2;
                        rowrange[1] = rowrange[1];
                        break;
                }
                Console.WriteLine($" row {rowrange[0]},{rowrange[1]}");
            }
            int[] colrange = new int[] {0,7} ;
            for(int i = 7; i<10 ; i++)
            {
                int r = Range(colrange);
                Console.WriteLine(chars[i]);
                switch(chars[i])
                {
                    case 'L':
                        colrange[0] = colrange[0];
                        colrange[1] = colrange[0]+(r/2);
                        break;
                    case 'R':
                        colrange[0] = colrange[0]+r/2;
                        colrange[1] = colrange[1];
                        break;
                }
                Console.WriteLine($" col {colrange[0]},{colrange[1]}");
            }
            
            return new int[] {rowrange[1]-1,colrange[1],(rowrange[1]-1)*8+colrange[1]};
        }

        private int Range(int[] range)
        {
            return range[1]-range[0];
        }
    }
}
