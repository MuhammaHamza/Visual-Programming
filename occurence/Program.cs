using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace occurence
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "hellolleo";
            char c = 'o';
            int count=0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (c == str1[i])
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
