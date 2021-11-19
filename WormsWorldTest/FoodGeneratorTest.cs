using System;
using System.Collections.Generic;
using System.Numerics;
using FluentAssertions;
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
        public void SingleFoodTest()
        {
            Dictionary<Position, int> food = new();
            food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            Assert.AreEqual(1, food.Count);
        }
        
        [TestMethod]
        public void ConcurFoodTest()
        {
            Dictionary<Position, int> food = new();
            food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            Action act = () => foodGenerator.GetNewFoodPosition(food);
            act.Should().Throw<TimeoutException>();
        }
    }
}