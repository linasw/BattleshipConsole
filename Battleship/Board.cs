using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        public static void DrawBoard(List<List<char>> grid)
        {
            Console.Write("  | ");
            for (int p = 0; p < grid[0].Count(); p++)
            {
                Console.Write($"{p} ");
            }
            Console.WriteLine();
            Console.WriteLine("--+--------------------");

            int i = 0;

            foreach (var sublist in grid)
            {
                Console.Write(i.ToString() + " | ");
                foreach (var value in sublist)
                {
                    Console.Write(value + " ");
                }
                Console.WriteLine();
                i++;
            }
        }
    }
}
