namespace GameOfLife
{
    public abstract class Cell
    {
        public abstract char Display();

        public abstract bool IsAlive { get; }
    }
}