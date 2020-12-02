using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day1Challenge
    {
        private static List<int> _Balance;

        public int BalanceProduct { get; set; }

        private void CheckValues()
        {
            int checkValue = 2020;
            foreach(int Item1 in _Balance)
            {
                foreach(int Item2 in _Balance)
                {
                    foreach (int Item3 in _Balance)
                    {
                        if (Item1 + Item2 + Item3 == checkValue)
                        {
                            BalanceProduct = Item1 * Item2 * Item3;
                        }
                    }
                }
            }
        }

        public Day1Challenge(List<int> BL)
        {
            _Balance = BL;
            CheckValues();
        }
    }
}
