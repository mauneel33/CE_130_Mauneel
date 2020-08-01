using System;

namespace calc
{
	public class Add
	{
		static void Main(string[] args)
		{
			string temp;
			int a, b;
			Console.WriteLine("Enter the 1st number:");
			temp = Console.ReadLine();
			a = Convert.ToInt32(temp);
			Console.WriteLine("Enter the 2nd number:");
			temp = Console.ReadLine();
			b = Convert.ToInt32(temp);
			Console.WriteLine("Addition : {0}",a+b);
			Console.ReadKey();
		}
	}
}