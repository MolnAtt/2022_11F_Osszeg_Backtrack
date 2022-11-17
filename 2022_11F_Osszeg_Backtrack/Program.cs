using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_11F_Osszeg_Backtrack
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 1, 7, 5, };


			foreach (int item in lista)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();
			Console.WriteLine("Van-e az adott pozitív egész számokból álló listának ilyen összegű részhalmaza");
			//int o = int.Parse(Console.ReadLine());
			for (int o = 0; o < 15; o++)
			{

				Console.WriteLine($"{o}: {Vanilyen(lista, o)}");
			}
			Console.ReadKey();
		}

		private static bool Vanilyen(List<int> lista, int osszeg, int eleje=0)
		{
			bool siker = osszeg == 0;
			bool levél = eleje == lista.Count;
			bool reménytelen = osszeg < 0;

			// kilépési feltételek
			if (siker)
			{
				return true;
			}

			if (reménytelen || levél)
			{
				return false;
			}

			// visszavezetés részproblémára

			return Vanilyen(lista, osszeg, eleje + 1) || Vanilyen(lista, osszeg - lista[eleje], eleje + 1);
		}

	}
}
