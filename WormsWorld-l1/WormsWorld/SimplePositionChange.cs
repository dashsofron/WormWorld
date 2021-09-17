namespace WormsWorld
{
    public class SimplePositionChange : IPositionChange

    {
        private int _step = 1;

        public SimplePositionChange(in int step)
        {
            _step = step;
        }

        public void changePosition(Position position, StepDirection direction)
        {
            switch (direction)
            {
                case StepDirection.Left:
                    position.X -= _step;
                    break;

                case StepDirection.Right:
                    position.X += _step;
                    break;

                case StepDirection.Up:
                    position.Y += _step;
                    break;

                case StepDirection.Down:
                    position.Y -= _step;
                    break;
            }
        }
    }
}