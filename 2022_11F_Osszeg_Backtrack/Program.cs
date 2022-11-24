using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_11F_Osszeg_Backtrack
{
	class Program
	{
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
			// return Vanilyen(lista, osszeg, eleje + 1) || Vanilyen(lista, osszeg - lista[eleje], eleje + 1);

			// végigpróbálgatás

			for (int i = 0; i < 2; i++)
				if (Vanilyen(lista, osszeg - i * lista[eleje], eleje + 1))
					return true;
			return false;
		}

		static int[] elso_megoldas;
		private static bool Első(List<int> lista, int osszeg, int eleje = 0)
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

			// végigpróbálgatás

			for (int i = 0; i < 2; i++)
			{
				if (Első(lista, osszeg - i * lista[eleje], eleje + 1))
				{
					elso_megoldas[eleje] = i; // csak akkor mentjük el, ha bevált!
					return true;
				}
			}
			return false;

		}

		static List<int[]> osszes_mo;
		static int[] akt_mo;
		private static void Kiválogatás(List<int> lista, int osszeg, int eleje = 0)
		{
			bool siker = osszeg == 0;
			bool levél = eleje == lista.Count;
			bool reménytelen = osszeg < 0;

			// kilépési feltételek
			if (siker)
			{
				osszes_mo.Add(akt_mo.ToArray());
				return;
			}

			if (reménytelen || levél)
			{
				return;
			}

			// visszavezetés részproblémára

			// végigpróbálgatás

			for (int i = 0; i < 2; i++) // ha 1,0 sorrendben próbálgatunk (i--), akkor nem is kell a visszaalakítás!
			{
				akt_mo[eleje] = i;
				Kiválogatás(lista, osszeg - i * lista[eleje], eleje + 1);
				akt_mo[eleje] = 0;
			}
		}


		private static bool Vanilyen_quick(List<int> lista, int osszeg, int eleje = 0) => osszeg == 0 ? true : ((osszeg < 0 || eleje == lista.Count) ? false : Vanilyen_quick(lista, osszeg, eleje + 1) || Vanilyen_quick(lista, osszeg - lista[eleje], eleje + 1));

		static void Kiir(List<int> lista, int[] karakterisztika)
		{
			Console.Write("{");
			for (int i = 0; i < lista.Count; i++)
			{
				if (karakterisztika[i] == 1)
				{
					Console.Write($"{lista[i]} ");
				}
			}
			Console.WriteLine("}");
		}
		static void Main(string[] args)
		{
			List<int> lista = new List<int> { 1, 13, 6, 8, 10, 3, 19, 5, 4, 2, 9, 11};

			foreach (int item in lista)
			{
				Console.Write($"{item} ");
			}
			Console.WriteLine();

			Console.WriteLine("Van-e az adott pozitív egész számokból álló listának ilyen összegű részhalmaza?");
			for (int o = 0; o < 15; o++)
			{
				Console.WriteLine($"{o}: {Vanilyen(lista, o)}");
			}
			Console.WriteLine("--------------------------------------");

			Console.WriteLine("Van-e az adott pozitív egész számokból álló listának ilyen összegű részhalmaza, és ha igen, adj meg egyet!");
			Console.WriteLine($"{string.Join(",", lista)}"); 
			
			for (int o = 0; o < 15; o++)
			{
				elso_megoldas = new int[lista.Count];
				bool vane = Első(lista, o);
				Console.Write($"{o}: {vane}");
				if (vane)
				{
					Console.Write(" -> [ ");
					for (int i = 0; i < lista.Count; i++)
					{
						Console.Write(elso_megoldas[i]);
						Console.Write(" ");
					}
					Console.Write("]");
				}
				Console.WriteLine();
			}

			Console.WriteLine("--------------------------------------");

			Console.WriteLine("Az adott pozitív egész számokból álló listának add meg az összes ilyen összegű részhalmazát!");
			Console.WriteLine($"{string.Join(",", lista)}");

			for (int o = 0; o < 30; o++)
			{
				Console.Write($"{o} ->\t");
				osszes_mo = new List<int[]>();
				akt_mo = new int[lista.Count];

				Kiválogatás(lista, o);
				for (int j = 0; j < osszes_mo.Count; j++)
				{
					Console.Write($" [{string.Join(" ", osszes_mo[j])}] ");
				}

				Console.WriteLine();
			}

			for (int o = 0; o < 30; o++)
			{
				Console.Write($"{o} ->\t");
				osszes_mo = new List<int[]>();
				akt_mo = new int[lista.Count];

				Kiválogatás(lista, o);
				for (int j = 0; j < osszes_mo.Count; j++)
				{
					Kiir(lista, osszes_mo[j]);
				}

				Console.WriteLine();
			}
			Console.WriteLine("--------------------------------------");
			Console.ReadKey();


		}
	}
}
