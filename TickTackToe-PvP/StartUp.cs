using System;
using TickTackToe_PvP.Board;
using TickTackToe_PvP.Game;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP
{
    class StartUp
    {
        static void Main(string[] args)
        {
            IBoard board = new TheBoard();
            IGame game = new TheGame(board);
            IPlayer player01 = new Player01();
            IPlayer player02 = new Player02();
            StartScreen startScreen = new StartScreen();


           /* Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is the initial board");
            Console.ResetColor();
            Console.WriteLine(board.InitialBoard());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This is the new board when player one has made a move at 0,0");
            Console.ResetColor();
           *//* board.UpdateMatrix(0, 0, true, false);
            board.UpdateMatrix(0, 1, true, false);
            board.UpdateMatrix(0, 2, true, false);*//*
            Console.WriteLine(board.DrawBoard());

            var matrix = board.BoardMatrix;
            string result = game.IsWinner(matrix);
            Console.WriteLine(result);*/

            while (true)
            {
                startScreen.NewIndex(player01, player02);

                board.ResetMatrix();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(board.DrawBoard());
                    Console.Write($"Player01: ");
                    string player01Turn = Console.ReadLine();
                    player01.Turn = true;
                    board.UpdateMatrix(player01Turn, player01.Turn, player02.Turn); 
                    player01.Turn = false;
                 

                    string checkWinner = game.IsWinner(board.BoardMatrix);
                    if (checkWinner == "X")
                    {
                        player01.WinCount++;
                        player01.Winner = true;
                        Console.WriteLine("Player01 WINS!!\nPress [ENTER] to continue..");
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine(board.DrawBoard());
                    Console.Write($"Player02: ");
                    string player02Turn = Console.ReadLine();
                    player02.Turn = true;
                    board.UpdateMatrix(player02Turn, player01.Turn, player02.Turn);
                    player02.Turn = false;
                    checkWinner = game.IsWinner(board.BoardMatrix);
                    if (checkWinner == "O")
                    {
                        player02.WinCount++;
                        player02.Winner = true;
                        Console.WriteLine("Player02 WINS!!\nPress [ENTER] to continue..");
                        Console.ReadLine();
                        break;
                    }
                }

            }
        }
    }
}
