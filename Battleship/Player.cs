using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player : BasePlayer
    {
        public Player(int boardHeight, int boardWidth) : base(boardHeight, boardWidth)
        {

        }

        public override void Shoot(BasePlayer enemyPlayer, int x, int y)
        {
            if (enemyPlayer.Grid[y, x].Equals(' '))
            {
                EnemyGrid[y, x] = 'M';
                Console.Clear();
                Console.WriteLine("You missed!");
                Console.WriteLine();
                return;
            }

            if (enemyPlayer.Grid[y, x].Equals('M') || EnemyGrid[y, x].Equals('S'))
            {
                Console.Clear();
                Console.WriteLine("You just shot in the same place and lost your turn! Not very smart...");
                Console.WriteLine();
                return;
            }

            if (enemyPlayer.Grid[y, x].Equals('O'))
            {
                ShotsHitNumber++;
                EnemyGrid[y, x] = 'S';
                Console.Clear();
                Console.WriteLine("Nice shot!");
                Console.WriteLine();
                return;
            }
        }
    }
}
