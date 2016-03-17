using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Multiplication
{
    class Multiplication
   {
        public int row1, row2,col1,col2,col3,row3;
        public int[][] Array1;
        public int[][] Array2;
        public int[][] Array3;
        public void input1()
        {
            Console.WriteLine("Enter Number Of rows");
            row1 = Console.Read();
            Console.WriteLine("Enter number Of columns");
            col1 = Console.Read();
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    Console.WriteLine("Enter Element :" + i + " " + j);
                    Array1[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
 
        }
        public void input2()
        {
            Console.WriteLine("Enter Number Of rows");
            row2 = Console.Read();
            Console.WriteLine("Enter number Of columns");
            col2 = Console.Read();
            for ( int i = 0; i < row2; i++)
            {
                for (int j = 0; j < col2; j++)
                {
                    Console.WriteLine("Enter Element :"+i+" "+j);
                    Array2[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

        }

        public void multiply()
        {
            if (row1 != col2)
            {
                Console.WriteLine("Number Of Rows Is Not Equals To Column");
            }
            else
            {
                Array3[row3][col3] = (Array1[row1][col1] * Array2[row2][col2]) + Array3[row3][col3];
            }


        }

        public void Execute()
        {
            do
            {
                input1();
                input2();
            } while (row1!=col2);
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
