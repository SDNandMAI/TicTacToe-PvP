﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Board
{
    public interface IBoard
    {
        public string DrawBoard();

        public void UpdateMatrix(int row, int col, bool player01Turn, bool player02Turn);

        public string InitialBoard();
        public void ResetMatrix();
        public string [,] BoardMatrix { get; }
        string[,] OriginalBoardMatrix { get;  }
    }
}
