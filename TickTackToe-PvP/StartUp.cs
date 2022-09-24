using System;
using TickTackToe_PvP.Board;

namespace TickTackToe_PvP
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IBoard board = new TheBoard();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is the initial board");
            Console.ResetColor();
            Console.WriteLine(board.InitialBoard());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is the new board when player one has made a move at 0,0");
            Console.ResetColor();
            Console.WriteLine(board.DrawBoard(0,0,true,false));
        }
    }
}
