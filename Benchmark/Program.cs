using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
	public class Program
	{
		static void Main(string[] args)
		{
			//BenchmarkRunner.Run<NameParserBenchmarks>();
			//BenchmarkRunner.Run<ArrayBenchmarks>();
			//BenchmarkRunner.Run<ConcatMultiStringsBenchmarks>();
			BenchmarkRunner.Run<ConcatTwoStringsBenchmarks>();
		}
	}
}
