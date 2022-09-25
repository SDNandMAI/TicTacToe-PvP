using System;
using TickTackToe_PvP.Board;
using TickTackToe_PvP.Game;

namespace TickTackToe_PvP
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IBoard board = new TheBoard();
            IGame game = new TheGame(board);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is the initial board");
            Console.ResetColor();
            Console.WriteLine(board.InitialBoard());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is the new board when player one has made a move at 0,0");
            Console.ResetColor();
            board.UpdateMatrix(0, 0, true, false);
            board.UpdateMatrix(0, 1, true, false);
            board.UpdateMatrix(0, 2, true, false);
            Console.WriteLine(board.DrawBoard());

            var matrix = board.BoardMatrix;
            string result = game.IsWinner(matrix);
            Console.WriteLine(result);
        }
    }
}
