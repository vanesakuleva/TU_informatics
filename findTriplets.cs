using System;

namespace findTriplets
{
    class Program

    {
        private static void FindTriplets(int [] nums)
        {

            for (int i = 0; i < nums.Length-2; i++)
            {
                for (int j = i + 1; j < nums.Length-1; j++)
                {
                    for (int k = j + 1; k < nums.Length; k++)
                    {

                        if (nums[i] == nums[k] && nums[k] == nums[j])

                            Console.WriteLine($"{i}, {j}, {k}");
                    }
                }
            }
             
        }
        static void Main(string[] args)
        {
            int[] triplets = { 1, 2, 3, 1, 1, 1, 2, 2 };
            FindTriplets(triplets);
            Console.ReadKey();
        }
    }
}

