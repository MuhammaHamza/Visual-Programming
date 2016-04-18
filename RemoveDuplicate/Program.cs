using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveDuplicate
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int[] arra = { 1, 2, 3, 4, 5, 4, 3, 21, 1 };
            for (int i = 0; i < arra.Length; i++)                    /////haha I Have done it ;;
            {
                int num1 = arra[i];
                for (int j = 0; j <i; j++)
                {
                    int num2 = arra[j];
                    if (num1 == num2)
                    {
                        arra[i] = 0;
                    }
                }
                Console.WriteLine("Corrected Array :" +arra[i]);
            }
       }
    }
}
