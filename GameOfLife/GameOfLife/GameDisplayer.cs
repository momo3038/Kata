using System.Text;

namespace GameOfLife
{
    public class GameDisplayer : IGameDisplayer
    {
        public string Display(Cell[,] board)
        {
            var builder = new StringBuilder();

            for (int colIndex = 0; colIndex <=  board.GetUpperBound(0); colIndex++)
            {
                if (colIndex > 0)
                    builder.AppendLine();

                for (int rowIndex = 0; rowIndex <= board.GetUpperBound(1); rowIndex++)
                {
                    builder.Append(board[colIndex, rowIndex].Display());
                }
            }
            return builder.ToString();
        }
    }
}