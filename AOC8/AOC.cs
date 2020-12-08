using System.Threading.Tasks.Sources;
using System;
using System.Collections.Generic;

namespace AOC8
{
    public class AOC : IDisposable
    {
        public void Dispose()
        {}
        public List<Tuple<int, string, int>> ProcessData(List<string> input)
        {
            List<Tuple<int, string, int>> ret = new List<Tuple<int, string, int>>();

            foreach (string line in input)
            {
                var split = line.Split(" ");
                ret.Add(new Tuple<int, string, int>(0, split[0], int.Parse(split[1])));
            }
            return ret;
        }

        public int ExecuteInstructions(List<Tuple<int, string, int>> data)
        {
            //reset counts on everything
            for (int j = 0 ; j<data.Count ; j++ )
            {
                data[j] = new Tuple<int, string, int>(0, data[j].Item2, data[j].Item3);
            }
            int accumulator = 0;
            int i = 0;
            while (i<data.Count)
            {
                var kvp = data[i];
                if (kvp.Item1 > 0)
                    return accumulator;
                data[i] = new Tuple<int, string, int>(kvp.Item1 + 1, kvp.Item2, kvp.Item3);
                switch (kvp.Item2)
                {
                    case "acc":
                        accumulator += kvp.Item3;
                        break;
                    case "jmp":
                        i += kvp.Item3 - 1;
                        break;
                    case "nop":
                        break;
                }
                i++;
            }
            return accumulator;
        }

        public List<Tuple<int, string, int>> FindValidInstructionSet(List<Tuple<int, string, int>> data)
        {
            if(ValidateInstructions(data))
                return data;
            else
            {
                int i = 0;
                while (i<data.Count)
                {
                    string instruction = data[i].Item2;
                    if (data[i].Item2 == "jmp" || data[i].Item2 == "nop"){
                        data[i] = new Tuple<int, string, int>(0, data[i].Item2 == "jmp" ? "nop":"jmp", data[i].Item3);
                        if (ValidateInstructions(data))
                            return data;
                        else
                            data[i] = new Tuple<int, string, int>(0, instruction, data[i].Item3);
                    }
                    i++;
                }
            }
            return null;
        }

        public bool ValidateInstructions(List<Tuple<int, string, int>> data)
        {
            for (int j = 0 ; j<data.Count ; j++ )
            {
                data[j] = new Tuple<int, string, int>(0, data[j].Item2, data[j].Item3);
            }
            int accumulator = 0;
            int i = 0;
            while (true)
            {
                try
                {
                    var kvp = data[i];
                    if (kvp.Item1 > 0)
                        return false;
                    data[i] = new Tuple<int, string, int>(kvp.Item1 + 1, kvp.Item2, kvp.Item3);
                    switch (kvp.Item2)
                    {
                        case "acc":
                            accumulator += kvp.Item3;
                            break;
                        case "jmp":
                            i += kvp.Item3 - 1;
                            break;
                        case "nop":
                            break;
                    }
                    i++;
                }
                catch(Exception e)
                {
                    if (i == data.Count)
                        return true;
                    return false;
                }
            }
        }
    }
}
