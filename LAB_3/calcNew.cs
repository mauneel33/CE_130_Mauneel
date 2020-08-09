using System;
using System.Reflection;

[assembly: AssemblyVersion("1.0.0.0")]

namespace calc
{
	public class Calculator
	{
		public long addition(long x, long y)
		{
			Console.WriteLine("New Version");
			return x+y;
		}

		public long multiplication(long x, long y)
		{
			Console.WriteLine("New Version");
			return x*y;
		}
	}
}