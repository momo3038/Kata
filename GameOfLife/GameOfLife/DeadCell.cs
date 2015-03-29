namespace GameOfLife
{
    internal class DeadCell : Cell
    {
        public override char Display()
        {
            return '.';
        }

        public override bool IsAlive
        {
            get { return false; }
        }
    }
}