using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixIdentity
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix=new int[100,100];
            int l;
            int h;
            bool chk=false;
            Console.WriteLine("enter The number of rows");
            l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter The number of COLS");
            h = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j <h ; j++)
                {
                    Console.WriteLine("Eter element "+i+""+j+ ":");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < l; i++)
            {
                chk = false;
                for (int j = 0; j < h; j++)
                {
                    if (i == j&&matrix[i,j]==1||i!=j&&matrix[i,j]==0)
                        chk = true;
                    
                }
               
            }
           
            


        }
    }
}
