using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class BasePlayer
    {
        protected int _boardWidth;
        protected int _boardHeight;
        public List<List<char>> Grid { get; set; }
        public List<List<char>> EnemyGrid { get; set; }
        public int ShotsHitNumber { get; set; }
        public int WinningShotsNumber { get; set; }

        public BasePlayer(int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            ShotsHitNumber = 0;
            WinningShotsNumber = 0;
            Grid = new List<List<char>>();
            EnemyGrid = new List<List<char>>();
            InitializeCleanGrid(Grid);
            InitializeCleanGrid(EnemyGrid);
        }

        private void InitializeCleanGrid(List<List<char>> grid)
        {
            for (int i = 0; i < _boardHeight; i++)
            {
                List<char> row = new List<char>();
                for (int j = 0; j < _boardWidth; j++)
                {
                    row.Add(' ');
                }
                grid.Add(row);
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
