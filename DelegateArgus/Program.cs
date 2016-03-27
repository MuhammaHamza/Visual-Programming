using DelegateArgus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateArgus
{
    public delegate void del();
     public delegate int del2();
     public delegate int del3(int i);
     public delegate int del4(int i,int k);
   public  class diff
    {
        public int name()
        {
          int temp=10;
            return 
                temp;
        }
        public int naem(int u)
        {
            return u*2;
        }
        public int hola(int k,int g)
        {
            return k+g;
        }
     
   
    }
    
    }
    class Program
    {
        public static void hello()
        {
            Console.WriteLine(  "Hello Buddy");
        }

        public static void Goodbye()
        {
            Console.WriteLine("GoodBye Buddy");
        }
        public static void inter(del2 dre)
        {
            Console.WriteLine(dre());
        }
        static void Main(string[] args)
        {
           del der = hello;
            der += Goodbye;
            der();
                diff df=new diff();
           del2 der2=df.name;
           Console.WriteLine("del  2 :" + der2()); 
            del3 dre3=df.naem;
            inter(der2);
            Console.WriteLine("del 3:" + dre3(11)); 
                del4 dre4=df.hola;
                Console.WriteLine("Del 4:" + dre4(12, 23)); 
            
        }
    }
