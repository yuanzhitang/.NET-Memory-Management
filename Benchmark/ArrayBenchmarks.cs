using BenchmarkDotNet.Attributes;
using System;
using System.Linq;

namespace Benchmark
{
	[MemoryDiagnoser]
	public class ArrayBenchmarks
	{
		private int[] _myArray;

		[Params(100,1000,10000)]
		public int Size { get; set; }

		[GlobalSetup]
		public void Setup()
		{
			_myArray = new int[Size];
			for (var i = 0; i < Size; i++)
			{
				_myArray[i] = i;
			}
		}

		/*Requirement:
		 * 
		 * Taks an array and returns 1/4 of its elements, starting from the middle element
		 * 
		 */

		[Benchmark(Baseline = true)]
		public int[] Original() => _myArray.Skip(Size / 2).Take(Size / 4).ToArray();

		[Benchmark]
		public int [] ArrayCopy()
		{
			var newArray = new int[Size / 4];
			Array.Copy(_myArray, Size / 2, newArray, 0, Size / 4);

			return newArray;
		}

		[Benchmark]
		public Span<int> Span() =>
			_myArray.AsSpan().Slice(Size / 2, Size / 4);

		[Benchmark]
		public int[] SpanReturnArray() => _myArray.AsSpan().Slice(Size / 2, Size / 4).ToArray();

		[Benchmark]
		public int[] BufferBlockCopy()
		{
			var newArray = new int[Size / 4];

			Buffer.BlockCopy(_myArray, Size / 2, newArray, 0, Size / 4);
			//Array.Copy(_myArray, Size / 2, newArray, 0, Size / 4);

			return newArray;
		}
	}
}
