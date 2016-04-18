using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casting
{
    class Implici
    {
        public int a;
       public Implici()
        { }
        public int geta()
        {
            return a;
        }
    }
    class Explici:Implici
    {
        public int b;
       public Explici()
        {
 
        }
        public int getb()
        {
            return b;
        }
    }
    struct Implicit1
    {
        public int c;
        public int getc()
        {
            return c;
        }

    };
    struct Explixit1
    {
        public int d;
        public int getd()
        {
            return d;
 
        }

 
    };
    class Program
    {
        static void Main(string[] args)
        {
            Object ob1 = new object();
            Explici ex = new Explici();
            Implici im=new Implici();
             ob1=im;
            Implicit1 im1=new Implicit1();
            Explixit1 ex1;
            ex = (Explici)im;           //Explicit     assigining child to parent (Only via casting)
            im = ex;                   //Imlicit       asssiging parent to child 
            int d=(int)im.geta();
            d=(int)im1.getc();

                   
        }
    }
}
