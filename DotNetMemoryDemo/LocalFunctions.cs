using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetMemoryDemo
{
	class LocalFunctions
	{
        private static void Process(string[] lines, string mark)
        {
            foreach (var line in lines)
            {
                if (IsValid(line))
                {
                    // Processing logic...
                }
            }

            bool IsValid(string line)
            {
                return !string.IsNullOrEmpty(line) && line.Length >= mark.Length;
            }
        }
    }
}
