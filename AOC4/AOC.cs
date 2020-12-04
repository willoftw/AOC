using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace AOC4
{
    public class AOC : IDisposable
    {
        public List<PassportEntry> passports = new List<PassportEntry>();
        public int validPassports = 0;

        public AOC(string filepath)
        {
            StreamReader reader = File.OpenText(filepath);

            string[] readText = File.ReadAllLines(filepath);

            string combinedBatch = "";

            for (int i = 0; i < readText.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(readText[i]))
                    combinedBatch += "∞";
                else
                    combinedBatch += " " + readText[i];
            }
            Console.WriteLine(combinedBatch);
            List<string> parseable = new List<string>(combinedBatch.Split("∞"));

            foreach (string parse in parseable)
            {
                //var dict = parse.Split(' ')
                //.Select(x => x.Split(':'))
                //.ToDictionary(x => x[0], x => x[1]);
                //parse.Replace('\n', ' ');
                List<string> pairs = new List<string>(parse.Split(" "));

                PassportEntry entry = new PassportEntry();
                foreach (string value in pairs)
                {
                    if (string.IsNullOrWhiteSpace(value))
                        continue;
                    string[] keyvalues = value.Split(":");
                    Console.WriteLine(keyvalues);

                    keyvalues[1] = string.IsNullOrWhiteSpace(keyvalues[1]) ? "" : keyvalues[1];
                    //byr(Birth Year)
                    //iyr(Issue Year)
                    //eyr(Expiration Year)
                    //hgt(Height)
                    //hcl(Hair Color)
                    //ecl(Eye Color)
                    //pid(Passport ID)
                    //cid(Country ID)
                    switch (keyvalues[0])
                    {
                        case "byr":
                            entry.Byr = keyvalues[1];
                            break;
                        case "iyr":
                            entry.Iyr = keyvalues[1];
                            break;
                        case "eyr":
                            entry.Eyr = keyvalues[1];
                            break;
                        case "hgt":
                            entry.Hgt = keyvalues[1];
                            break;
                        case "hcl":
                            entry.Hcl = keyvalues[1];
                            break;
                        case "ecl":
                            entry.Ecl = keyvalues[1];
                            break;
                        case "pid":
                            entry.Pid = keyvalues[1];
                            break;
                        case "cid":
                            entry.Cid = keyvalues[1];
                            break;
                        case "":
                            break;
                    }
                    Console.WriteLine(entry);

                }
                passports.Add(entry);
            }

            foreach (PassportEntry p in passports)
            {
                if (p.isValid())
                    validPassports++;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

    }

    public class PassportEntry
    {
        //^(\d{3,3})cm$|^(\d{2,2})in$
        private string byr = "";//(Birth Year)
        private string iyr ="";//(Issue Year)
        private string eyr = "";//(Expiration Year)
        private string hgt = "";//(Height)
        private string hcl = "";//hcl(Hair Color)
        private string ecl = ""; //ecl(Eye Color)
        private string pid = "";//(Passport ID)
        private string cid = "";//(Country ID)

        public string Byr { get { return (byr.Length == 4 && isInRange(int.Parse(byr), 1920, 2002)) ? byr : ""; } set { this.byr = value; } }//(Birth Year)
        public string Iyr { get { return (iyr.Length == 4 && isInRange(int.Parse(iyr), 2010, 2020)) ? iyr : ""; } set { this.iyr = value; } }//(Issue Year)
        public string Eyr { get { return (eyr.Length == 4 && isInRange(int.Parse(eyr), 2020, 2030)) ? eyr : ""; } set { this.eyr = value; } }//(Expiration Year)
        public string Hgt
        {
            get
            {
                try
                {
                    string unit = hgt.ToCharArray()[hgt.Length - 2] + "" + hgt.ToCharArray()[hgt.Length - 1];
                    if (unit == "cm" || unit == "in")
                    {
                        int value = int.Parse(hgt.Substring(0, hgt.Length - 2));
                        bool valid = unit switch
                        {
                            "cm" => isInRange(value, 150, 193) ? true : false,
                            "in" => isInRange(value, 59, 76) ? true : false,
                            _ => throw new NotImplementedException()
                        };
                        return valid ? hgt : "";
                    }
                    return "";
                }
                catch(Exception e )
                {
                    return "";
                }
            }
            set { this.hgt = value; }
        }//(Height)
        public string Hcl
        {
            get
            {
                try
                {
                    if (hcl.ToCharArray()[0] != '#')
                        return "";
                    return hcl.Substring(1).ToCharArray().Length == 6 ? hcl : "";
                }
                catch (Exception e)
                {
                    return "";
                }
            }
            set { this.hcl = value; }
        }//hcl(Hair Color)
        public string Ecl { get { return Regex.Match(ecl, "^(amb|blu|brn|gry|grn|hzl|oth)$").Success ? ecl : ""; } set { this.ecl = value; } } //ecl(Eye Color)
        public string Pid { get { try { return pid.ToCharArray().Length == 9 ? pid : ""; } catch (Exception e) { return ""; } } set { this.pid = value; } }//(Passport ID)
        public string Cid { get; set; }//(Country ID)

        bool isInRange(int num, int bottom, int top)
        {
            return (num >= bottom && num <= top);
        }

        public bool isValid()
        {
            if (Byr!="" &&
                Iyr != "" &&
                Eyr != "" &&
                Hgt != "" &&
                Hcl != "" &&
                Ecl != "" &&
                Pid != "" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isFullyPopulated()
        {
            if (Byr != "" &&
                Iyr != "" &&
                Eyr != "" &&
                Hgt != "" &&
                Hcl != "" &&
                Ecl != "" &&
                Pid != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
