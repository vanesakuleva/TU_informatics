using System;

using System.IO;

namespace exMatrix

{

    class Program

    {

        static void Main(string[] args)

        {



            var file = File.OpenText("textFile.txt");

            var rows = int.Parse(file.ReadLine());

            var cols = int.Parse(file.ReadLine());

            var matrix = new decimal[rows, cols];





            for (int row = 0; row < rows; row++)

            {

                var lines = file.ReadLine().Split(' ');



                for (int col = 0; col < cols; col++)

                    matrix[row, col] = decimal.Parse(lines[col]);





                Console.ReadLine();

            }
            PrintMatrix(matrix);

            Console.WriteLine(SumOfNegativeOnAntiDIagonal(matrix));

            SortMatrix(matrix);

        }

        static void SortMatrix(decimal[,] matrix)

        {

            for (int col = 1; col < matrix.GetLength(1); col++)

            {

                bool sorted = true;

                do

                {

                    for (int row = 1; row < matrix.GetLength(0); row++)

                    {

                        if ((col % 2 != 0 && matrix[row - 1, col] < matrix[row, col]) || (col % 2 == 0 && matrix[row - 1, col] > matrix[row, col]))

                        {

                            var t = matrix[row - 1, col];

                            matrix[row - 1, col] = matrix[row, col];

                            matrix[row, col] = t;



                            sorted = false;
                        }
                    }
                }

                while (!sorted);
            }
        }

        static decimal SumOfNegativeOnAntiDIagonal(decimal[,] matrix)

        {

            if (matrix.GetLength(0) != matrix.GetLength(1))

                throw new InvalidOperationException();
            decimal sum = 0;

            for (int row = 0, col = matrix.GetLength(1) - 1; row < matrix.GetLength(0); row++, col--)
            {

                if (matrix[row, col] < 0)

                    sum += matrix[row, col];
            }
            return sum;
        }
        static void PrintMatrix(decimal[,] matrix)

        {

            for (int row = 0; row < matrix.GetLength(0); row++)

            {

                for (int col = 0; col < matrix.GetLength(1); col++)

                    Console.Write($"{matrix[row, col]}\t");

                Console.WriteLine();

            }



        }
        static bool CheckIdentity(decimal[,] matrix)

        {

            if (matrix.GetLength(0) != matrix.GetLength(1))

                throw new InvalidOperationException();



            bool isIdentity = true;

            for (int row = 0; row < matrix.GetLength(0); row++)



                for (int col = 0; col < matrix.GetLength(1); col++)

                {

                    if ((row == col && matrix[row, col] != 1) ||

                        (row != col && matrix[row, col] != 0))

                    {

                        isIdentity = false;

                        break;

                    }
                }

            return isIdentity;

        }
    }
}