using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day2Challenge
    {
        private int _validPasswordCount { get; set; }
        public int validPasswordCount { get => _validPasswordCount; }

        private static int LowerLimit(string Policy)
        {
            int num;
            try
            {
                num = Convert.ToInt32(Policy.Substring(0, Policy.IndexOf('-')));
            }catch(Exception ex)
            {
                num = -1;
            }
            return num;
        }
        private static int UpperLimit(string Policy)
        {
            int num;
            try
            {
                num = Convert.ToInt32(Policy.Substring(Policy.IndexOf('-')+1, Policy.IndexOf(' ')- Policy.IndexOf('-')-1));
            }
            catch (Exception ex)
            {
                num = -1;
            }
            return num;
        }
        private static string PolicyLimit(string Policy)
        {
            
            return Policy.Substring(Policy.IndexOf(' ')+1);
        }
        private int pwdLooper(string Policy, string Term)
        {
            int hitCounter;
            hitCounter = 0;
            for (int i = 0; i < Policy.Length; i++)
            {
                if (Policy.Substring(i, Term.Length) == Term)
                {
                    hitCounter++;
                }
            }
            return hitCounter;
        }
        private bool PolicyCheck(int uLimit,int lLimit, int occurance)
        {

            if (occurance >= lLimit && occurance <= uLimit)
            {
                return true;
            } else
            {
                return false;
            }
        }
        private bool PolicyCheck(int pos1, int pos2, string Term, string pwd)
        {

            if (pwd[pos1-1].ToString() == Term && pwd[pos2 - 1].ToString() != Term 
                || pwd[pos1 - 1].ToString() != Term && pwd[pos2 - 1].ToString() == Term)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void pwdCounter(string[] inputFile)
        {
            int lowerLimit;
            int upperLimit;
            string explicityPolicy;
            
            int pwdCntIncrimenter = 0;
            foreach(string input in inputFile)
            {
                
                string Term = input.Split(':')[0];
                lowerLimit = LowerLimit(Term);
                upperLimit = UpperLimit(Term);
                explicityPolicy = PolicyLimit(Term);
                Term = input.Split(':')[1].Trim();

                int hitCounter = pwdLooper(Term, explicityPolicy);
                if (PolicyCheck(lowerLimit, upperLimit,  explicityPolicy, Term))
                {
                    pwdCntIncrimenter++;
                }
            }
            _validPasswordCount = pwdCntIncrimenter;
        }
        public Day2Challenge(string[] inputFile)
        {
            pwdCounter(inputFile);
        }
    }
}
