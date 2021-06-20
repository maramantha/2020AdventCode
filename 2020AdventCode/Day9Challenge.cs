using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2020AdventCode
{
	class Day9Challenge
	{
		private double MissingAvailableFactorValue = 0;
		private double EncryptionWeakness = 0;
		public double MissingFactorOutput() { return MissingAvailableFactorValue; }
		public double EncryptionFactorWeakness() { return EncryptionWeakness; }
		private bool findFirstNonFactoredItem(double[] xmasList, int EncryptionLen, int index = 0)
        {
			double factoringValue = xmasList[index + EncryptionLen + 1];
			if(index + EncryptionLen < xmasList.Length) 
            {
				for(int a = index; a < index + EncryptionLen; a++)
                {
					for(int b = a + 1;b<=index+ EncryptionLen; b++)
                    {
						if(xmasList[a] + xmasList[b] == factoringValue)
                        {
							index++;
							return findFirstNonFactoredItem(xmasList,EncryptionLen, index);
						}
                    }
                }
				MissingAvailableFactorValue = factoringValue;
				
				return FindEncryptionWeakness(xmasList);

			} else
            {
				return false;
            }
        }

		private bool FindEncryptionWeakness(double[] xmasList)
        {
			double summation;
			for(int i = 0; i < xmasList.Length;i++)
            {
				summation = 0;
				int a = i;
				do
				{
					summation += xmasList[a];
					a++;
				} while (summation < MissingAvailableFactorValue);
				a--;
				if(summation == MissingAvailableFactorValue)
                {
					double[] contingeousSet = setContingeousArray(xmasList, i, a);
					EncryptionWeakness = contingeousSet.Min() + contingeousSet.Max();
					return true;
                }
			}
			return false;
        }

		private double[] setContingeousArray(double[] xmasList, int beginningIndex, int endingIndex)
        {
			List<double> xmasPool = new List<double>();
			for(int i = beginningIndex; i <=endingIndex;i++)
            {
				xmasPool.Add(xmasList[i]);
            }
			return xmasPool.ToArray();
        }

		public Day9Challenge(string[] grpAnswers, int EncryptionLength)
		{
			
			double[] xmasEncrption = new double[grpAnswers.Length];
			bool FoundMissingFactor = false;
			for(int i = 0; i < grpAnswers.Length;i++)
            {
				string item = grpAnswers[i];
				xmasEncrption[i] = Convert.ToDouble(grpAnswers[i]);
            }
			FoundMissingFactor = findFirstNonFactoredItem(xmasEncrption, EncryptionLength);
		}
	}
}
