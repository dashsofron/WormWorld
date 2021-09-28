namespace WormsWorld.entity
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Position()
        {
        }
        public Position(Position position)
        {
            X = position.X;
            Y = position.Y;
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public override int GetHashCode()
        {
            if (X == null || Y == null) return 0;
            return (X, Y).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Position other = obj as Position;
            return other != null && other.X == X && other.Y == Y;
        }
    }
}