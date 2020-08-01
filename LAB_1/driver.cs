using System;
using calc;

namespace demo
{
	public class DriverDemo
	{
		static void Main(string[] args)
		{
			Addition a = new Addition();
			string temp;
			int x, y;
			Console.WriteLine("Enter the 1st number:");
			temp = Console.ReadLine();
			x = Convert.ToInt32(temp);
			Console.WriteLine("Enter the 2nd number:");
			temp = Console.ReadLine();
			y = Convert.ToInt32(temp);
			Console.WriteLine("Addition : {0}",a.add(x,y));
			Console.ReadKey();
		}
	}
}