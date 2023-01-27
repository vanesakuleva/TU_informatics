using System;
using System.Reflection;

namespace recursionAndIterationWay
{
    class Program

    {
        private static int Recursive(int n,int counter)
        {
            if (n == 1)
         
                return counter;

            else
                counter += 1;
            {
                if (n % 2 == 0)
                {
                    
                    return Recursive(n / 2, counter);
                }
                else
                {
                    
                    return Recursive(n * 3 + 1, counter);
                }
            }

        }
        private static int Iterative(int n)
        {
            var counter = 0;


            while (n != 1)
            {

                if (n % 2 == 0)
                {
                    n = n / 2;
                    counter += 1;

                }
                else
                {
                    n = n * 3 + 1;
                    counter += 1;

                }
            }
            return counter;


        }
        static void Main(string[] args)
        {
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine(Iterative(x));

            Console.WriteLine(Recursive(x, 0));
            Console.ReadKey();
        }
    }
}

