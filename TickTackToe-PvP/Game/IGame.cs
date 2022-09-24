using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Game
{
    public interface IGame
    {
        public bool IsWinner(string [,] board);

        int Player01Wins { get; }
        int Player02Wins { get; }
    }
}
