using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logic;

namespace TestNeuralNetworkConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 10000;
			KohonenNetwork kohonenNetwork = new KohonenNetwork(count,10);

			for (int i = 0; i < count; i++)
			{
				int[] test;
				var indexMax = Test(count, out test);
				kohonenNetwork.Study(test, indexMax);
			}

			int countTests = 10000;
			int correct = 0;
			for (int i = 0; i < countTests; i++)
			{
				int[] example;
				int result = Test(count, out example);
				int t = kohonenNetwork.Handle(example);
				if (t == result) correct++;
				//Console.WriteLine(kohonenNetwork.Handle(example));
				//Console.WriteLine("true:{0}", result);
				//Console.ReadKey();
			}
			Console.WriteLine((double)correct/countTests);
			Console.ReadKey();

		}

		private static int Test(int count, out int[] test)
		{
			long seed = DateTime.Now.Ticks;
			Random rnd = new Random((int)seed);
			int a = rnd.Next()%count;
			int b = rnd.Next()%count;
			int c = rnd.Next()%count;
			test = new int[count];
			for (int j = 0; j < test.Length; j++)
			{
				test[j] = (int)(c*Math.Pow(j - a,2)) + b;
			}
			return a / 100000;
		}
	}
}
