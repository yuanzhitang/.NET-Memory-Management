using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDemo
{
	class Program
	{
		private static Student globalStudent = new Student() { Name = "Static Student", Addresses = Get3KBString() };
		static async Task  Main(string[] args)
		{
			//GCCollect();
			//GCCollectWhenAllocateObjects();
			PrintStudentGC(globalStudent);

			await AllocateManyObjects();

			Console.ReadKey();
		}

		private static async Task AllocateManyObjects()
		{
			await Task.Run(() =>
			{
				while (true)
				{
					PrintGCTotalMemory(true); //21946Bytes

					PrintStudentGC(globalStudent);

					var student = new Student() { Name = "Stu1", Addresses = Get3KBString() };

					Console.WriteLine($"Gen: {GC.GetGeneration(student)}");
				}
			});
		}

		private static void GCCollectWhenAllocateObjects()
		{
			PrintGCTotalMemory(true); //21946Bytes

			var student = new Student() { Name = "Stu1" };

			Console.WriteLine($"Gen: {GC.GetGeneration(student)}");

			PrintGCTotalMemory();

			var stu2 = new Student()
			{
				Name = "Stu2",
				Addresses = Get3KBString()
			};

			Console.WriteLine("New Stu 2 with Large strings");
			//GC.Collect();

			PrintGCTotalMemory();
			PrintStudentGC(student);
			PrintStudentGC(stu2);

			Console.WriteLine("GC.Collect(1)...");
			GC.Collect(1);

			PrintStudentGC(student);
			PrintStudentGC(stu2);
		}

		private static void PrintStudentGC(Student student)
		{
			Console.WriteLine($"Name:{student.Name}, Gen: {GC.GetGeneration(student)}");
		}

		private static List<string> Get3KBString()
		{
			int len = 10 * 1024;
			var list = new List<string>(len);
			for (int i = 0; i < len; i++)
			{
				list.Add("a");
			}

			return list;
		}

		private static void GCCollect()
		{
			PrintGCTotalMemory(true); //21946Bytes

			var student = new Student();

			Console.WriteLine($"Gen: {GC.GetGeneration(student)}");

			PrintGCTotalMemory();

			Console.WriteLine("GC.Collect()...");
			GC.Collect();

			PrintGCTotalMemory();
			Console.WriteLine($"Gen: {GC.GetGeneration(student)}");

			Console.WriteLine("GC.Collect(1)...");
			GC.Collect(1);

			Console.WriteLine($"Gen: {GC.GetGeneration(student)}");
		}

		private static long PrintGCTotalMemory(bool forceFullCollection = false)
		{
			long initMemory = GC.GetTotalMemory(forceFullCollection);
			Console.WriteLine($"GC: {initMemory} bytes: {initMemory / (1024 * 1024)} MB");
			return initMemory;
		}
	}
}
