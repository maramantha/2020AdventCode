using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020AdventCode
{
    class Day6Challenge
    {
        private int _sumYesAnswers { get; set; }
        public int sumYesAnswers { get => _sumYesAnswers; }

        private struct individualAnswers
        {
            public int yesAnswers;
            public string yesQuestionsIDs;
        }

        private class GroupAnswers
        {
            public int numPeople;
            public List<individualAnswers> IAL = new List<individualAnswers>();
            public int sharedAnswerCount;


        }
        private void groupTherapy(ref List<string> ItemList, out GroupAnswers GA)
        {
            GroupAnswers GA1 = new GroupAnswers();
            individualAnswers IA = new individualAnswers();
            IA.yesQuestionsIDs = "";
            foreach (string Item in ItemList)
            {
                GA1.numPeople++;
                for (int i = 0; i < Item.Length; i++)
                {
                    if (!IA.yesQuestionsIDs.Contains(Item[i]))
                    {
                        IA.yesAnswers++;
                        IA.yesQuestionsIDs = IA.yesQuestionsIDs + Item[i];
                    }
                }
                GA1.IAL.Add(IA);
                IA = new individualAnswers();
                IA.yesQuestionsIDs = "";
            }
            GA = GA1;
        }

        private void yesCounter(ref List<GroupAnswers> GAL)
        {
            string compareValues = "1";
            string tempHolder = string.Empty;
            foreach(GroupAnswers GA in GAL)
            {
                foreach(individualAnswers IA in GA.IAL)
                {
                    if(compareValues == "1")
                    {
                        compareValues = IA.yesQuestionsIDs;
                    } else
                    {
                        
                        for(int i = 0; i < compareValues.Length;i++)
                        {
                            if(IA.yesQuestionsIDs.Contains(compareValues[i]))
                            {
                                tempHolder = tempHolder + compareValues[i];
                            }
                        }
                        compareValues = tempHolder;
                        tempHolder = string.Empty;
                    }
                }
                GA.sharedAnswerCount = compareValues.Length;
                compareValues = "1";
                _sumYesAnswers += GA.sharedAnswerCount;
            }
        }

        private void groupAssigner(ref string[] grpAnswers)
        {
            List < GroupAnswers > GAL = new List<GroupAnswers>();
            List<string> DeclarItem = new List<string>();
            GroupAnswers GA = new GroupAnswers();
            for (int i =0; i < grpAnswers.Length; i++)
            {
                if(grpAnswers[i] != "")
                {
                    DeclarItem.Add(grpAnswers[i]);
                }
                else
                {
                    groupTherapy(ref DeclarItem,out GA);
                    GAL.Add(GA);
                    DeclarItem.Clear();
                    GA = new GroupAnswers();

                }

            }
            groupTherapy(ref DeclarItem, out GA);
            GAL.Add(GA);
            yesCounter(ref GAL);
        } 

        public Day6Challenge(string[] grpAnswers)
        {
            groupAssigner(ref grpAnswers);
        }
    }
}
