namespace GameOfLife
{
    public class Game
    {
        private Cell[,] _board;
        private readonly int _numberOfRow;
        private readonly int _numberOfCol;
        public Game(string input, IGameParser parser)
        {
            _board = parser.Parse(input);
            _numberOfRow = _board.GetUpperBound(0) + 1;
            _numberOfCol = _board.GetUpperBound(1) + 1;
        }

        public void Play()
        {
            var newBoard = new Cell[_numberOfRow,_numberOfCol]; 

            for (var rowIndex = 0; rowIndex < _numberOfRow; rowIndex++)
            {
                for (var colIndex = 0; colIndex < _numberOfCol; colIndex++)
                {
                    var cell = _board[rowIndex, colIndex];
                    newBoard[rowIndex, colIndex] = cell;

                    if (cell.IsAlive && 
                        (CellIsUnderpopulation(rowIndex, colIndex) || CellIsOvercrowding(rowIndex,colIndex)))
                        newBoard[rowIndex, colIndex] = new DeadCell();

                    else if(!cell.IsAlive && CellCanRegenerate(rowIndex, colIndex))
                        newBoard[rowIndex, colIndex] = new LivingCell();
                }
            }

            _board = newBoard;
        }

        private bool CellCanRegenerate(int rowIndex, int colIndex)
        {
            return CountLivingNeighbours(rowIndex, colIndex) == 3;
        }

        private bool CellIsOvercrowding(int rowIndex, int colIndex)
        {
            return CountLivingNeighbours(rowIndex, colIndex) > 3;
        }

        private bool CellIsUnderpopulation(int rowIndex, int colIndex)
        {
            return CountLivingNeighbours(rowIndex, colIndex) < 2;
        }

        private int CountLivingNeighbours(int rowIndex, int colIndex)
        {
            var nbNeighboursLive = 0;

            for (var i = -1; i <= 1; i++)
            {
                for (var j = -1; j <= 1; j++)
                {
                    var rowIndexToTest = rowIndex + i;
                    var colIndexToTest = colIndex + j;

                    if (CellIsNotInGrid(rowIndexToTest, colIndexToTest))
                        continue;

                    var cell = _board[rowIndexToTest, colIndexToTest];
                    if (cell.IsAlive && cell != _board[rowIndex, colIndex])
                        nbNeighboursLive++;
                }
            }

            return nbNeighboursLive;
        }

        private bool CellIsNotInGrid(int rowIndex, int colIndex)
        {
            return (rowIndex < 0 || rowIndex > 3) || (colIndex < 0 || colIndex > 7);
        }

        public string Display(IGameDisplayer displayer)
        {
            return displayer.Display(_board);
        }
    }
}