using System;
using NFluent;

namespace GameOfLife
{
    public class GameParser : IGameParser
    {
        public Cell[,] Parse(string input)
        {
            string[] rows = input.Split(new[] {"\r\n"}, StringSplitOptions.None);

            var board = new Cell[rows.Count(), rows[0].Count()];

            for (int currentRowIndex = 0; currentRowIndex < rows.Count(); currentRowIndex++)
            {
                char[] rowOfCell = rows[currentRowIndex].ToCharArray();

                int currentColIndex2 = 0;
                for (int currentColIndex = 0; currentColIndex < rowOfCell.Length; currentColIndex++)
                {
                    char cell = rowOfCell[currentColIndex];

                    if (cell == DeadCellRepresentation)
                        board[currentRowIndex, currentColIndex2] = new DeadCell();

                    if (cell == LivingCellRepresentation)
                        board[currentRowIndex, currentColIndex2] = new LivingCell();

                    currentColIndex2++;
                }
            }

            return board;
        }

        public char LivingCellRepresentation
        {
            get { return '*'; }
        }

        public char DeadCellRepresentation
        {
            get { return '.'; }
        }
    }
}