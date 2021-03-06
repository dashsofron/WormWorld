using System.Collections.Generic;
using System.Threading;
using WormsWorld.wormBehaviour;

namespace WormsWorld.entity
{
    public class Worm
    {
        private readonly IDirectionChange _directionChange;

        public string Name { get; set; }

        public int LifeStrength { get; set; }

        public Position Position { get; set; }

        public Worm(string name, Position position, in int life)
        {
            Name = name;
            Position = position;
            _directionChange = new NearestFoodDirectionChange();
            LifeStrength = life;
        }


        public Action GetNextAction(Dictionary<Position, int> food, List<Worm> worms)
        {
            if (food.Count == 0) return new Action(ActionType.NoAction, StepDirection.NoDirection);
            return new Action(ActionType.Move, _directionChange.ChangeDirection(food, worms, Position));
        }

        public override string ToString()
        {
            return $"{Name} ({Position.X.ToString()},{Position.Y.ToString()},{LifeStrength.ToString()})";
        }
    }
}