using System.Threading;

namespace WormsWorld
{
    public class Worm
    {
        private string _name;
        private Position _position;
        private IPositionChange _positionChange;
        private IDirectionChange _directionChange;


        public string Name { get; set; }

        public Worm(string name, Position position, in int step)
        {
            Name = name;
            _position = position;
            _positionChange = new SimplePositionChange(step);
            _directionChange = new ClockDirectionChange();
        }

        public void SetNextPosition()
        {
            _positionChange.changePosition(_position, _directionChange.ChangeDirection(_position));
        }

        public override string ToString()
        {
            return string.Format("{0} ({1},{2})", Name, _position.X.ToString(), _position.Y.ToString());
        }
    }
}