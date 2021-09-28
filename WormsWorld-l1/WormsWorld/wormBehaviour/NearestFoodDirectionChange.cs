using System;
using System.Collections.Generic;
using WormsWorld.entity;

namespace WormsWorld.wormBehaviour
{
    public class NearestFoodDirectionChange : IDirectionChange
    {
        public StepDirection ChangeDirection(
            Dictionary<Position, int> food,
            List<Worm> worms,
            Position position
        )
        {
            int stepsToFood = Int32.MaxValue;
            Position foodPosition = new Position();
            int foodValue = 0;
            foreach (var foodItem in food)
            {
                var stepsToThisFoodItem = Math.Abs(foodItem.Key.X - position.X) + Math.Abs(foodItem.Key.Y - position.Y);
                if (stepsToThisFoodItem < stepsToFood ||
                    stepsToThisFoodItem == stepsToFood && foodValue < foodItem.Value)

                {
                    stepsToFood = stepsToThisFoodItem;
                    foodPosition = foodItem.Key;
                    foodValue = foodItem.Value;
                }
            }

            if (foodPosition.X > position.X)
            {
                return StepDirection.Right;
            }

            if (foodPosition.X != position.X)
            {
                return StepDirection.Left;
            }

            if (foodPosition.Y > position.Y)
            {
                return StepDirection.Up;
            }

            {
                return StepDirection.Down;
            }
        }
    }
}