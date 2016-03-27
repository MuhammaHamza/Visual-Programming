using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMine
{
    delegate void Del();
    delegate int del2();
    class Program
    {
        public static void Hello()
        {
            Console.WriteLine("Welcome buddy");
        }
        public static int Goodbye()
        {
            Console.WriteLine("Good Bye");
            return 0;
        }
        public static void geo(Del d)
        {
            Console.WriteLine(d);
        }
        static void Main(string[] args)
        {
            Del de = new Del(Hello);
            Console.WriteLine(de);
            del2 dew = new del2(Goodbye);
            Console.WriteLine(dew);
            geo(de);
        }
    }
}
 