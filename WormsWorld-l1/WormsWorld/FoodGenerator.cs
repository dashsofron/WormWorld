using System.Collections.Generic;
using WormsWorld.entity;

namespace WormsWorld
{
    public class FoodGenerator
    {
        public static Position GetNewFoodPosition(in Dictionary<Position, int> food)
        {
            Position position = new Position(NormalRandGenerator.NextNormal(), NormalRandGenerator.NextNormal());
            while (food.ContainsKey(position))
            {
                position.X = NormalRandGenerator.NextNormal();
                position.Y = NormalRandGenerator.NextNormal();
            }

            return position;
        }
    }
}