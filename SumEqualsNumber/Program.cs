using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEqualsNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 16;
            int[] numarr = { 6, 12, 4, 10, 0, 16 };
            int aja=0;
            int jaja = 0;
            bool check;
            for (int i = 0; i < numarr.Length; i++)
            {
                check = false;
                aja = numarr[i];
                for (int j = 0; j < numarr.Length; j++)
                {
                    jaja = numarr[j];
                    if (aja + jaja == number)
                    {
                        Console.WriteLine("first Number  :" + aja + "  :::Seconed Number :" + jaja);
                    }
                   
                 }
            }
        }
    }
}
