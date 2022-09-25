using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using TickTackToe_PvP.Board;

namespace TickTackToe_PvP.Game
{
    public class TheGame : IGame
    {
        public IBoard GameBoard { get; private set; }

        public void ResetGame()
        {
            GameBoard.ResetMatrix();
            GameBoard.DrawBoard();
        }

        public TheGame(IBoard gameBoard)
        {
            this.GameBoard = gameBoard;
        }

        public string IsWinner(string[,] board)
        {
            string xSymbol = "X";
            string oSymbol = "O";
            string noWinnerSymbo = "n";

            for (int r = 0; r < board.GetLength(1); r++)
            {
                //check horizontal lines
                string[] line = new string[] { board[r,0],  board[r, 1],  board[r, 2] };
                //Player01 winner
                if (line.All(x => x == xSymbol )) return xSymbol;
                //Player02 winner
                if (line.All(o => o == oSymbol)) return oSymbol;


                //check vertical lines
                string[]column = new string[] { board[0, r], board[1, r], board[2, r] };
                //Player01 winner
                if (column.All(x => x == xSymbol || x == xSymbol)) return xSymbol;
                //Player02 winner
                if (column.All(o => o == xSymbol || o == oSymbol)) return oSymbol;

            }

            //Check diagonals
            string[] diagonal01 = new string[] { board[0, 0], board[1, 1], board[2, 2] };
            //Player01 winner
            if (diagonal01.All(x => x == xSymbol || x == xSymbol)) return xSymbol;
            //Player02 winner
            if (diagonal01.All(o => o == xSymbol || o == oSymbol)) return oSymbol;

            string[] diagonal02 = new string[] { board[0, 2], board[1, 1], board[2, 0] };
            //Player01 winner
            if (diagonal02.All(x => x == xSymbol || x == xSymbol)) return xSymbol;
            //Player02 winner
            if (diagonal02.All(o => o == xSymbol || o == oSymbol)) return oSymbol;

            return noWinnerSymbo;

            
        }
    }
}
