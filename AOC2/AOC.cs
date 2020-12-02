using System;
using System.Collections.Generic;

namespace AOC2
{
    public class AOC : IDisposable
    {
        public List<PasswordRule> passwords { get; set; } 
        public int validPasswords=0;

        public AOC(List<String> values)
        {
            this.passwords = ParseInput(values);
        }

        public List<PasswordRule> ParseInput(List<String> values)
        {
            List<PasswordRule> ret = new List<PasswordRule>();
            //parse into PaswordRules
            //6-7 n: nnnqgdnn
            foreach (string value in values)
            {
                PasswordRule pr = new PasswordRule();
                string[] split = value.Split(" ");
                string[] minmax = split[0].Split("-");
                pr.min = int.Parse(minmax[0]);
                pr.max = int.Parse(minmax[1]);
                pr.allowedChar = split[1].ToCharArray()[0];
                pr.pass = split[2];
                pr.valid = pr.checkPassword();
                validPasswords += pr.valid ? 1 : 0;
                ret.Add(pr);

            }
            return ret;
        }

        public void Dispose()
        {
            
        }
    }

    public class PasswordRule
    {
        public char allowedChar { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public string pass { get; set; }
        public bool valid { get; set; }

        public bool checkPassword()
        {
            int allowedCharCount = 0;
            foreach (char c in pass.ToCharArray())
            {
                if (c == allowedChar)
                    allowedCharCount++;
            }
            return (allowedCharCount >= min && allowedCharCount <= max) ? true : false;
        }
    }
}
