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
			KohonenNetwork kohonenNetwork = new KohonenNetwork(4,16);
			kohonenNetwork.Study(new[] { 0, 0, 0, 0 }, 0);
			kohonenNetwork.Study(new[] { 0, 0, 0, 1 }, 1);
			kohonenNetwork.Study(new[] { 0, 0, 1, 0 }, 2);
			kohonenNetwork.Study(new[] { 0, 0, 1, 1 }, 3);
			kohonenNetwork.Study(new[] { 0, 1, 0, 0 }, 4);
			kohonenNetwork.Study(new[] { 0, 1, 0, 1 }, 5);
			kohonenNetwork.Study(new[] { 0, 1, 1, 0 }, 6);
			kohonenNetwork.Study(new[] { 0, 1, 1, 1 }, 7);
			kohonenNetwork.Study(new[] { 1, 0, 0, 0 }, 8);
			kohonenNetwork.Study(new[] { 1, 0, 0, 1 }, 9);
			kohonenNetwork.Study(new[] { 1, 0, 1, 0 }, 10);
			kohonenNetwork.Study(new[] { 1, 0, 1, 1 }, 11);
			kohonenNetwork.Study(new[] { 1, 1, 0, 0 }, 12);
			kohonenNetwork.Study(new[] { 1, 1, 0, 1 }, 13);
			kohonenNetwork.Study(new[] { 1, 1, 1, 0 }, 14);
			kohonenNetwork.Study(new[] { 1, 1, 1, 1 }, 15);
			Console.WriteLine(kohonenNetwork.Handle(new[]{ 1, 0, 1, 0}));
			Console.ReadKey();
		}
	}
}
