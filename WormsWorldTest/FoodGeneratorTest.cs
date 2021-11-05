using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WormsWorld.entity;

namespace WormsWorld
{
    // как понимаю эти тесты проверяют ConstFoodGenerator
    // вместо реального FoodGenerator
    [TestClass]
    public class FoodGeneratorTest  
    {
        private const int FoodQuality = 10;

        private IFoodGenerator foodGenerator = new ConstFoodGenerator();

        // по названию теста не понятно что он проверяет
        [TestMethod]
        public void UniqFoodTest()
        {
            Dictionary<Position, int> food = new();
            food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            Assert.AreEqual(1, food.Count);
        }
        
        // рекомендую использовать FluentAssertion библиотеку
        // там можно использовать следующий синтаксис
        // Action act = () => foodGenerator.GetNewFoodPosition(food);
        // act.Should().Throw<TimeoutException>();
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