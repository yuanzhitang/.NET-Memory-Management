using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
	[MemoryDiagnoser]
	public class ConcatTwoStringsBenchmarks
	{
		private string Hello = "Hello";
		private string World = "World";

		[Benchmark(Baseline = true)]
		public string Original()
		{
			return Hello + World;
		}

		[Benchmark]
		public string Concat()
		{
			return string.Concat(Hello, World);
		}

		[Benchmark]
		public string StringBuilder()
		{
			var stringBuilder = new StringBuilder();
			stringBuilder.Append(Hello);
			stringBuilder.Append(World);

			return stringBuilder.ToString();
		}

		[Benchmark]
		public string StringBuilderFixedLength()
		{
			var stringBuilder = new StringBuilder(Hello.Length+World.Length);
			stringBuilder.Append(Hello);
			stringBuilder.Append(World);

			return stringBuilder.ToString();
		}

		[Benchmark]
		public string Dollar()
		{
			return $"{Hello}{World}";
		}

		[Benchmark]
		public string StringFormat()
		{
			return string.Format("{0}{1}", Hello, World);
		}

		[Benchmark]
		public string Join()
		{
			return string.Join("", new string[] { Hello, World });
		}

		[Benchmark]
		public string StringFormatInt()
		{
			return "a" + 100;
		}

		[Benchmark]
		public string StringFormatToString()
		{
			return "a" + 100.ToString();
		}
	}
}
