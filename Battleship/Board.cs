using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        public static void DrawBoard(char[,] grid)
        {
            Console.WriteLine("  | 0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("--+--------------------");

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i.ToString() + " | ");
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i, j] + " "); 
                }
                Console.WriteLine();
            }
        }
    }
}
