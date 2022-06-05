using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHeap
{
	public class ValueTypeChecker
	{
		public static void Run()
		{
			int num = 10;
			PrintIsValueTypeFor(num.GetType());

			int[] array = new int[5];
			PrintIsValueTypeFor(array.GetType());
		}

		private static void PrintIsValueTypeFor(Type type)
		{
			Console.WriteLine($"IsValueType:{type.IsValueType} IsByRef:{type.IsByRef}");
		}
	}
}
