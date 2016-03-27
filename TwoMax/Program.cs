using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arra1 = { 1, 5, 4, 66, 76, 45, 33, 21 };
            int temp;
            int k = arra1.Length;
            for (int j = 0; j <= arra1.Length; j++)
            {
                for (int i = 0; i <arra1.Length-1; i++)
                {
                    if (arra1[i] > arra1[i + 1])
                    {
                        temp = arra1[i+1];
                        arra1[i+1] = arra1[i];
                        arra1[i] = temp;

                    }
                    
                }

            }
            for (int i = 0; i < arra1.Length; i++)
            {
                Console.WriteLine(arra1[i]);
            }

            Console.WriteLine("first Max" + arra1[k-1]);
            Console.WriteLine("Seconed Max" + arra1[k-2]);
            
        }
    }
}
