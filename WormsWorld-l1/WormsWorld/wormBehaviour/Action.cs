using System;
using WormsWorld.entity;

namespace WormsWorld.wormBehaviour
{
    public class Action
    {
        public ActionType ActionType;
        public StepDirection Direction;

        public Action(ActionType type, StepDirection direction)
        {
            ActionType = type;
            Direction = direction;
        }
    }
}