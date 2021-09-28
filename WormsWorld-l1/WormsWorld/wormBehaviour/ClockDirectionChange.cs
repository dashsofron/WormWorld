using System.Collections.Generic;
using WormsWorld.entity;

namespace WormsWorld.wormBehaviour
{
    public class ClockDirectionChange : IDirectionChange
    {
        private StepDirection _direction = StepDirection.Up;
        private const int Border = 1;

        public StepDirection ChangeDirection(
            Dictionary<Position, int> food,
            List<Worm> wormsPosition,
            Position position
        )
        {
            switch (_direction)
            {
                case StepDirection.Left:
                    if (position.X.Equals(-Border))
                        _direction = StepDirection.Up;
                    break;
                case StepDirection.Right:
                    if (position.X.Equals(Border))
                        _direction = StepDirection.Down;
                    break;

                case StepDirection.Up:
                    if (position.Y.Equals(Border))
                        _direction = StepDirection.Right;

                    break;
                case StepDirection.Down:
                    if (position.Y.Equals(-Border))
                        _direction = StepDirection.Left;
                    break;
            }

            return _direction;
        }
    }
}