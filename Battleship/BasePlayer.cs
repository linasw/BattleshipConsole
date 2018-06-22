using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class BasePlayer
    {
        private int _boardHeight;
        private int _boardWidth;
        public char[,] Grid { get; set; }
        public char[,] EnemyGrid { get; set; }
        public int ShotsHitNumber { get; set; }
        public int WinningShotsNumber { get; set; }

        public BasePlayer(int boardHeight, int boardSize)
        {
            _boardHeight = boardHeight;
            _boardWidth = boardSize;
            ShotsHitNumber = 0;
            WinningShotsNumber = 0;
            Grid = new char[_boardHeight, _boardWidth];
            EnemyGrid = new char[_boardHeight, _boardWidth];
            InitializeCleanGrid(Grid);
            InitializeCleanGrid(EnemyGrid);
        }

        private void InitializeCleanGrid(char[,] grid)
        {
            for (int i = 0; i < _boardHeight; i++)
            {
                for (int j = 0; j < _boardWidth; j++)
                {
                    grid[i, j] = 'o';
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
