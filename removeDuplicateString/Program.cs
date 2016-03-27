using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace removeDuplicateString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "helo olaf";
            char[] arra = str.ToCharArray();
            for (int i = 0; i < arra.Length; i++)
            {
                for (int j = 0; j <i; j++)
                {
                    if (arra[i] == arra[j])
                    {
                        arra[i] = '_'; 
                    }
                }
                Console.WriteLine(arra[i]);
            }
            string s = new string(arra);
            Console.WriteLine(s);
        }
    }
}
