using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormsWorld.entity;

namespace WormsWorld
{
    [TestClass]
    public class FoodGeneratorTest
    {
        private const int FoodQuality = 10;

        private IFoodGenerator foodGenerator = new ConstFoodGenerator();

        [TestMethod]
        public void UniqFoodTest()
        {
            Dictionary<Position, int> food = new();
            food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            Assert.AreEqual(1, food.Count);
        }
        
        [TestMethod]
        [ExpectedException(typeof(TimeoutException),"can't add not equal food")]

        public void NotUniqFoodTest()
        {
            Dictionary<Position, int> food = new();
            food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
        }
    }
}