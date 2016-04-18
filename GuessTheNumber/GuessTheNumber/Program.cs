using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    class RandomNumber
    {
        public int selectedNumber,count,Guess,number;
        public static Random rand = new Random();
        public void generateRandomNumber()
        {
            int min=0;
            int max = 100;
            selectedNumber = rand.Next(min, max);
            do
            {               
                number = getNumber();
                GuessNumber(number, selectedNumber);
            }
            while (number != selectedNumber);
            Console.WriteLine("You habe done it in "+count+" Tries");
        }
        public void GuessNumber(int num,int num2)
        {
            if (num > num2)
            {
                Console.WriteLine("Above The Selected Number");
                count++;
                Console.WriteLine("Wrong " + count);
           }
            else if (num < num2)
            {
                Console.WriteLine("Below The Selected Number");
                count++;
                Console.WriteLine("Wrong "+count);
            }
            else
            {
                Console.WriteLine("You Have Got The Right Answer");
            }
 
        }
        public int getNumber()
        {
            Console.WriteLine("Please Enter The Number");
            Guess =Convert.ToInt32(Console.ReadLine());
            return Guess;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            RandomNumber ran = new RandomNumber();
            ran.generateRandomNumber();
            

        }
    }
}
