using System;
using System.Collections.Generic;
using System.Text;
using TickTackToe_PvP.Board;

namespace TickTackToe_PvP.Game
{
    public interface IGame
    {
        public string IsWinner(string [,] board);

        public IBoard GameBoard { get; }
        public void ResetGame();


    }
}
