namespace WormsWorld
{
    public class SimplePositionChange : PositionChange

    {
        private int step = 1;

        public void changePosition(Position position, StepDirection direction)
        {
            switch (direction)
            {
                case StepDirection.Left:
                    position.X -= step;
                    break;

                case StepDirection.Right:
                    position.X += step;
                    break;

                case StepDirection.Up:
                    position.Y += step;
                    break;

                case StepDirection.Down:
                    position.Y -= step;
                    break;
            }
        }
    }
}