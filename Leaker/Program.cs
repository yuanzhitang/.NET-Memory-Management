using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Leaker
{
	class Program
	{
		static void Main(string[] args)
		{
			OutOfMemorySample.Run();
			//StackOverflowSample.Run();
		}
	}
}
