using System;
using System.Security.Cryptography.X509Certificates;
using TickTackToe_PvP.Board;
using TickTackToe_PvP.Game;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP
{
    class StartUp
    {
        public static IGame game;
        public static IBoard board;
        static void Main(string[] args)
        {
            board = new TheBoard();
            game = new TheGame(board);
            IPlayer player01 = new Player01();
            IPlayer player02 = new Player02();
            StartScreen startScreen = new StartScreen();



            while (true)
            {
                startScreen.NewIndex(player01, player02);

                board.ResetMatrix();

                while (true)
                {
                    PlayerMakesMove(board, player01);
                   
                    if (GetWinner(player01)) break;

                    PlayerMakesMove(board, player02);
                
                    if (GetWinner(player02))  break;
                    
                }

            }
        }

        private static bool GetWinner(IPlayer player)
        {
            string checkWinner = game.IsWinner(board.BoardMatrix);
            if (checkWinner == player.Marker)
            {
                player.WinCount++;
                player.Winner = true;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(board.DrawBoard());
                Console.WriteLine($"{player.Name} WINS!!\nPress [ENTER] to continue..");
                Console.ResetColor();
                Console.ReadLine();
                return true;
            }
            return false;
        }
        private static void PlayerMakesMove(IBoard board, IPlayer player)
        {
            Console.Clear();
            Console.WriteLine(board.DrawBoard());
            Console.Write($"{player.Name}: ");
            string playerCommand = Console.ReadLine();
            player.Turn = true;
            board.UpdateMatrix(playerCommand, player);
            player.Turn = false;
        }
    }
}
