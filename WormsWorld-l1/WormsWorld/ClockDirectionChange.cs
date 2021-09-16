namespace WormsWorld
{
    public class ClockDirectionChange :DirectionChange
    {
        private StepDirection _direction = StepDirection.Up;
        private int border = 1;
        
        public StepDirection ChangeDirection(Position position)
        {
            switch (_direction)
            {
                case StepDirection.Left:
                    if (position.X.Equals(-border))
                        _direction = StepDirection.Up;
                    break;
                case StepDirection.Right:
                    if (position.X.Equals(border))
                        _direction = StepDirection.Down;
                    break;

                case StepDirection.Up:
                    if (position.Y.Equals(border))
                        _direction = StepDirection.Right;

                    break;
                case StepDirection.Down:
                    if (position.Y.Equals(-border))
                        _direction = StepDirection.Left;
                    break;
            }

            return _direction;
        }
    }
}