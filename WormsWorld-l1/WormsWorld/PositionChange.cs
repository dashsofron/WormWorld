using System.Threading;

namespace WormsWorld
{
    public interface PositionChange
    {
        void changePosition(Position position,StepDirection stepDirection);
    }
}