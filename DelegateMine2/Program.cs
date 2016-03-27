using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateMine2
{
    public delegate void DEL(int a,int b);
    class Program
    {
        public static void add(int a, int b)
        {
            Console.WriteLine("Addition :"+(a+b));
        }
        public static void sub(int a, int b)
        {
            Console.WriteLine("Subtraction :" + (a - b));
        }
        public static void mul(int a, int b)
        {
            Console.WriteLine("Multiplication :" + (a * b));
        }
        static void Main(string[] args)
        {
            DEL der = add;
            der += sub;
            der += mul;
            der(10, 12);
        }
    }
}
