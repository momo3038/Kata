namespace GameOfLife
{
    public interface IGameParser
    {
        Cell[,] Parse(string input);
        char LivingCellRepresentation { get; }
        char DeadCellRepresentation { get; }
    }
}