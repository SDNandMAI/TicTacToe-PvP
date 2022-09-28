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
