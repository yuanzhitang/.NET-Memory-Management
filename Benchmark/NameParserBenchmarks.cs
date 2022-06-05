using BenchmarkDotNet.Attributes;

namespace Benchmark
{
	[MemoryDiagnoser]
	public class NameParserBenchmarks
	{
		private const string FullName = "Jim Tom";
		private static readonly NameParser Parser = new NameParser();

		[Benchmark]
		public void GetLastName()
		{
			Parser.GetLastName(FullName);
		}
	}

	internal class NameParser
	{
		internal string GetLastName(string fullName)
		{
			var names = fullName.Split(' ');

			return names[1];
		}
	}
}
