using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jagged_array
{
    class Program
    {

        public static void jagg(params int[] arra)
        {
            for (int i = 0; i < arra.Length; i++)
            {
                if (i == 3)
                    continue;
                Console.WriteLine(arra[i] += arra[i]);
            }
        }
        public static void Obj(params Object[] obj1)
        {
            foreach (var item in obj1)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            jagg(10, 20,30,40,50); 

            Obj("hello",67,'f',876);
            int[][,] jaggede = new int[3][,] { new int[,] { { 1, 3 }, { 5, 7 } },
                                new int[,] { { 0, 2 }, { 4, 6 }, { 8, 10 } },
                                new int[,] { { 11, 22 }, { 99, 88 }, { 0, 9 } }
            };
            for (int i = 0; i < jaggede.Length; i++)               /// Rola Pay Gaya (did not understood)
            {
                for (int k = 0; k <i ; k++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        Console.WriteLine(jaggede[i][k,j]);
                    }
                }
            }
            
            
        }
    }
}
