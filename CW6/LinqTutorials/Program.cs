using LinqTutorials.Models;
using System;
using System.Collections.Generic;

namespace LinqTutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*");
            IEnumerable<Emp> t = LinqTasks.Task1();
            foreach (Emp x in t)
            {
                Console.WriteLine(x.ToString());
            }
            IEnumerable<Emp> t2 = LinqTasks.Task2();
            foreach (Emp x in t2)
            {
                Console.WriteLine(x.ToString());
            }

        }
    }
}
