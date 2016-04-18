using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @delegate
{
    delegate int del1();
    delegate void del2(string s);

    
   public class student
    {
        public int test( )
       { Console.WriteLine("hello buddy"); return 0; }

        public void test1(string s)
        { Console.WriteLine("hello buddy"+ s);  }
    }
    class Program
    {
        
        
        
      public  static void Main(string[] args)
        {
            student stu=new student();
            del2 del=new del2(stu.test1);
            Console.WriteLine("Well "+del);
            
        }
       
    }
}
