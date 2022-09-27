using System;
using System.Text;
using TickTackToe_PvP.Players;

namespace TickTackToe_PvP.Board
{
    public class TheBoard : IBoard
    {
        private const int rows = 3, cols = 3;
        private const int boardMinValue = 1;
        private const int boardMaxValue = 9;
        private IPlayer player01 = new Player01();
        private IPlayer player02 = new Player02();
        public string[,] BoardMatrix { get; private set; }

        private readonly string[,] OriginalBoardMatrix = new string[rows, cols]
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };

        public TheBoard()
        {
            this.BoardMatrix = OriginalBoardMatrix.Clone() as string[,]; 
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

        public void UpdateMatrix(string playerMove, IPlayer player)
        {
            int result = 0;
            bool parsed = int.TryParse(playerMove, out result);
            if (!parsed || result < boardMinValue || result > boardMaxValue)
            {
                throw new ArgumentException(ExceptinMessages.InvalidPlayerMove);
            }

            int row = 0;
            int col = 0;
            bool found = false;
            for (int r = 0; r < OriginalBoardMatrix.GetLength(0); r++)
            {
                for (int c = 0; c < OriginalBoardMatrix.GetLength(1); c++)
                {
                    if (OriginalBoardMatrix[r,c] == playerMove)
                    {
                        if (BoardMatrix[r,c] == player01.Marker || BoardMatrix[r,c] == player02.Marker)
                        {
                            throw new ArgumentException(ExceptinMessages.OccupiedIndex);
                        }

                        row = r;
                        col = c;
                        found = true;
                        break;
                        
                    }
                }
                if (found) break;
            }
            if (player.Turn)
            {
                this.BoardMatrix[row, col] = player.Marker;
            }

           
        }

        public void ResetMatrix()
        {
            this.BoardMatrix = OriginalBoardMatrix.Clone() as string[,]; 
        }
    }
}
