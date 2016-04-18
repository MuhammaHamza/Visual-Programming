using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathematicalfunc
{
    class Program
    {
        public static void func1()
        {
            int num = 0;
            int power = 0;
            Console.WriteLine("enter number");
            num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter Power");
            power = Convert.ToInt32(Console.ReadLine());
            double i = Math.Pow(num, power);
            Console.WriteLine(i);
        }
        static void Main(string[] args)
        {
            //func1();
            int[][] jagg=new int[10][];
            jagg[0] = new int[]{1,2,3,4,5,6,};
            jagg[5]=new int[]{2};
            Console.WriteLine("jagged"+jagg);



            
        }
    }
}
