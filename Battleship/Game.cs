using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Game
    {
        Globals globals;
        Random random;
        Board board;
        Player player;
        BotPlayer botPlayer;
        ShipController shipController;

        public Game()
        {
            globals = new Globals();
            random = new Random();
            board = new Board();
            player = new Player(globals.BoardWidth, globals.BoardHeight);
            botPlayer = new BotPlayer(globals.BoardHeight, globals.BoardWidth);
            shipController = new ShipController(globals.BoardWidth, globals.BoardHeight);
        }

        public void StartGame()
        {
            WelcomeMessage();
            PlantShips();
            Console.Clear();
            while(true)
            {
                PlayerShoot();
                if (IsWinningShot(player))
                {
                    WonMesssage();
                    break;
                }
                BotShoot();
                if (IsWinningShot(botPlayer))
                {
                    LostMessage();
                    break;
                }
            }
        }

        private void WelcomeMessage()
        {
            Console.WriteLine("Welcome to battleships!");
            Console.WriteLine();
            Console.WriteLine("Let's start with planting your ships.");
        }

        private void WonMesssage()
        {
            Console.WriteLine("Here's your board");
            Board.DrawBoard(player.Grid);
            Console.WriteLine("Your enemy's board");
            Board.DrawBoard(player.EnemyGrid);
            Console.WriteLine("You won!");
            Console.WriteLine("!!! CONGRATULATIONS !!!");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private void LostMessage()
        {
            Console.WriteLine("Here's your board");
            Board.DrawBoard(player.Grid);
            Console.WriteLine("Your enemy's board");
            Board.DrawBoard(player.EnemyGrid);
            Console.WriteLine("You lost :(");
            Console.WriteLine("!!! BETTER LUCK NEXT TIME !!!");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private void PlantShips()
        {
            Board.DrawBoard(player.Grid);
            Console.WriteLine("Enter starting position of your ship");
            Console.WriteLine("Enter x");
            string readLineResult = Console.ReadLine();
            if (!int.TryParse(readLineResult, out int x))
            {
                Console.WriteLine("It's not a number!");
                Console.WriteLine("Press any key to exit the game...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Enter y");
            readLineResult = Console.ReadLine();
            if (!int.TryParse(readLineResult, out int y))
            {
                Console.WriteLine("It's not a number!");
                Console.WriteLine("Press any key to exit the game...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Enter ending position of your ship");
            Console.WriteLine("Enter x");
            readLineResult = Console.ReadLine();
            if (!int.TryParse(readLineResult, out int a))
            {
                Console.WriteLine("It's not a number!");
                Console.WriteLine("Press any key to exit the game...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Enter y");
            readLineResult = Console.ReadLine();
            if (!int.TryParse(readLineResult, out int b))
            {
                Console.WriteLine("It's not a number!");
                Console.WriteLine("Press any key to exit the game...");
                Console.ReadKey();
                Environment.Exit(0);
            }

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
            player.Grid = new List<List<char>>(shipController.Grid);
            botPlayer.Grid = new List<List<char>>(shipController.Grid);
            player.SetWinningShotNumber(x, y, a, b);
            botPlayer.SetWinningShotNumber(x, y, a, b);
        }

        private void PlayerShoot()
        {
            Console.WriteLine("Here's your board");
            Board.DrawBoard(player.Grid);
            Console.WriteLine("Your enemy's board");
            Board.DrawBoard(player.EnemyGrid);
            Console.WriteLine("\nNow shoot!");
            Console.WriteLine();
            Console.WriteLine("Enter x");
            string readLineResult = Console.ReadLine();
            if (!int.TryParse(readLineResult, out int x))
            {
                Console.WriteLine("It's not a number!");
                Console.WriteLine("Press any key to exit the game...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.WriteLine("Enter y");
            readLineResult = Console.ReadLine();
            if (!int.TryParse(readLineResult, out int y))
            {
                Console.WriteLine("It's not a number!");
                Console.WriteLine("Press any key to exit the game...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            player.Shoot(botPlayer, x, y);
        }

        private void BotShoot()
        {
            botPlayer.Shoot(player, random.Next(0, globals.BoardWidth - 1), random.Next(0, globals.BoardHeight - 1));
        }

        private bool IsWinningShot(BasePlayer player)
        {
            if (player.ShotsHitNumber == player.WinningShotsNumber)
                return true;
            else return false;
        }
    }
}
