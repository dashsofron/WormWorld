using System.Threading;

namespace WormsWorld
{
    public interface IDirectionChange
    {
        StepDirection ChangeDirection(Position position);
    }
}