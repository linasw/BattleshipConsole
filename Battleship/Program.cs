using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y, a, b;
            string result;
            Board board = new Board();
            Player player = new Player();
            BotPlayer botPlayer = new BotPlayer();
            ShipController shipController = new ShipController();

            Console.WriteLine("Welcome to battleships!");
            Console.WriteLine();
            Console.WriteLine("Let's start with planting your ships.");
            board.DrawBoard(player.GetYourGrid());
            Console.WriteLine("Enter starting position of your ship");
            Console.WriteLine("Enter x");
            result = Console.ReadLine();
            int.TryParse(result, out x);
            Console.WriteLine("Enter y");
            result = Console.ReadLine();
            int.TryParse(result, out y);
            Console.WriteLine("Enter ending position of your ship");
            Console.WriteLine("Enter x");
            result = Console.ReadLine();
            int.TryParse(result, out a);
            Console.WriteLine("Enter y");
            result = Console.ReadLine();
            int.TryParse(result, out b);

            int addShipsResult = shipController.AddShip(x, y, a, b);

            if (addShipsResult != 0)
            {
                if (addShipsResult == 1)
                    Console.WriteLine("Ship can't be placed diagonally");
                else if (addShipsResult == 2)
                    Console.WriteLine("Ship's length can't be equal 1");
                else if (addShipsResult == 3)
                    Console.WriteLine("Ship can't be placed on occupied tile");
                else if (addShipsResult == 4)
                    Console.WriteLine("Unknown error");

                Console.ReadKey();
                return;
            }
                
            player.InitialSetGridWithShip(shipController.GetGrid());
            botPlayer.InitialSetGridWithShip(shipController.GetGrid());

            while (true)
            {
                Console.WriteLine("Here's your board");
                board.DrawBoard(player.GetYourGrid());
                Console.WriteLine("Your enemy's board");
                board.DrawBoard(player.GetEnemyGrid());
                Console.WriteLine("\nNow shoot!");
                Console.WriteLine();
                Console.WriteLine("Enter x");
                result = Console.ReadLine();
                int.TryParse(result, out x);
                Console.WriteLine("Enter y");
                result = Console.ReadLine();
                int.TryParse(result, out y);
                player.Shoot(botPlayer, x, y);
            }

            Console.ReadKey();
        }
    }
}
