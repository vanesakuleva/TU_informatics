using System;
using System.IO;


namespace vanesa
{
    class Program

    {
        static void Main(string[] args)
        {
            string[] textFromFile = File.ReadAllLines("matrix.txt");



            int rows;
            rows = textFromFile.Length;

            string matrix = File.ReadAllText("matrix.txt");


            int i = 0, j = 0;
            int[,] result = new int[rows, rows];

            foreach (string row in matrix.Split('\n'))
            {
                j = 0;
                foreach (string col in row.Trim().Split(' '))
                {
                    result[i, j] = int.Parse(col.Trim());
                    j++;

                }
                i++;

            }
            int r=0 , c=0 ;
            int sumOfRows = 0;
            int sumOfCols = 0;

            for (r = 0; r <rows; r++)
                for (c = 0;c < rows; c++)
            {
                    if (r % 2 == 0)
                        if (result[r, c] % 2 == 0)
                            sumOfRows += result[r, c];
                    if (c %2 != 0)
                        if (result[r, c] % 2 != 0)
                            sumOfCols += result[r, c];
                }
            Console.WriteLine($"Sum of the even nums on the odd rows: {sumOfRows}");
            Console.WriteLine($"Sum of the odd nums on the even rows: {sumOfCols}");
            Console.ReadKey();
        }
    }




}       
  
