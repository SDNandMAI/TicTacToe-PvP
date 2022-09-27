using System;
using System.Collections.Generic;
using System.Text;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP
{
    public class StartScreen
    {
       public void NewIndex(IPlayer player01, IPlayer player02)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            //Console.BackgroundColor = ConsoleColor.DarkCyan;
            string initialMessage = "Press [ENTER] to start a new TicTacToe game.";
            CenterText(initialMessage);
            Console.WriteLine(initialMessage);
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Blue;
            string playerStats = $"{player01.Name} wins {player01.WinCount} vs {player02.Name} wins {player02.WinCount}";
            CenterText(playerStats);
            Console.WriteLine(playerStats);
            Console.ReadLine();
            Console.ResetColor();

        }

        private static void CenterText(string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            
        }
    }
}
