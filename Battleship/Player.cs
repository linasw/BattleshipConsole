using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player : BasePlayer
    {
        public Player(int boardWidth, int boardHeight) : base(boardWidth, boardHeight)
        {

        }

        public override void Shoot(BasePlayer enemyPlayer, int x, int y)
        {
            if (enemyPlayer.Grid[y][x].Equals(' '))
            {
                EnemyGrid[y][x] = 'M';
                Console.Clear();
                Console.WriteLine($"You shot at ({x}, {y}). That's a missed shot!");
                Console.WriteLine();
                return;
            }

            if (enemyPlayer.Grid[y][x].Equals('M') || EnemyGrid[y][x].Equals('S'))
            {
                Console.Clear();
                Console.WriteLine($"You just shot in the same place at ({x}, {y}) and lost your turn! Not very smart...");
                Console.WriteLine();
                return;
            }

            if (enemyPlayer.Grid[y][x].Equals('O'))
            {
                ShotsHitNumber++;
                EnemyGrid[y][x] = 'S';
                Console.Clear();
                Console.WriteLine($"You shot at ({x}, {y}). Nice shot!");
                Console.WriteLine();
                return;
            }
        }
    }
}
