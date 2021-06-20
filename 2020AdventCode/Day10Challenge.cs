using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2020AdventCode
{
	class Day10Challenge
	{
		private double deviceJoltage;
		private int joltDeltaTolerance = 3;
		private bool joltsWithinTolerance = true;
		private double JoltDeltaMultiplier = 0;
		private List<double> JoltDelta = new List<double>();
		public double SomeValu() { return JoltDeltaMultiplier; }
		private void joltSorter(ref double[] AdapterBag )
        {
			Stack<double> AdapterPile = new Stack<double>() ;
			while(AdapterBag.Min() != AdapterBag.Max())
			{
				int AdapterBagINdex = 0;
				AdapterPile.Push(AdapterBag.Min());
				while(AdapterBag[AdapterBagINdex] != AdapterBag.Min())
                {
					AdapterBagINdex++;
                }
				AdapterBag[AdapterBagINdex] = AdapterBag.Max();
            }
			AdapterPile.Push(AdapterBag.Max());
			for(int i = AdapterBag.Length-1; i >= 0; i--)
            {
				double AdapterJoltage = AdapterPile.Pop();
				if(i == AdapterBag.Length-1)
                {
					JoltDelta.Add(deviceJoltage - AdapterJoltage);
                }
				else
                {
					JoltDelta.Add(AdapterBag[i + 1] - AdapterJoltage);
                }
				AdapterBag[i] = AdapterJoltage;
            }
			JoltDelta.Add(AdapterBag[0] - 0);
			joltAccumulator();

		}
		private void joltDeltaCalc(double[] Adapters, double nextAdapter = 0)
        {
			double JoltDelta = Adapters[0] - 0;

			for (int i = 0; i<Adapters.Length-1;i++)
            {
				JoltDelta = Adapters[i + 1] - Adapters[i];
				if(JoltDelta<=joltDeltaTolerance)
                {

                }
                else
                {
					joltsWithinTolerance = false;
                }
            }
        }

		private void joltAccumulator()
        {
			int joltValue1 = 0;
			int joltValue3 = 0;
			foreach(double i in JoltDelta)
            {
				if(i == 1)
                {
					joltValue1++;
                }
				else if(i ==3)
                {
					joltValue3++;
                }
            }
			JoltDeltaMultiplier = joltValue1 * joltValue3;
        }

		public Day10Challenge(string[] grpAnswers)
		{
			double[] Adapters = new double[grpAnswers.Length];
			for(int i = 0; i < grpAnswers.Length; i++)
            {
				Adapters[i] = Convert.ToDouble(grpAnswers[i]);
            }
			deviceJoltage = Adapters.Max()+3;
			joltSorter(ref Adapters);
		}
	}
}
