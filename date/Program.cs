using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace date
{

    class Program
    {
        public string[] age = new string[100];
        public DateTime[] dt = new DateTime[100];
        public DateTime dt1 = DateTime.Today;
        public int sib;


        public void GetAge()
        {
            Console.Write("Please Enter Number OF siblings  :");
            sib = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < sib; i++)
            {
                Console.Write("Please Input the date of Sibling :" + (i + 1) + " in the following Format 'Mon/Day/Year' :");
                age[i] = Console.ReadLine();
                dt[i] = Convert.ToDateTime(age[i]);

            }
        }
        public void AgeYears()
        {
            
            for (int i = 0; i < sib; i++)
            {
                //if (dt[i] > dt[i + 1])
                //{
                //    DateTime temp;
                //    temp=dt[i];
                //    dt[i]=dt[i + 1] ;
                //    dt[i + 1] = temp;

                //}
                TimeSpan tf2 = dt1.Subtract(dt[i]);
                int t2 = tf2.Days;
                int dt212 = t2 / 365;
                int dt213 = (t2 % 365) / 30;
                int dt214 = (t2 % 365) % 30;
                Console.WriteLine("Age Of Sibling :" + (i + 1) + ":" + Math.Abs(dt212) + " Years " + Math.Abs(dt213) + " Months " + Math.Abs(dt214) + " Days ");

            }
        }

        public void AgeDiff()
        {
            for (int i = 0; i < sib - 1; i++)
            {

                Console.Write("Difference between Sibling :" + (i + 1) + " and " + (i + 2) + ":");
                TimeSpan tf = dt[i].Subtract(dt[i + 1]);
                int t = tf.Days;
                int dt212 = t / 365;
                int dt213 = (t % 365) / 30;
                int dt214 = (t % 365) % 30;
                Console.WriteLine(+Math.Abs(dt212) + " Years " + Math.Abs(dt213) + " Months " + Math.Abs(dt214) + " Days ");

            }
        }
        static void Main(string[] args)
        {
            try
            {
                Program pro = new Program();
                pro.GetAge();
                Console.WriteLine("-------------------------------------------------------------------");
                pro.AgeYears();
                Console.WriteLine("-------------------------------------------------------------------");
                pro.AgeDiff();

            }
            catch
            {
                Console.WriteLine("Enter The Valid Date");
            }


        }

    }
}
