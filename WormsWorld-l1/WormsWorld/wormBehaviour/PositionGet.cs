using WormsWorld.entity;

namespace WormsWorld.wormBehaviour
{
    public class PositionGet
    {
        private int _step = 1;

        public PositionGet(in int step)
        {
            _step = step;
        }

        public Position GetNextPosition(in Position position, StepDirection direction)
        {
            Position nextPosition = new Position(position);
            switch (direction)
            {
                case StepDirection.Left:
                    nextPosition.X -= _step;
                    break;

                case StepDirection.Right:
                    nextPosition.X += _step;
                    break;

                case StepDirection.Up:
                    nextPosition.Y += _step;
                    break;

                case StepDirection.Down:
                    nextPosition.Y -= _step;
                    break;
            }

            return nextPosition;
        }
    }
}