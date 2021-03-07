using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adelaide.DP
{
    using static System.Console;
    class Position
    {
        int rowNumber;
        int colNumber;
        bool isUsed = false;
        bool canBeUsed = true;

        public Position(int rowNumber, int colNumber, bool isUsed, bool canBeUsed)
        {
            this.rowNumber = rowNumber;
            this.colNumber = colNumber;
            this.isUsed = isUsed;
            this.canBeUsed = canBeUsed;

        }

        public void PrintPosition()
        {
            if (isUsed)
                Write("Q");
            else
                Write("-");        
        }

        public bool CanBeUsed()
        {
            return this.canBeUsed;
        }

        public void UpdatePositionUsage(bool isSet)
        {
            this.isUsed = isSet;
        }

        public void UpdatePositionAvailability(bool isSet)
        {
            this.canBeUsed = isSet;
        }
    }



    class ChessBoard
    {
        int boardLength;
      
        public Position[][] positions;

        public int GetBoardLength()
        {
            return boardLength;
        }

        public Position GetPosition(int row, int col)
        {
            return positions[row][col];
        }

        public ChessBoard(int numberOfRows) 
        {
            boardLength = numberOfRows;
            positions = new Position[boardLength][]; // why it's now allowing me to use new Position[boardLength][boardLength] ?

            for (int i = 0; i < boardLength; i++)
            {
                positions[i] = new Position[boardLength]; // not sure why I couldn't just initialize it 1 go

                for (int j = 0; j < boardLength; j++)
                {
                    positions[i][j] = new Position(i, j, false, true);
                }
            }
        }

        public void PrintChessBoard()
        {
            for (int i = 0; i < boardLength; i++)
            {
                WriteLine();
                for (int j = 0; j < boardLength; j++)
                {
                    positions[i][j].PrintPosition();
                }
            }
        }

        public void UpdatePositionWithQueen(int row, int column, bool isSet)
        {        
            positions[row][column].UpdatePositionUsage(isSet);

            // update next rows with this column being used. 
            for (int i = row; i < boardLength; i++)
            {
                positions[i][column].UpdatePositionAvailability(!isSet);
            }

            // update next diagonals with this oclumn being used. 
            for (int i = row; i < boardLength; i++)
            {
                positions[i][i+column].UpdatePositionAvailability(!isSet);
            }
        }
    }

    class NQueens
    {
        List<ChessBoard> solutions = new List<ChessBoard>();
        bool setQueen = true;
        // try to solve N-Queens by backtracking
        private void solveNQueensRecursion(ChessBoard board, int row)
        {
            bool placedInThisRow = false;
            for (int col = 0; col < board.GetBoardLength(); col++)
            {
                if (board.GetPosition(row, col).CanBeUsed())
                {
                    board.UpdatePositionWithQueen(row, col, setQueen);
                    placedInThisRow = true;
                }
            }

            if(placedInThisRow)
            {
                // we found the solution
                if (row == board.GetBoardLength())
                {
                    board.PrintChessBoard();
                    return;
                }
                else
                {
                    solveNQueensRecursion(board, row + 1); 
                }
            }
        }

        private void solveNQueensBase(ChessBoard board)
        {

        }


    }
}
