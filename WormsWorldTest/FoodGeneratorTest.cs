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
        private const int randNum = 10;
        private const int FoodQuality = 10;
        private const int Life = 10;

        private FoodGenerator foodGenerator = new();

        [TestMethod]
        public void UniqFoodTest()
        {
            Dictionary<Position, int> food = new();
            for (BigInteger i = 0; i < randNum; i++)
                food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            Assert.AreEqual(randNum, food.Count);
        }

        [TestMethod]
        public void UniqFoodWithWormsTest()
        {
            List<Worm> worms = new List<Worm>();
            for (int i = -30; i < 30; i++)
            for (int j = -30; j < 30; j++)
                worms.Add(new Worm("worm", new Position(i, j), Life));
            Dictionary<Position, int> food = new();
            for (BigInteger i = 0; i < randNum; i++)
                food[foodGenerator.GetNewFoodPosition(food)] = FoodQuality;
            int num = 0;
            for (int i = 0; i < worms.Count; i++)
            {
                if (food.ContainsKey(worms[i].Position))
                    num++;
            }

            Assert.IsTrue(num > 0);
        }
    }
}