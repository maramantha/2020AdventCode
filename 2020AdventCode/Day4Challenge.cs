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
        private bool validBirthYear(int checkValue)
        {
            int lwrYear = 1920;
            int upperYear = 2002;
            bool checkRtn = checkValue != 0;
            if (checkRtn)
            {
                checkRtn = checkValue > 999 && checkValue < 10000; //4 digit value
            }
            if (checkRtn)
            {
                checkRtn = checkValue <= upperYear;
            }
            if (checkRtn)
            {
                checkRtn = checkValue >= lwrYear;
            }
            return checkRtn;
        }
        private bool validIssueYear(int checkValue)
        {
            int lwrYear = 2010;
            int upperYear = 2020;
            bool checkRtn = checkValue != 0;
            if (checkRtn)
            {
                checkRtn = checkValue > 999 && checkValue<10000; //4 digit value
            }
            if (checkRtn)
            {
                checkRtn = checkValue <= upperYear;
            }
            if (checkRtn)
            {
                checkRtn = checkValue >= lwrYear;
            }
            return checkRtn;
        }
        private bool validExprYear(int checkValue)
        {
            int lwrYear = 2020;
            int upperYear = 2030;
            bool checkRtn = checkValue != 0;
            if (checkRtn)
            {
                checkRtn = checkValue > 999 && checkValue < 10000; //4 digit value
            }
            if (checkRtn)
            {
                checkRtn = checkValue <= upperYear;
            }
            if (checkRtn)
            {
                checkRtn = checkValue >= lwrYear;
            }
            return checkRtn;
        }
        private bool validHght(string checkValue)
        {
            int cmLwr = 150;
            int cmUpr = 193;
            int inLwr = 59;
            int inUpr = 76;
            bool checkRtn = false;
            int heightVal;
            if (checkValue != null)
            {
                if (checkValue.Contains("in"))
                {
                    try
                    {
                        heightVal = Convert.ToInt32(checkValue.Replace("in", ""));
                        checkRtn = heightVal >= inLwr;
                        if (checkRtn)
                        {
                            checkRtn = heightVal <= inUpr;
                        }
                    }
                    catch (Exception ex)
                    {
                        checkRtn = false;
                    }
                } else if (checkValue.Contains("cm"))
                {
                    try
                    {
                        heightVal = Convert.ToInt32(checkValue.Replace("cm", ""));
                        checkRtn = heightVal >= cmLwr;
                        if (checkRtn)
                        {
                            checkRtn = heightVal <= cmUpr;
                        }
                    } catch(Exception ex)
                    {
                        checkRtn = false;
                    }
                }
            }
            return checkRtn;
        }
        private bool validPid(string checkValue)
        {
            bool checkRtn = false;
            if (checkValue != null)
            { 
            checkRtn = checkValue.Length == 9;
            int tempHold;
            try
            {
                if(checkRtn)
                {
                    tempHold = Convert.ToInt32(checkValue);
                }
            } catch(Exception ex)
            {
                checkRtn = false;
            }
            }
            return checkRtn;
        }
        private bool validEyeColor(string checkValue)
        {
            bool checkRtn = false;
            if (checkValue != null)
            {
                switch (checkValue)
                {
                    case "amb":
                        checkRtn = true;
                        break;
                    case "blu":
                        checkRtn = true;
                        break;
                    case "brn":
                        checkRtn = true;
                        break;
                    case "gry":
                        checkRtn = true;
                        break;
                    case "grn":
                        checkRtn = true;
                        break;
                    case "hzl":
                        checkRtn = true;
                        break;
                    case "oth":
                        checkRtn = true;
                        break;
                }
            }
            return checkRtn;
        }
        private bool validHair(string checkValue)
        {
            char[] HexValues = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            bool checkRtn = false;
            if (checkValue != null)
            {
                if(checkValue[0] =='#')
                {
                    checkRtn = checkValue.Length == 7;
                    for(int i = 1; i < checkValue.Length; i++)
                    {
                        checkRtn = HexValues.Contains(checkValue[i]);
                    }
                }
                
            }
            return checkRtn;
        }

        private void cntValidPassports(ref List<passportData> PD)
        {
            foreach(passportData Passport in PD)
            {
                if(validBirthYear(Passport.birthYear))
                {
                    if (validIssueYear(Passport.issueYear))
                    {
                        if (validExprYear(Passport.expirationYear))
                        {
                            if (validHght(Passport.height))
                            {
                                if (validHair(Passport.hairColor))
                                {
                                    if (validEyeColor(Passport.eyeColor))
                                    {
                                        if (validPid(Passport.pid))
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