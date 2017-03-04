using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tempest_Questoes
{
    class Questoes
    {
        static void Main(string[] args)
        {
            
            Question01();

            Question02();
            
            Question03();
        }

        private static void Question01()
        { 
            int number;
            int minLocal = 0;
            int arrayLimit;
            int maxValue;
            int maxIndex;

            Console.WriteLine("Question 01 - Maximum Difference in a Array");

            Console.WriteLine("Define the array limit");
            
            //validate input 
            while ((!Int32.TryParse(Console.ReadLine(), out arrayLimit)) || (arrayLimit < 1 || arrayLimit > 1000000)) { }
    
            //define the array
            int[] array = new int[arrayLimit];
            Console.WriteLine("Define the numbers");
            

            //populate the array
            for (int cont = 0; cont < arrayLimit; cont++)
            {
                //validate input
                while (!Int32.TryParse(Console.ReadLine(), out number) || (number < -1000000 || number > 1000000)) { }
                //populate the array
                array[cont] = number;
            }

            maxValue = array.Max();
            maxIndex = array.ToList().IndexOf(maxValue);

            for (int cont = 0; cont < maxIndex; cont++)
            {
                if (cont != 0 && (array[cont] < array[minLocal]))
                {
                    minLocal = cont;
                }
            }

            //response
            Console.WriteLine("Maximum Difference {0}", (maxValue - array[minLocal]));
            //read a key to continue
            Console.ReadKey();
            
        }


        private static void Question02()
        {
            Console.WriteLine("Question 02 - Permutations divisible by 8");
            Console.WriteLine("Please enter the number of test cases");

            int testCases;
            double permutate;
            string divisible;
            double[] arrayRandomizer;
            double permutationRandomized;

            //validate the number to the test cases
            while (!Int32.TryParse(Console.ReadLine(), out testCases) || (testCases < 1 || testCases > 45)){}

            Console.WriteLine("Please enter a number to be tested");

            do {
                testCases--;
                //define the divisible to be NO agains
                divisible = "NO";

                //read the number
                while (!Double.TryParse(Console.ReadLine(), out permutate)) { }
                //check if the number itself is divisible
                if (permutate % 8 == 0)
                {
                    // if it is the gave the response on the moment
                    divisible = "YES";
                    Console.WriteLine(divisible);
                    break;
                }
                //convert all the numbers individually to an array cleaning the toString ascii
                arrayRandomizer = Array.ConvertAll(permutate.ToString().ToArray(), x => (double)x - 48);
                
                //randon generator to the permutation generator
                Random rnd = new Random();
                
                //iteration Lenght^2
                for(int i = 0; i < (arrayRandomizer.Length* arrayRandomizer.Length); i++)
                {
                    //randomize the order of the number creating a permutation
                    arrayRandomizer = arrayRandomizer.OrderBy(x => rnd.Next()).ToArray();
                    //transform the array into a double
                    Double.TryParse(string.Join("", arrayRandomizer), out permutationRandomized);
                    if(permutationRandomized % 8 == 0)
                    {
                        divisible = "YES";
                        break;
                    }
                }

                Console.WriteLine(divisible);

            } while (testCases != 0);

            //read a key to continue
            Console.ReadKey();
        }


        private static void Question03()
        {
            Console.WriteLine("Question 03 - 4th Bit");
            Console.WriteLine("Please enter the number");

            int value;

            //read the integer only allowing integer 32 bits
            while (!Int32.TryParse(Console.ReadLine(), out value)){ }

            //shift right 3 bits, letting the 4th bit now be the one that defines an odd or even number
            // then just pick the bit
            value = (value >> 3) % 2;
            Console.WriteLine("The 4th bit is {0}", value);

            //read a key to continue
            Console.ReadKey();
        }
        
    }
}
