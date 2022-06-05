using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryDemo
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var spanDemo = new SpanDemo();

			spanDemo.CompareReadOnlySpan();

			while (true)
			{
				//spanDemo.WithSpan();

				//spanDemo.WithSpanForString();

				//spanDemo.WithSubstringForString();

				//spanDemo.AllocHGlobal();

				//spanDemo.MemoryLeak();
			}

			await NewObjects();

			Console.ReadKey();
		}

		private static async Task NewObjects()
		{
			while (true)
			{
				var stu = new Student()
				{
					Name = "Tom"
				};

				await Task.Delay(1000);
			}
		}
	}
}
