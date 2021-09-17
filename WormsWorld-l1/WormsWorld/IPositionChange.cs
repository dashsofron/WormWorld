using System.Threading;

namespace WormsWorld
{
    public interface IPositionChange
    {
        void changePosition(Position position, StepDirection stepDirection);
    }
}