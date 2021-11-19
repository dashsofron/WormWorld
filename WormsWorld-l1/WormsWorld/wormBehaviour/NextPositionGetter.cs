using WormsWorld.entity;

namespace WormsWorld.wormBehaviour
{
    public class NextPositionGetter
    {
        private readonly int _step;

        public NextPositionGetter(int step)
        {
            _step = step;
        }

        public Position GetNextPosition(Position position, StepDirection direction)
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