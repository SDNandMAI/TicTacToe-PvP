using System;
using System.Collections.Generic;
using System.Text;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP.Board
{
    public interface IBoard
    {
        public string DrawBoard();

        public void UpdateMatrix(string playerMove, IPlayer player);

        public string InitialBoard();
        public void ResetMatrix();

        public string [,] BoardMatrix { get; }

    }
}
