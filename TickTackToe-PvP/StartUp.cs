using System;
using System.Threading.Tasks;
using TickTackToe_PvP.Board;
using TickTackToe_PvP.Game;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP
{
    class StartUp
    {
        public static IGame game;
        public static IBoard board;
        public static IPlayer player01;
        public static IPlayer player02;
        public static StartScreen startScreen;
        public const int delayTime = 3000;
        static async Task Main(string[] args)
        {
            board = new TheBoard();
            game = new TheGame(board);
            player01 = new Player01();
            player02 = new Player02();
            startScreen = new StartScreen();

            while (true)
            {
                startScreen.NewIndex(player01, player02);

                game.ResetGame();
                player01.Turn = true;
                if ((player01.WinCount + player02.WinCount) % 2 != 0)
                {
                    player01.Turn = false; 
                    player02.Turn = true;
                }
                
                while (true)
                {
                    if (player01.Turn)
                    {
                        DrawNewBoard(board);
                        Console.Write($"{player01.Name}: ");
                        try
                        {
                            PlayerMakesMove(board, player01);
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                            await Task.Delay(delayTime);
                            continue;
                        }
                       

                        if (await CheckForResult(player01)) break;
                        

                        player02.Turn = true;
                    }

                    if (player02.Turn)
                    {
                        DrawNewBoard(board);
                        Console.Write($"{player02.Name}: ");
                        try
                        {
                            PlayerMakesMove(board, player02);
                        }
                        catch (ArgumentException ae)
                        {

                            Console.WriteLine(ae.Message);
                            await Task.Delay(delayTime);
                            continue;
                        }
                        

                        if (await CheckForResult(player02)) break;

                        player01.Turn = true;
                        
                    }
                }
            }
        }

        private static async Task<bool> CheckForResult(IPlayer player)
        {
            string checkWinner = game.IsWinner(board.BoardMatrix);
            if (checkWinner == player.Marker)
            {
                player.WinCount++;
                player.Winner = true;
                await PrintWinner(player);
                return true;
            }

            if (game.IsTie(checkWinner))
            {
                await PrintTie();
                return true;
            }
            return false;
        }

        private static async Task PrintTie()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            DrawNewBoard(board);
            Console.WriteLine("You finished in a tie!, returnit to start screen...");
            Console.ResetColor();
            await Task.Delay(delayTime);
        }

        private static async Task PrintWinner(IPlayer player)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            DrawNewBoard(board);
            Console.WriteLine($"{player.Name} WINS!!, returning to start screen...");
            Console.ResetColor();
            await Task.Delay(delayTime);
        }

        private static void PlayerMakesMove(IBoard board, IPlayer player)
        {
            string playerCommand = Console.ReadLine();
            player.Turn = true;
            board.UpdateMatrix(playerCommand, player);
            player.Turn = false;
        }

        private static void DrawNewBoard(IBoard board)
        {
            Console.Clear();
            Console.WriteLine(board.DrawBoard());
        }

       
    }
}
