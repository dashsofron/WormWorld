using System.Collections.Generic;
using WormsWorld.entity;

namespace WormsWorld
{
    public interface IFoodGenerator
    {
        public Position GetNewFoodPosition(in Dictionary<Position, int> food);
    }
}