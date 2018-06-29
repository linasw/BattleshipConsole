using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class BotPlayer : BasePlayer
    {
        public BotPlayer(int boardWidth, int boardHeight) : base(boardWidth, boardHeight)
        {
            
        }

        public override void Shoot(BasePlayer enemyPlayer, int x, int y)
        {
            if (enemyPlayer.Grid[y][x].Equals(' '))
            {
                Console.WriteLine($"The bot shot at ({x}, {y}) and he missed!");
                enemyPlayer.Grid[y][x] = 'M';
                EnemyGrid[y][x] = 'M';
                return;
            }

            if (enemyPlayer.Grid[y][x].Equals('M') || EnemyGrid[y][x].Equals('S'))
            {
                if (x == _boardWidth && y == _boardHeight)
                {
                    Shoot(enemyPlayer, 0, 0);
                    return;
                }
                else if (x == _boardWidth && y < _boardHeight)
                {
                    Shoot(enemyPlayer, 0, ++y);
                    return;
                }
                else if (x <= _boardWidth)
                {
                    Shoot(enemyPlayer, ++x, y);
                    return;
                }
                return;
            }

            if (enemyPlayer.Grid[y][x].Equals('O'))
            {
                Console.WriteLine($"The bot shot at ({x}, {y}) and he didn't miss this time!");
                ShotsHitNumber++;
                enemyPlayer.Grid[y][x] = 'S';
                EnemyGrid[y][x] = 'S';
                return;
            }
        }
    }
}
