using WormsWorld.entity;

namespace WormsWorld.wormBehaviour
{
    // странное название, не понятно что делает этот класс
    public class PositionGet
    {
        // _step можно сделать readonly, и не нужно его инициализировать 1,
        // так как он инициализируется в конструкторе
        private int _step = 1;

        // зачем тут in?
        public PositionGet(in int step)
        {
            _step = step;
        }

        // зачем тут in?
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