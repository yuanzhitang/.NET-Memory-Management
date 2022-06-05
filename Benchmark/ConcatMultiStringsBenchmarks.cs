using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
	[MemoryDiagnoser]
	public class ConcatMultiStringsBenchmarks
	{
		private string[] _myArray;

		[Params(2, 5, 50, 100)]
		public int Size { get; set; }

		public int Capacity { get; set; }

		[GlobalSetup]
		public void Setup()
		{
			_myArray = new string[Size];
			Capacity = 0;
			for (var i = 0; i < Size; i++)
			{
				var str = i.ToString();
				_myArray[i] = str;
				Capacity += str.Length;
			}
		}

		[Benchmark(Baseline = true)]
		public string Original()
		{
			var str = string.Empty;

			for (int i = 0; i < _myArray.Length; i++)
			{
				str += _myArray[i];
			}

			return str;
		}

		[Benchmark]
		public string Concat()
		{
			var str = string.Empty;

			for (int i = 0; i < _myArray.Length; i++)
			{
				str = string.Concat(str, _myArray[i]);
			}

			return str;
		}

		[Benchmark]
		public string StringBuilder()
		{
			var stringBuilder = new StringBuilder();
			for (int i = 0; i < _myArray.Length; i++)
			{
				stringBuilder.Append(_myArray[i]);
			}

			return stringBuilder.ToString();
		}

		[Benchmark]
		public string StringBuilderFixedLength()
		{
			var stringBuilder = new StringBuilder(Capacity);
			for (int i = 0; i < _myArray.Length; i++)
			{
				stringBuilder.Append(_myArray[i]);
			}

			return stringBuilder.ToString();
		}

		[Benchmark]
		public string Join()
		{

			return string.Join("", _myArray);
		}
	}
}
