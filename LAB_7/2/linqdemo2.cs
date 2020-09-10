using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQdemo1_2
{
    class linqdemo2
    {
        static void Main(string[] args)
        {
            List<string> namelist = new List<string>();
            namelist.Add("John");
            namelist.Add("Usha");
            namelist.Add("Rock");
            namelist.Add("Adi");
            namelist.Add("Sid");
            namelist.Add("James");
            namelist.Add("Kabir");
            namelist.Add("M");
            namelist.Add("Kai");
            namelist.Add("Si");

            var knames = namelist.Where(s=>s[0] == 'K');
            Console.WriteLine("The names starting with 'K' are:");
            foreach (string s in knames)
                Console.Write(s+"\t");
            Console.WriteLine("\n");

            var names1 = namelist.Where(s => s.Length<4);
            Console.WriteLine("The names with length less than 4 are:");
            foreach (string s in names1)
                Console.Write(s + "\t");
            Console.WriteLine("\n");

            var names2 = namelist.Where(s => s.Length == 3);
            Console.WriteLine("The names with length equal to 3 are:");
            foreach (string s in names2)
                Console.Write(s + "\t");
            Console.WriteLine("\n");

            var ascnames = namelist.OrderBy(s=>s);
            Console.WriteLine("The names in ascending order : ");
            foreach (string s in ascnames)
                Console.Write(s + "\t");
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
