namespace WormsWorld
{
    public class Position
    {
        private int _x;
        private int _y;

        public int X { get; set; }

        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}