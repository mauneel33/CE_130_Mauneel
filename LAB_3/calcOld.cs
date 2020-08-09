using System;
using System.Reflection;

[assembly: AssemblyVersion("0.0.0.0")]

namespace calc
{
	public class Calculator
	{
		public int addition(int x, int y)
		{
			return x+y;
		}

		public int multiplication(int x, int y)
		{
			return x*y;
		}
	}
}