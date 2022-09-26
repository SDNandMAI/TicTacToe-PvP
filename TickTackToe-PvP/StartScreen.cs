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
            Console.WriteLine("Press [ENTER] to start TicTacToe game.");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"{player01.Name} wins {player01.WinCount} vs {player02.Name} wins {player02.WinCount}");
            Console.ReadLine();

        }
    }
}
