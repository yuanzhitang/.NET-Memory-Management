using System;

namespace Leaker
{
	public class StackOverflowSample
	{
		public static void Run()
		{
			try
			{
				int i = 0;
				while (true)
				{
					AllocateBytes(i);

					i++;
				}

				//Span<double> bytes = stackalloc double[200000];
				//Span<byte> bytes = stackalloc byte[1025565];
			}
			catch (Exception)
			{
				// Will not hit
			}

			void AllocateBytes(int i)
			{
				Span<byte> bytes = stackalloc byte[i];

				Console.WriteLine(i.ToString());

				//var bytes = new byte[i];
				//Console.WriteLine("Gen0 Collections:" + GC.CollectionCount(0));
				//Console.WriteLine("======Gen1 Collections:" + GC.CollectionCount(1));
				//Console.WriteLine("=============Gen2 Collections:" + GC.CollectionCount(2));
			}
		}
	}
}
