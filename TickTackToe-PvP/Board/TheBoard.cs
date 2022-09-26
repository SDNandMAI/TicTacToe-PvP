using System;
using System.Collections.Generic;
using System.Text;

namespace TickTackToe_PvP.Board
{
    public class TheBoard : IBoard
    {
        private const int rows = 3, cols = 3;
        public string[,] BoardMatrix { get; private set; }

        private readonly string[,] OriginalBoardMatrix = new string[rows, cols]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

        public TheBoard()
        {
            this.BoardMatrix = new string[rows, cols]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        }

        public string DrawBoard()
        {
            StringBuilder board = new StringBuilder();

            board.AppendLine(@"___ ___ ___");
            board.AppendLine($" {BoardMatrix[0, 0]} | {BoardMatrix[0, 1]} | {BoardMatrix[0, 2]}");
            board.AppendLine(@"___ ___ ___");
            board.AppendLine($" {BoardMatrix[1, 0]} | {BoardMatrix[1, 1]} | {BoardMatrix[1, 2]}");
            board.AppendLine(@"___ ___ ___");
            board.AppendLine($" {BoardMatrix[2, 0]} | {BoardMatrix[2, 1]} | {BoardMatrix[2, 2]}");
            // board.AppendLine(@"___ ___ ___");


            return board.ToString();
        }

        public string InitialBoard()
        {
            this.ResetMatrix();
            return this.DrawBoard();
        }

        public void UpdateMatrix(string playerMove, bool player01Turn, bool player02Turn)
        {
            int row = 0;
            int col = 0;
            bool found = false;
            for (int r = 0; r < OriginalBoardMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < OriginalBoardMatrix.GetLength(1); c++)
                {
                    if (OriginalBoardMatrix[r,c] == playerMove.ToString())
                    {
                        row = r;
                        col = c;
                        found = true;
                        break;
                        
                    }
                }
                if (found) break;
            }

            string x = "X";
            string o = "O";

            if (player01Turn && !player02Turn)
            {
                this.BoardMatrix[row, col] = x;
            }

            if (!player01Turn && player02Turn)
            {
                this.BoardMatrix[row, col] = o;
            }
        }

        public void ResetMatrix()
        {
            this.BoardMatrix = new string[rows, cols]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        }
    }
}
