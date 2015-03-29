namespace GameOfLife
{
    internal class LivingCell : Cell
    {
        public override char Display()
        {
            return '*';
        }

        public override bool IsAlive { get { return true; } }
    }
}