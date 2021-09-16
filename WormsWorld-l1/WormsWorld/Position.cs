namespace WormsWorld
{
    public class Position
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set => _x = value;
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}