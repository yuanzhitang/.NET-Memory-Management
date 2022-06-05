using System;
using System.Collections.Generic;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DotNetMemoryDemo
{
	class SpanDemo
	{
		public void CompareReadOnlySpan()
		{
			var byte1 = "ab".AsSpan();
			ReadOnlySpan<char> byte2 = new char[] { 'A', 'b' };

			var byte3 = "ab".AsSpan(1, 1);

			var str1 = byte1.ToString();
			var str2 = byte2.ToString();

			var r = str1 == str2;

			bool result = byte1 == byte2;

			result = byte1.SequenceEqual(byte2);
			var result2 = byte1.SequenceCompareTo(byte2);


			StringBuilder sb = new StringBuilder();
		}


		public void WithSpan()
		{
			var arr = new byte[10];
			Span<byte> bytes = arr; // Implicit cast from T[] to Span<T>

			Span<byte> slicedBytes = bytes.Slice(start: 5, length: 2);
			slicedBytes[0] = 42;
			slicedBytes[1] = 43;
			Assert.Equal(42, slicedBytes[0]);
			Assert.Equal(43, slicedBytes[1]);
			Assert.Equal(arr[5], slicedBytes[0]);
			Assert.Equal(arr[6], slicedBytes[1]);
			//slicedBytes[2] = 44; // Throws IndexOutOfRangeException
			bytes[2] = 45; // OK
			Assert.Equal(arr[2], bytes[2]);
			Assert.Equal(45, arr[2]);
		}

		public void WithSpanForString()
		{
			string str = "hello, world";
			ReadOnlySpan<char> worldSpan = str.AsSpan();

			var worldString = worldSpan.Slice(start: 7, length: 5); // No allocation

			Console.WriteLine(worldString.ToString());
		}

		public void WithSubstringForString()
		{
			string str = "hello, world";
			string worldString = str.Substring(startIndex: 7, length: 5); // Allocates ReadOnlySpan<char> worldSpan =

			Console.WriteLine(worldString);
		}

		public unsafe void AllocHGlobal()
		{
			IntPtr ptr = Marshal.AllocHGlobal(2);
			try
			{
				var bytes = new Span<byte>((byte*)ptr, 2) { [0] = 42 };

				Console.WriteLine(bytes[0]);
				Console.WriteLine(Marshal.ReadByte(ptr));
			}
			finally
			{
				Marshal.FreeHGlobal(ptr);
			}
		}

		private static List<int> staticList = new List<int>();
		private static long count = 0;

		public void MemoryLeak()
		{
			for (int i = 0; i < 10000; i++)
			{
				staticList.Add(i);
			}

			count = count + 10000;

			Console.WriteLine(count);

			Console.WriteLine("Gen0 Collections:" + GC.CollectionCount(0));
			Console.WriteLine("Gen1 Collections:" + GC.CollectionCount(1));
			Console.WriteLine("Gen2 Collections:" + GC.CollectionCount(2));

			//GCSettings.LargeObjectHeapCompactionMode = GCLargeObjectHeapCompactionMode.CompactOnce;
			//GC.Collect();

			//if(staticList.Count>10000)
			//{

			//}
		}

		private async Task SomethingAsync(Memory<byte> data)
		{
			SomethingNotAsync(data.Span.Slice(1));

			await Task.Delay(1000);
		}

		private void SomethingNotAsync(Span<byte> data)
		{
			//Do something
		}

	}

	//class Impossible
	//{
	//	Span<byte> field;
	//}

	ref struct TwoSpans<T>
	{
		public Span<T> first;
		public Span<T> second;
	}
}
