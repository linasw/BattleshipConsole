using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class ShipController
    {
        char[,] Grid;
        private char[,] tempGrid;

        public ShipController()
        {
            Grid = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Grid[i, j] = ' ';
                }
            }

            CleanTempGrid();
        }

        public char[,] GetGrid()
        {
            return Grid;
        }

        private void CleanTempGrid()
        {
            tempGrid = new char[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    tempGrid[i, j] = ' ';
                }
            }
        }
        //0 - no errors; 1 - Ship can't be placed diagonally; 2 - Ship's length can't be 1; 3 - Ship can't be placed on occupied tile; 4 - unknown
        public int AddShip(int firstColumn, int firstRow, int secondColumn, int secondRow) 
        {
            if (firstColumn != secondColumn && firstRow != secondRow) //Ship can't be placed diagonally
            {
                return 1;
            }

            if (firstColumn == secondColumn && firstRow == secondRow) //Ship's length can't be 1
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
                if (CheckIfOccupied(column, rowStart))
                    return 3;
                tempGrid[rowStart, column] = 'O';
                rowStart++;
            }

            Grid = tempGrid;
            return 0;
        }

        private int AddRowShip(int row, int columnStart, int columnEnd)
        {
            while (columnStart <= columnEnd)
            {
                if (CheckIfOccupied(columnStart, row))
                    return 3;
                tempGrid[row, columnStart] = 'O';
                columnStart++;
            }

            Grid = tempGrid;
            return 0;
        }

        private bool CheckIfOccupied(int x, int y)
        {
            if (Grid[y, x].Equals('O'))
                return true;
            else return false;
        }
    }
}
