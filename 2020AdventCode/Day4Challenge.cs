using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day4Challenge
    {
        private double _validPassportCount { get; set; }
        public double validPassportCount { get => _validPassportCount; }
        private struct passportData
        {
            public int birthYear;
            public int issueYear;
            public int expirationYear;
            public string height;
            public string hairColor;
            public string eyeColor;
            public string pid;
            public string cid;
        }
        private void lineSplitter(List<string> Passport, out passportData filledPassport)
        {
            passportData TPD = new passportData();
            
            foreach(string line in Passport)
            {
                string[] items = line.Split(' ');
                foreach(string i in items)
                {
                    string[] obj = i.Split(':');
                    switch(obj[0])
                    {
                        case "byr":
                            TPD.birthYear = Convert.ToInt32(obj[1]);
                            break;
                        case "iyr":
                            TPD.issueYear = Convert.ToInt32(obj[1]);
                            break;
                        case "eyr":
                            TPD.expirationYear = Convert.ToInt32(obj[1]);
                            break;
                        case "hgt":
                            TPD.height = obj[1];
                            break;
                        case "hcl":
                            TPD.hairColor = obj[1];
                            break;
                        case "ecl":
                            TPD.eyeColor = obj[1];
                            break;
                        case "pid":
                            TPD.pid = obj[1];
                            break;
                        case "cid":
                            TPD.cid = obj[1];
                            break;
                    }
                }
            }

            filledPassport = TPD;
        }

        private void filetoPassport(ref List<passportData> PD, string[] input)
        {
                passportData tempPD = new passportData();
                List<string> oneFile = new List<string>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != "")
                    {
                        oneFile.Add(input[i]);
                    }else
                    {
                        
                        lineSplitter(oneFile, out tempPD);
                        PD.Add(tempPD);
                        oneFile.Clear();
                    }
                }
            lineSplitter(oneFile, out tempPD);
            PD.Add(tempPD);
            oneFile.Clear();

        }
        private void cntValidPassports(ref List<passportData> PD)
        {
            foreach(passportData Passport in PD)
            {
                if(Passport.birthYear != 0)
                {
                    if (Passport.issueYear != 0)
                    {
                        if (Passport.expirationYear != 0)
                        {
                            if (Passport.height != null)
                            {
                                if (Passport.hairColor != null)
                                {
                                    if (Passport.eyeColor != null)
                                    {
                                        if (Passport.pid != null)
                                        {
                                            _validPassportCount++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public Day4Challenge(string[] inputFile)
        {
            List<passportData> PD = new List<passportData>();
            filetoPassport(ref PD, inputFile);
            cntValidPassports(ref PD);

        }


    }
}
