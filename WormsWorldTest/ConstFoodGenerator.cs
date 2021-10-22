using System;
using System.Collections.Generic;
using WormsWorld.entity;

namespace WormsWorld
{
    public class ConstFoodGenerator : IFoodGenerator
    {
        private const int tryNum = 10;
        private Position constPosition = new Position(0, 0);

        public Position GetNewFoodPosition(in Dictionary<Position, int> food)
        {
            Position position = constPosition;
            int step = 0;
            while (food.ContainsKey(position) && step < tryNum)
            {
                position = constPosition;
                step++;
            }

            if (step >= tryNum)
                throw new TimeoutException("can't add not equal food");
            return position;
        }
    }
}