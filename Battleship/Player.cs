using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Player
    {
        public char[,] Grid;
        public char[,] EnemyGrid;

        public Player()
        {
            Grid = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Grid[i, j] = ' ';
                }
            }

            EnemyGrid = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    EnemyGrid[i, j] = ' ';
                }
            }
        }

        private void InitializeCleanGrid(char [,] grid)
        {
            grid = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }

        public char[,] GetYourGrid()
        {
            return Grid;
        }

        public char[,] GetEnemyGrid()
        {
            return EnemyGrid;
        }

        public void SetEnemyGrid(int x, int y, char status)
        {
            EnemyGrid[y, x] = status;
        }

        public void InitialSetGrid(char[,] grid)
        {
            Grid = grid;
        }

        public void Shoot(Player enemyPlayer, int x, int y)
        {
            char[,] enemyGridStatus = enemyPlayer.GetYourGrid();

            if (enemyGridStatus[y, x].Equals(' '))
            {
                SetEnemyGrid(x, y, 'M');
                Console.WriteLine("You missed!");
                return;
            }

            if (enemyGridStatus[y, x].Equals('M') || enemyGridStatus[x, y].Equals('S'))
            {
                Console.WriteLine("Can't shoot in the same space!");
                return;
            }

            if (enemyGridStatus[y, x].Equals('O'))
            {
                SetEnemyGrid(x, y, 'S');
                Console.WriteLine("Nice shot!");
                return;
            }
        }
    }
}
