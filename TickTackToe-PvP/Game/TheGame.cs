using System.Linq;
using TickTackToe_PvP.Board;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP.Game
{
    public class TheGame : IGame
    {
        private int gameCounter = 0;
        private const int maxMoves = 9;
        private const string noWinnerSymbol = "n";
        private IPlayer player01 = new Player01(), player02 = new Player02();
        public IBoard GameBoard { get; private set; }

        public void ResetGame()
        {
            GameBoard.ResetMatrix();
            gameCounter = 0;
           
        }

        public TheGame(IBoard gameBoard)
        {
            this.GameBoard = gameBoard;
        }

        public string IsWinner(string[,] board)
        {
            string xSymbol = player01.Marker, oSymbol = player02.Marker;
           
            gameCounter++;

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
                if (column.All(x => x == xSymbol )) return xSymbol;
                //Player02 winner
                if (column.All(o => o == oSymbol )) return oSymbol;

            }

            //Check diagonals
            string[] diagonal01 = new string[] { board[0, 0], board[1, 1], board[2, 2] };
            //Player01 winner
            if (diagonal01.All(x => x == xSymbol)) return xSymbol;
            //Player02 winner
            if (diagonal01.All(o => o == oSymbol )) return oSymbol;

            string[] diagonal02 = new string[] { board[0, 2], board[1, 1], board[2, 0] };
            //Player01 winner
            if (diagonal02.All(x => x == xSymbol )) return xSymbol;
            //Player02 winner
            if (diagonal02.All(o => o == oSymbol )) return oSymbol;

            return noWinnerSymbol;
        }

        public bool IsTie(string result)
        {
            if (this.gameCounter == maxMoves && result == noWinnerSymbol)
            {
                return true;
            }
            return false;
        }
    }
}
