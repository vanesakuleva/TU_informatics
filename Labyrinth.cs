using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] lab;
            int startX, startY;
            int exitX, exitY;

            using (var f = File.OpenText("lab.txt"))
            {
                int n = int.Parse(f.ReadLine());
                lab = new int[n, n];

                startX = int.Parse(f.ReadLine());
                startY = int.Parse(f.ReadLine());
                exitX = int.Parse(f.ReadLine());
                exitY = int.Parse(f.ReadLine());

                for(int y = 0; y < n; ++y)
                {
                    var valuesStr = f.ReadLine().Split(' ');

                    for (int x = 0; x < n; ++x)
                        lab[y, x] = int.Parse(valuesStr[x]);
                }
            }

            if (FindPath(lab, exitX, exitY, startX, startY))
            {
                Console.WriteLine("EXIT");
            }
            else
                Console.WriteLine("NO PATH");

            Console.ReadLine();
        }

        static bool FindPath(int[,] lab, int currentX, int currentY,
            int exitX, int exitY)
        {
            if (currentX < 0 || currentX >= lab.GetLength(1) ||
                currentY < 0 || currentY >= lab.GetLength(0) ||
                lab[currentY, currentX] != 0)
                return false;

            if (currentX == exitX && currentY == exitY)
            {
                Console.Write("({0}, {1}) -> ",
                    currentX, currentY);
                return true;
            }
            lab[currentY, currentX] = 1;

            if (FindPath(lab, currentX - 1, currentY, exitX, exitY))
            {
                Console.Write("({0}, {1}) -> ",
                    currentX, currentY);
                return true;
            }
            if (FindPath(lab, currentX + 1, currentY, exitX, exitY))
            {
                Console.Write("({0}, {1}) -> ",
                    currentX, currentY);
                return true;
            }
            if (FindPath(lab, currentX, currentY - 1, exitX, exitY))
            {
                Console.Write("({0}, {1}) -> ",
                    currentX, currentY);
                return true;
            }
            if (FindPath(lab, currentX, currentY + 1, exitX, exitY))
            {
                Console.Write("({0}, {1}) -> ",
                    currentX, currentY);
                return true;
            }
            lab[currentY, currentX] = 0;
            return false;
        }
    }
}
