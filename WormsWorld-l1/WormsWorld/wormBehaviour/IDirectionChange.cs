using System.Collections.Generic;
using System.Threading;
using WormsWorld.entity;

namespace WormsWorld
{
    public interface IDirectionChange
    {
        StepDirection ChangeDirection(
            Dictionary<Position, int> food,
            List<Worm> worms,
            Position position
        );
    }
}