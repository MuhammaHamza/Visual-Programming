using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAllInOne       ///First Non Repeated Character
{
    
    class Program
    {
        static void Main(string[] args)
        {

           
            String str1 = "helloh";
            char[] arra2 = new char[100];
            bool check;
            char[] arra1 = str1.ToCharArray();
            for (int i = 0; i < str1.Length; i++)
            {
                check = false;
                for (int j = 0; j < str1.Length; j++)
                {
                    if (arra1[i] == str1[j] && i!=j) ///Rola (Saray Non Repeated Character return krta hai)
                    {
                        check = true;
                        break;
                    }
                }

                if (!check)
                {
                    
                    Console.WriteLine(arra1[i]);
                }
            }
            //Console.WriteLine(arra2[0]);
        }
        
    }
}
