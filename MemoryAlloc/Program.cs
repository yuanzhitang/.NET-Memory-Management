using MemoryAllocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAlloc
{
	class Program
	{
		static void Main(string[] args)
		{
			var largeObj = new LargeObjectExample();

			Console.WriteLine(GC.GetGeneration(largeObj));
			Console.WriteLine(GC.GetGeneration(largeObj.NormalString));
			Console.WriteLine(GC.GetGeneration(largeObj.ByteArray85000));
			Console.WriteLine(GC.GetGeneration(largeObj.ByteArray80000));

			Console.ReadKey();
		}
	}
}
