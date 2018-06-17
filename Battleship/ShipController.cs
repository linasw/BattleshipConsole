using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class ShipController
    {
        public char[,] Grid { get; set; }
        private char[,] _tempGrid;

        public ShipController()
        {
            Grid = new char[10, 10];
            _tempGrid = new char[10, 10];
            InitializeCleanGrid(Grid);
            InitializeCleanGrid(_tempGrid);
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

        //0 - no errors; 1 - Ship can't be placed diagonally; 2 - Ship's length can't be 1; 3 - Ship can't be placed on occupied tile; 4 - unknown
        public int AddShip(int firstColumn, int firstRow, int secondColumn, int secondRow) 
        {
            if (IsPlacedDiagonally(firstColumn, firstRow, secondColumn, secondRow))
            {
                return 1;
            }

            if (IsLenghtMoreThan1(firstColumn, firstRow, secondColumn, secondRow))
            {
                return 2;
            }

            if (firstColumn == secondColumn)
            {
                if (firstRow < secondRow)
                    return AddColumnShip(firstColumn, firstRow, secondRow);
                else
                    return AddColumnShip(firstColumn, secondRow, firstRow);
            }

            if (firstRow == secondRow)
            {
                if (firstColumn < secondColumn)
                    return AddRowShip(firstRow, firstColumn, secondColumn);
                else
                    return AddRowShip(firstRow, secondColumn, firstColumn);
            }
            return 4;
        }

        private int AddColumnShip(int column, int rowStart, int rowEnd)
        {
            while (rowStart <= rowEnd)
            {
                if (IsOccupied(column, rowStart))
                    return 3;
                _tempGrid[rowStart, column] = 'O';
                rowStart++;
            }

            Grid = _tempGrid;
            return 0;
        }

        private int AddRowShip(int row, int columnStart, int columnEnd)
        {
            while (columnStart <= columnEnd)
            {
                if (IsOccupied(columnStart, row))
                    return 3;
                _tempGrid[row, columnStart] = 'O';
                columnStart++;
            }

            Grid = _tempGrid;
            return 0;
        }

        private bool IsOccupied(int x, int y)
        {
            if (Grid[y, x].Equals('O'))
                return true;
            else return false;
        }

        private bool IsPlacedDiagonally(int firstColumn, int firstRow, int secondColumn, int secondRow)
        {
            if (firstColumn != secondColumn && firstRow != secondRow)
                return true;
            else return false;
        }

        private bool IsLenghtMoreThan1(int firstColumn, int firstRow, int secondColumn, int secondRow)
        {
            if (firstColumn == secondColumn && firstRow == secondRow)
                return true;
            else return false;
        }
    }
}
