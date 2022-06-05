using System;
using System.Buffers;

namespace DotNetMemoryDemo
{
	public class ArrayPoolDemo
	{
		public void ArrayPool()
		{
			//定义数组池
			ArrayPool<int> arrayPool = ArrayPool<int>.Create(maxArrayLength: 10000, maxArraysPerBucket: 10);

			//定义使用数组的长度
			int arrayLenght = 5;
			int[] array = arrayPool.Rent(arrayLenght);


			//输出数组的长度
			Console.WriteLine($"定义数组长度：{arrayLenght}，实际数组长度：{array.Length}");


			//对数组进行赋值
			array[0] = 0;
			array[1] = 1;
			array[2] = 2;
			array[3] = 3;
			array[4] = 4;


			//输出数组的值
			foreach (var item in array)
			{
				Console.WriteLine(item);
			}

			//将内存返回给数组池，clearArray设置True清除数组，下次调用时为空，设置False，保留数组，下次调用还是现在的值
			arrayPool.Return(array, clearArray: true);
			foreach (var item in array)
			{
				Console.WriteLine(item);
			}
		}

		public void DoSomeWorkVeryOften()
		{
			var arrayPool = ArrayPool<byte>.Shared;
			var buffer = arrayPool.Rent(1000);

			try
			{
				DoSomethingWithBuffer(buffer);
			}
			finally
			{
				arrayPool.Return(buffer);
			}
		}

		private void DoSomethingWithBuffer(byte[] buffer)
		{
			// use the array
		}
	}
}
