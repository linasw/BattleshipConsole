using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class BasePlayer
    {
        public char[,] Grid { get; set; }
        public char[,] EnemyGrid { get; set; }
        public int ShotsHitNumber { get; set; }
        public int WinningShotsNumber { get; set; }

        public BasePlayer()
        {
            ShotsHitNumber = 0;
            WinningShotsNumber = 0;
            Grid = new char[10, 10];
            EnemyGrid = new char[10, 10];
            InitializeCleanGrid(Grid);
            InitializeCleanGrid(EnemyGrid);
        }

        private void InitializeCleanGrid(char[,] grid)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public void SetWinningShotNumber(int x, int y, int a, int b) //Counts ships length and sets WinningShotNumber
        {
            if (x != a)
                WinningShotsNumber += Math.Abs(x - a) + 1;
            else
                WinningShotsNumber += Math.Abs(y - b) + 1;
        }

        public abstract void Shoot(BasePlayer enemyPlayer, int x, int y);
    }
}
