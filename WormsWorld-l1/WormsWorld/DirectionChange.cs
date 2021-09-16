using System.Threading;

namespace WormsWorld
{
    public interface DirectionChange
    {
        StepDirection ChangeDirection(Position position);
    }
}