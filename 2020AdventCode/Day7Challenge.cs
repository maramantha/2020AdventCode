using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day7Challenge
    {
        class Bag
        {
            private string currentBag;
            List<Bag> containedIn = new List<Bag>();
            List<Bags> contents = new List<Bags>();
            public Boolean visited;

            public Bag(string currentBag)
            {
                this.currentBag = currentBag;
                visited = false;
            }
            public string getBagName()
            {
                return currentBag;
            }
            int hashCode()
            {
                return currentBag.GetHashCode();
            }

            public void Containerfor(Bags bgs)
            {
                contents.Add(bgs);
            }

            public void ContainIn(Bag bgs)
            {
                containedIn.Add(bgs);
            }
            public bool ContainColor(string color)
            {
                foreach(Bags items in contents)
                {
                    if(color == items.Color)
                    {
                        return true;
                    }
                }
                return false;
            }
            public List<Bags> BagsThisContains()
            {
                return contents;
            }
            public List<Bag> bagsContainedin()
            {
                return containedIn;
            }
        }

        class Bags
        {
            public int Num { get; set; }
            public string Color { get; set; }
        }
        private double _BagCounttoTargetBag { get; set; }
        public double BagCounttoTargetBag { get => _BagCounttoTargetBag; }
        
        private void listCreater(ref List<Bag> CBL, ref string[] GA)
        {
            foreach (string line in GA)
            {
                string[] lineContained = new string[2]; //= ;
                lineContained[0] = line.Substring(0, line.IndexOf("contain")).Replace("bags", "").Trim();// contained[0];
                Bag baggage = new Bag(lineContained[0]);
                lineContained[1] = line.Substring(line.IndexOf("contain")).Replace("contain", "").Trim();
                lineContained[1] = lineContained[1].Replace(".", "").Replace("bags", "").Replace("bag", "").Trim();
                string[] containee = lineContained[1].Split(',');
                foreach(string bg in containee)
                {
                    Bags Containtees = new Bags();
                    try
                    {
                        string NumPart = bg.Trim().Substring(0, bg.Trim().IndexOf(" ")).Trim();
                        int qty;
                        if (NumPart == "no")
                        {
                            qty = 0;
                        } else
                        {
                            qty = Int32.Parse(NumPart);
                        }
                        string color = bg.Replace(qty.ToString(), "").Trim();
                        Containtees.Num = qty;
                        Containtees.Color = color;
                        baggage.Containerfor(Containtees);
                    }
                    catch
                    {
                        Console.WriteLine(bg);
                    }
                }
                CBL.Add(baggage);
            }
            foreach(Bag bg in CBL)
            {
                Bag beta = bg;
                CBLContainedInOtehrBags(ref CBL, ref beta);
            }
        }

        private void CBLContainedInOtehrBags(ref List<Bag> CBL, ref Bag baggage)
        {
            foreach(Bag bg in CBL)
            {
                if (bg.ContainColor(baggage.getBagName()) && !(bg.getBagName() == baggage.getBagName()))
                {
                    CBL[CBL.IndexOf(baggage)].ContainIn(bg);
                }
            }
        }

        private bool FindLongestRouteforSetColor(List<Bag> CBL, string targetBag, string startBag, out int RouteCount)
        {
            List<Bag> CBLRep = CBL;
            int tempRouteCount = 0;
            int maxRouteCount = 0;
            Boolean foundColor = false;
            foreach(Bag bg in CBLRep)
            {
                if(bg.ContainColor(startBag))
                {
                    if(bg.getBagName() == targetBag)
                    {
                        foundColor = true;
                    }
                    foreach (Bag bgs in bg.bagsContainedin())
                    {
                        if (!bg.visited)
                        {
                            FindLongestRouteforSetColor(CBLRep, targetBag, bgs.getBagName(), out tempRouteCount);
                            tempRouteCount++;
                        }
                    }
                    bg.visited = true;
                }
                if(maxRouteCount < tempRouteCount) { maxRouteCount = tempRouteCount; }
            }
            RouteCount = maxRouteCount;
            return foundColor;

        }

        private void BagsContainTarget(ref List<Bag> CBL, Bag startBag, ref HashSet<string> bagHolder)
        {
            foreach (Bag cb in CBL[CBL.IndexOf(startBag)].bagsContainedin())
                {
                if(!bagHolder.Contains(cb.getBagName()))
                {
                    bagHolder.Add(cb.getBagName());
                }
                BagsContainTarget(ref CBL, cb, ref bagHolder);
                }
        }
        
        private bool BagsContainTarget(List<Bag> CBL, string targetBag, out int BagHolderCnt)
        {
            BagHolderCnt = 0;
            HashSet<string> BagHolder = new HashSet<string>();
            foreach (Bag bg in CBL)
            {
                if(bg.getBagName() == targetBag)
                {
                    foreach(Bag cb in bg.bagsContainedin())
                    {
                        BagHolder.Add(cb.getBagName());
                        BagsContainTarget(ref CBL, cb, ref BagHolder);
                    }
                }
            }
            BagHolderCnt = BagHolder.Count();
            return false;
        }
        
        public Day7Challenge(string[] grpAnswers, string searchBag, int minQty)
        {
            List<Bag> BagPool = new List<Bag>();
            listCreater(ref BagPool, ref grpAnswers);
            BagsContainTarget(BagPool, searchBag, out LongestRoute);
        }
        private int LongestRoute;
        public int GetLogestedRoute() { return LongestRoute; }
    }
}