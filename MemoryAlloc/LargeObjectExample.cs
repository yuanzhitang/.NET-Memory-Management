using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace MemoryAllocation
{
	public class LargeObjectExample
	{
		public string NormalString { get; set; } = "Example";
		public byte[] ByteArray85000 = new byte[85000];
		public byte[] ByteArray80000 = new byte[80000];

		public void CompactLargeObject()
		{
			/*.NET Core and .NET Framework (starting with .NET Framework 4.5.1) include the GCSettings.LargeObjectHeapCompactionMode property that allows users to specify that the LOH should be compacted during the next full blocking GC. And in the future, .NET may decide to compact the LOH automatically. This means that, if you allocate large objects and want to make sure that they don’t move, you should still pin them.
			 */
			GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
			GC.Collect();
		}
	}
}
