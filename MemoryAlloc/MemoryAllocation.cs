using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
	class MemoryAllocation
	{
		public static void TestString()
		{
			Console.WriteLine("-Test String-");

			string str = "100";

			string str2 = str;

			Console.WriteLine(ReferenceEquals(str, str2));

			str2 = "200";
			Console.WriteLine(ReferenceEquals(str, str2));
			Console.WriteLine($"{str}{Environment.NewLine}{str2}");


			string strA = "A";
			string strB = "B";
			Console.WriteLine(ReferenceEquals(strA, strB));

			strB = "A";
			Console.WriteLine(ReferenceEquals(strA, strB));
		}

		public static void TestInt()
		{
			Console.WriteLine("-Test Int-");

			int num = 10;

			int secNum = num;

			secNum = 20;

			Console.WriteLine($"{num},{secNum}");
		}

		public static void TestArray()
		{
			var array = new int[2] { 1, 2};

			ChangeArray(array);

			string value = string.Join(",", array);
			Console.WriteLine(value);

			var secondArray = array;
			secondArray[0] = 100;

			Console.WriteLine(string.Join(",", array));
			Console.WriteLine(string.Join(",", secondArray));
		}

		public static void ChangeArray(int[] array)
		{
			array[1] = 5;
		}

		public static void ListAllocate()
		{
			if(true)
			{
				int num1 = 10;
			}

			int num2 = 20;
			int num3 = 30;

			//Console.WriteLine(num1);









			int expectedLength = 6;

			var list = new List<int>(expectedLength) { 1, 2, 3, 4 };

			//var student = new Student();

			list.Add(5);
			list.Add(6);
		}

		public void BoxAndUnbox()
		{
			int valueType = 0;
			object referenceType = valueType;//boxing

			valueType = (int)referenceType;//unboxing

			Console.WriteLine(" A few numbers: {0}, {1}. ", 25.ToString(), 32);

			int num = 10;
			string numStr = num.ToString();

			var student = new Student();

			var array = new int[10];

			var num2 = int.Parse(numStr);


			Console.WriteLine(numStr);
		}

		class Student
		{
		}
	}
}
