using System.Collections.Generic;
using System.Threading;
using WormsWorld.wormBehaviour;

namespace WormsWorld.entity
{
    public class Worm
    {
        private readonly IDirectionChange _directionChange;

        public string Name { get; set; }

        public int Life { get; set; }

        public Position Position { get; set; }

        public Worm(string name, Position position, in int step, in int life)
        {
            Name = name;
            Position = position;
            _directionChange = new NearestFoodDirectionChange();
            Life = 10;
        }


        public Action GetNextAction(Dictionary<Position, int> food, List<Worm> worms)
        {
            return new Action(ActionType.Move, _directionChange.ChangeDirection(food, worms, Position));
        }

        public override string ToString()
        {
            return $"{Name} ({Position.X.ToString()},{Position.Y.ToString()},{Life.ToString()})";
        }
    }
}